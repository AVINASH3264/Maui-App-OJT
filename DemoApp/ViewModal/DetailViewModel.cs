using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.ViewModal
{
    public partial class DetailViewModel : ObservableObject
    {
        TaskDatabase database;
        TaskItem item;

        public DetailViewModel(TaskDatabase database)
        {
            this.database = database;
        }

        public string Text
        {
            get => item?.Text;
            set
            {
                if (item != null)
                {
                    item.Text = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool Done
        {
            get => item?.Done ?? false;
            set
            {
                if (item != null)
                {
                    item.Done = value;
                    OnPropertyChanged();
                }
            }
        }

        public int ID
        {
            set
            {
                var taskItem = database.GetItemsAsync().Result.FirstOrDefault(i => i.ID == value);
                if (taskItem != null)
                {
                    item = taskItem;
                    OnPropertyChanged(nameof(Text));
                    OnPropertyChanged(nameof(Done));
                }
            }
        }

        [RelayCommand]
        async Task GoBack()
        {
            await database.SaveItemAsync(item);
            await Shell.Current.GoToAsync("..");
        }
    }
}
