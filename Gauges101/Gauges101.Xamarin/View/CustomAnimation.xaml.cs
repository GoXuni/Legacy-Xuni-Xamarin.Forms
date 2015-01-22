using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xuni.Xamarin.Gauge;

namespace GaugeDemo
{
    public partial class CustomAnimation
    {
        private SampleViewModel model;

        public CustomAnimation()
        {
            InitializeComponent();
            model = new SampleViewModel() { Value = 60, ShowText = GaugeShowText.None, ShowRanges = false };
            BindingContext = model;

            radialGauge.Pointer.Thickness = 0.5;
            linearGauge.Pointer.Thickness = 0.5;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            model.ValueSelectedIndex = 60;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AnimateNextStep();
        }

        private Random _rand = new Random();
        private async Task AnimateNextStep()
        {
            double nextValue = _rand.Next(0, 100);
            var linearGaugeAnimation = new Animation(d => linearGauge.Value = d, linearGauge.Value, nextValue, Easing.CubicInOut);
            this.Animate("LinearGaugeAnimation", linearGaugeAnimation, rate: 60, length: 2000, finished: (d2, b) => { }, repeat: () => false);
            var radialGaugeAnimation = new Animation(d => radialGauge.Value = d, radialGauge.Value, nextValue, Easing.CubicInOut);
            this.Animate("RadialGaugeAnimation", radialGaugeAnimation, rate: 60, length: 2000, finished: (d2, b) => AnimateNextStep(), repeat: () => false);
        }
    }
}
