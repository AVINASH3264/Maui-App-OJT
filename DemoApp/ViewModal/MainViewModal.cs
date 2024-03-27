using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoApp.ViewModal
{
    public partial class MainViewModal : ObservableObject
    {
        IConnectivity connectivity;
        TaskDatabase database;
        public MainViewModal(IConnectivity connectivity, TaskDatabase database)
        {
            Items = new ObservableCollection<TaskItem>();
            this.connectivity = connectivity;
            this.database = database;
            LoadItems();
            //GoToDetailPageCommand = new Command(async () => await Shell.Current.GoToAsync("DetailPage"));
        }

        public ObservableCollection<TaskItem> Items { get; set; }
        //public ICommand GoToDetailPageCommand { get; set; }

        [ObservableProperty]
        string? text;

        [RelayCommand]
        async Task Add()
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Oops!", "Check Your Internet ", "Try again");
                return;
            }
            //add item 
            var item = new TaskItem { Text = Text, Done = false };
            await database.SaveItemAsync(item);
            Items.Add(item);
            Text = string.Empty;
        }

        [RelayCommand]
        async Task Delete(TaskItem item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
                await database.DeleteItemAsync(item);
            }
        }

        [RelayCommand]
        async Task Tap(TaskItem item)
        {
            if (item != null)
            {
                // Create a new DetailViewModel with the TaskDatabase and TaskItem ID
                var viewModel = new DetailViewModel(database);
                viewModel.ID = item.ID;

                // Navigate to the DetailPage with the DetailViewModel
                await Shell.Current.GoToAsync($"{nameof(DetailPage)}");
                Shell.Current.CurrentPage.BindingContext = viewModel;
            }
        }


        private void LoadItems()
        {
            var items = database.GetItemsAsync().Result;
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
    }
}
