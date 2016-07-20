using Gauges101.Resources;
using Xamarin.Forms;
using Xuni.Forms.Gauge;

namespace Gauges101
{
    public partial class GettingStarted : ContentPage
    {
        public GettingStarted()
        {
            InitializeComponent();
            Title = AppResources.GettingStartedTitle;

            BindingContext = new SampleViewModel() { Value = 25, ShowText = GaugeShowText.None };

            ValueLabel.Text = ValueStepper.Value.ToString("N0");
            ValueStepper.ValueChanged += ValueStepper_ValueChanged;
        }

        void ValueStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            ValueLabel.Text = e.NewValue.ToString("N0");
        }
    }
}
