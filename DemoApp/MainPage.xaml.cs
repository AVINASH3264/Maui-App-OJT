using DemoApp.ViewModal;

namespace DemoApp
{
    public partial class MainPage : ContentPage
    {
      

        public MainPage(MainViewModal vm)
        {
            InitializeComponent();
            BindingContext = vm;

        }

       

    }

}
