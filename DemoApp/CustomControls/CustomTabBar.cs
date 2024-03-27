using System.Windows.Input;
using Maui.BindableProperty.Generator.Core;
namespace DemoApp.CustomControls
{
    public partial class CustomTabBar : TabBar
    {
        [AutoBindable]
        private ICommand? _centerViewCommand;

       

        [AutoBindable]
        private ImageSource? centerViewImageSource;

        [AutoBindable]
        private string? centerViewText;

        [AutoBindable]
        private bool centerViewVisible;

        [AutoBindable]
        public Color? centerViewBackgroundColor;


        
    }

}
