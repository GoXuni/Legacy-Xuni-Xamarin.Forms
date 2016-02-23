using System;
using Xamarin.Forms;
using FlexGridCustomRenderer.iOS;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ExportRenderer (typeof(FlexGridCustomRenderer.CustomChangeView), typeof(CustomChangeViewRenderer))]
namespace FlexGridCustomRenderer.iOS
{
	public class CustomChangeViewRenderer : ViewRenderer<CustomChangeView, UIKit.UIView>
	{
		UIView layoutPanel;
		UILabel textValue;
		UIImageView imgArrow;

		protected override void OnElementChanged(ElementChangedEventArgs<FlexGridCustomRenderer.CustomChangeView> e)
		{
			base.OnElementChanged (e);

			if (Control == null) {
				// initialize layout
				layoutPanel = new UIView ();
				// initialize image
				imgArrow = new UIImageView ();
				imgArrow.Frame = new CoreGraphics.CGRect (0, 0, 25, 25);
				layoutPanel.AddSubview (imgArrow);
				// initialize label
				textValue = new UILabel ();
				textValue.Font = UIFont.FromName ("Helvetica", 14f);
				textValue.Frame = new CoreGraphics.CGRect (25, 0, 100, 25);
				layoutPanel.AddSubview (textValue);
				// set control
				SetNativeControl (layoutPanel);
			}

			if (e.OldElement != null) {
				// unsubscribe
			}

			if (e.NewElement != null) {
				// subscribe
				textValue.Text = e.NewElement.Value.ToString ("n2");
				if (e.NewElement.Value < 0) {
					textValue.TextColor = UIColor.FromRGB (231, 76, 60);
					imgArrow.Image = UIImage.FromFile ("Arrow-Down-64.png");
				} else if (e.NewElement.Value > 0) {
					textValue.TextColor = UIColor.FromRGB (46, 204, 113);
					imgArrow.Image = UIImage.FromFile ("Arrow-Up-64.png");
				}
			}
		}
	}
}

