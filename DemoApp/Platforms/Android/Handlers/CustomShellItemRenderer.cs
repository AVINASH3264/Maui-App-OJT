using Microsoft.Maui.Controls.Platform.Compatibility;
using Android.Views;
using Android.OS;
using DemoApp.CustomControls;
using Android.Widget;
using Android.Graphics.Drawables;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Platform;
using Microsoft.Maui.Controls.Platform;
using DemoApp.ViewModal;

namespace DemoApp.Handlers
{
    internal class CustomShellItemRenderer : ShellItemRenderer
    {
        public CustomShellItemRenderer(IShellContext context) : base(context)
        {
        }

        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            if (Context is not null && ShellItem is CustomTabBar { CenterViewVisible: true } tabbar)
            {
                var rootLayout = new FrameLayout(Context)
                {
                    LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)
                };

                rootLayout.AddView(view);
                const int middleViewSize = 100;
                var middleViewLayoutParams = new FrameLayout.LayoutParams(
                    ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent,
                    GravityFlags.CenterHorizontal | GravityFlags.Bottom)
                {
                    BottomMargin = 50,
                    Width = middleViewSize,
                    Height = middleViewSize
                };
                var middleView = new Android.Widget.Button(Context)
                {
                    LayoutParameters = middleViewLayoutParams
                };
                middleView.Click += async (s, e) =>
                {
                    Console.WriteLine("middleView clicked");
                    await Shell.Current.GoToAsync("//Account");
                };
                middleView.SetText(tabbar.CenterViewText, TextView.BufferType.Normal);
                middleView.SetPadding(0, 0, 0, 0);
                if (tabbar.CenterViewBackgroundColor is not null)
                {
                    var backgroundDrawable = new GradientDrawable();
                    backgroundDrawable.SetShape(ShapeType.Rectangle);
                    backgroundDrawable.SetCornerRadius(middleViewSize / 2f);
                    backgroundDrawable.SetColor(tabbar.CenterViewBackgroundColor.ToPlatform(Colors.Transparent));
                    middleView.SetBackground(backgroundDrawable);
                }

                tabbar.CenterViewImageSource?.LoadImage(Application.Current!.MainPage!.Handler!.MauiContext!, result =>
                {
                    middleView.SetBackground(result?.Value);
                    middleView.SetMinimumHeight(0);
                    middleView.SetMinimumWidth(0);
                });

                rootLayout.AddView(middleView);
                return rootLayout;
            }

            return view;
        }
    }

}
