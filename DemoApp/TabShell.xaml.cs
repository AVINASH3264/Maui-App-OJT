namespace DemoApp;

public partial class TabShell : ContentPage
{
	public TabShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
    }
}