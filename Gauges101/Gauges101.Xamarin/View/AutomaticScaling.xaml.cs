using Gauges101.Resources;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xuni.Forms.Gauge;

namespace Gauges101
{
    public partial class AutomaticScaling : ContentPage
    {
        private Random _rand = new Random();
        private uint _stepDuration = 4000;

        public AutomaticScaling()
        {
            InitializeComponent();
            Title = AppResources.AutomaticScalingTitle;

            BindingContext = new SampleViewModel() { Max = 200, Value = 60, ShowText = GaugeShowText.All };

            StartAngleStepper.ValueChanged += OnStartAngleChanged;
            SweepAngleStepper.ValueChanged += OnSweepAngleChanged;
            StartAngleLabel.Text = StartAngleStepper.Value.ToString("N0");
            SweepAngleLabel.Text = SweepAngleStepper.Value.ToString("N0");
            Gauge.UpdateAnimation.Duration = _stepDuration - 500;
        }

        void OnStartAngleChanged(object sender, ValueChangedEventArgs e)
        {
            StartAngleLabel.Text = e.NewValue.ToString("N0");
        }

        void OnSweepAngleChanged(object sender, ValueChangedEventArgs e)
        {
            SweepAngleLabel.Text = e.NewValue.ToString("N0");
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(TimeSpan.FromMilliseconds(Gauge.LoadAnimation.Duration));
            await AnimateNextStep();
        }

        private async Task AnimateNextStep()
        {
            var viewModel = BindingContext as SampleViewModel;
            double nextValue = _rand.Next((int)viewModel.Min, (int)viewModel.Max);
            viewModel.Value = nextValue;
            await Task.Delay(TimeSpan.FromMilliseconds(_stepDuration));
            await AnimateNextStep();
        }

    }
}
