using Gauges101.Resources;
using Xamarin.Forms;

namespace Gauges101
{
    public partial class UsingRanges : ContentPage
    {
        public UsingRanges()
        {
            InitializeComponent();
            Title = AppResources.UsingRangesTitle;

            BindingContext = new SampleViewModel() { Value = 25 };

            linearGauge.Pointer.Thickness = 0.5;
            radialGauge.Pointer.Thickness = 0.5;
        }
    }
}
