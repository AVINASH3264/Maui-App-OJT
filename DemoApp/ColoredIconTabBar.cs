using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    public class ColoredIconTabBar : TabBar
    {
        public static readonly BindableProperty ColoredIconProperty =
            BindableProperty.CreateAttached("ColoredIcon", typeof(ImageSource), typeof(ColoredIconTabBar), default(ImageSource));

        public static ImageSource GetColoredIcon(BindableObject view)
        {
            return (ImageSource)view.GetValue(ColoredIconProperty);
        }

        public static void SetColoredIcon(BindableObject view, ImageSource value)
        {
            view.SetValue(ColoredIconProperty, value);
        }
    }

}
