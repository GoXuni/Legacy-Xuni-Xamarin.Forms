using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xuni.Xamarin.Gauge;

namespace GaugeDemo
{
    public partial class AutomaticScaling
    {
        private Random _rand = new Random();
        private TimeSpan _stepDuration = TimeSpan.FromSeconds(4);

        public AutomaticScaling()
        {
            InitializeComponent();

            BindingContext = new SampleViewModel() { Max = 200, Value = 60, ShowText = GaugeShowText.All };

            StartAngleStepper.ValueChanged += OnStartAngleChanged;
            SweepAngleStepper.ValueChanged += OnSweepAngleChanged;
            StartAngleLabel.Text = StartAngleStepper.Value.ToString("N0");
            SweepAngleLabel.Text = SweepAngleStepper.Value.ToString("N0");
            Gauge.UpdateAnimation.Duration = _stepDuration;
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
            await Task.Delay(Gauge.LoadAnimation.Duration);
            await AnimateNextStep();
        }

        private async Task AnimateNextStep()
        {
            var viewModel = BindingContext as SampleViewModel;
            double nextValue = _rand.Next((int)viewModel.Min, (int)viewModel.Max);
            viewModel.Value = nextValue;
            await Task.Delay(_stepDuration);
            await AnimateNextStep();
        }

    }
}
