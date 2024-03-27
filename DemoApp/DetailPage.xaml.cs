using DemoApp.ViewModal;

namespace DemoApp;

public partial class DetailPage : ContentPage
{
    public DetailPage()
    {
        InitializeComponent();

        // Retrieve the DetailViewModel from the BindingContext
        var viewModel = (DetailViewModel)BindingContext;

        // Set the BindingContext of the page to the viewModel
        BindingContext = viewModel;
    }
}

