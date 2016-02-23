using FlexGridCustomRenderer;
using FlexGridCustomRenderer.WinPhone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(CustomChangeView), typeof(CustomChangeViewRenderer))]
namespace FlexGridCustomRenderer.WinPhone
{
    public class CustomChangeViewRenderer : ViewRenderer<CustomChangeView, System.Windows.Controls.StackPanel>
    {
        StackPanel layoutPanel;
        TextBlock textValue;
        System.Windows.Controls.Image imgArrow;
        protected override void OnElementChanged(ElementChangedEventArgs<CustomChangeView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                layoutPanel = new StackPanel();
                layoutPanel.Orientation = Orientation.Horizontal;
                imgArrow = new System.Windows.Controls.Image();
                layoutPanel.Children.Add(imgArrow);
                textValue = new TextBlock();
                layoutPanel.Children.Add(textValue);
                
                //InitializeAsync();
                SetNativeControl(layoutPanel);
            }
            if (e.OldElement != null)
            {
                // Unsubscribe
                imgArrow.Source = null;
            }
            if (e.NewElement != null)
            {
                // Subscribe
                textValue.Text = e.NewElement.Value.ToString("n2");
                if(e.NewElement.Value < 0)
                {
                    imgArrow.Source = new BitmapImage(new Uri("Toolkit.Content/Arrow-Down-64.png", UriKind.RelativeOrAbsolute));
                    textValue.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 231, 76, 60));
                }
                else if(e.NewElement.Value > 0)
                {
                    imgArrow.Source = new BitmapImage(new Uri("Toolkit.Content/Arrow-Up-64.png", UriKind.RelativeOrAbsolute));
                    textValue.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 46, 204, 113));
                }
            }
        }
    }
}
