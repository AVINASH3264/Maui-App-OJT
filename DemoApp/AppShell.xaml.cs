using DemoApp.CustomControls;
using DemoApp.ViewModal;

namespace DemoApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        }
       
    }
}
