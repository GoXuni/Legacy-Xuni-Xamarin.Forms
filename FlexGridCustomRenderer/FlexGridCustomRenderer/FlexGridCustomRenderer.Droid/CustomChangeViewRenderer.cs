using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using FlexGridCustomRenderer.Droid;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FlexGridCustomRenderer.CustomChangeView), typeof(CustomChangeViewRenderer))]
namespace FlexGridCustomRenderer.Droid
{
    public class CustomChangeViewRenderer : ViewRenderer<FlexGridCustomRenderer.CustomChangeView, Android.Widget.LinearLayout>
    {
        LinearLayout layoutPanel;
        TextView textValue;
        ImageView imgArrow;
        protected override void OnElementChanged(ElementChangedEventArgs<FlexGridCustomRenderer.CustomChangeView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                layoutPanel = new LinearLayout(Context);
                layoutPanel.Orientation = Orientation.Horizontal;
                imgArrow = new ImageView(Context);
                layoutPanel.AddView(imgArrow);
                textValue = new TextView(Context);
                textValue.SetTextSize(Android.Util.ComplexUnitType.Dip, 16);
                textValue.SetPadding(0, 10, 0, 0);
                layoutPanel.AddView(textValue);
                SetNativeControl(layoutPanel);
            }

            if (e.OldElement != null)
            {
                // Unsubscribe
            }
            if (e.NewElement != null)
            {
                // Subscribe
                textValue.Text = e.NewElement.Value.ToString("n2");
                if (e.NewElement.Value < 0)
                {
                    imgArrow.SetImageResource(Resource.Drawable.arrowdown);
                    textValue.SetTextColor(Android.Graphics.Color.Argb(255, 231, 76, 60));
                }
                else if (e.NewElement.Value > 0)
                {
                    imgArrow.SetImageResource(Resource.Drawable.arrowup);
                    textValue.SetTextColor(Android.Graphics.Color.Argb(255, 46, 204, 113));
                }
            }
        }
    }
}