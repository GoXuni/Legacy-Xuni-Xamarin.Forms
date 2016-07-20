using Gauges101.Resources;
using Xamarin.Forms;
using Xuni.Forms.Gauge;

namespace Gauges101
{
    public partial class BulletGraph : ContentPage
    {
        public BulletGraph()
        {
            InitializeComponent();
            Title = AppResources.BulletGraphTitle;

            BindingContext = new SampleViewModel() { Value = 72, ShowText = GaugeShowText.All };
            BadLabel.Text = BadStepper.Value.ToString("N0");
            BadStepper.ValueChanged += BadStepper_ValueChanged;
            GoodLabel.Text = GoodStepper.Value.ToString("N0");
            GoodStepper.ValueChanged += GoodStepper_ValueChanged;
            TargetLabel.Text = TargetStepper.Value.ToString("N0");
            TargetStepper.ValueChanged += TargetStepper_ValueChanged;
        }

        void BadStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            BadLabel.Text = e.NewValue.ToString("N0");
        }

        void GoodStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            GoodLabel.Text = e.NewValue.ToString("N0");
        }

        void TargetStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            TargetLabel.Text = e.NewValue.ToString("N0");
        }
    }
}
