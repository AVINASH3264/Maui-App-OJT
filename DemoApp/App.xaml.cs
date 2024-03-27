using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.Application;
using System.Threading.Tasks;
using Sharpnado.Tabs;
namespace DemoApp
{
    public partial class App : Application
    {
        private TaskDatabase _database;

        public App()
        {
            InitializeComponent();
            Initializer.Initialize(false, false);
           
            MainPage = new AppShell();

            // Load the database when the app starts
            LoadDatabaseAsync();
        }

        private async Task LoadDatabaseAsync()
        {
            // Load your database here
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GetItDone.db3");
            _database = await TaskDatabase.CreateAsync(dbPath);

            // Load all items from the database
            var items = await _database.LoadAllItemsAsync();
        }

        protected override void OnStart()
        {
            base.OnStart();

            // Load the database when the app starts
            LoadDatabaseAsync();
        }

       
    }
}
