using Gauges101.Resources;
using System;
using Xamarin.Forms;
using Xuni.Forms.Gauge;

namespace Gauges101
{
    public partial class CustomAnimation : ContentPage
    {
        private SampleViewModel model;

        public CustomAnimation()
        {
            InitializeComponent();
            Title = AppResources.AnimationTitle;
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
        private void AnimateNextStep()
        {
            double nextValue = _rand.Next(0, 100);
            var linearGaugeAnimation = new Animation(d => linearGauge.Value = d, linearGauge.Value, nextValue, Easing.CubicInOut);
            this.Animate("LinearGaugeAnimation", linearGaugeAnimation, rate: 60, length: 2000, finished: (d2, b) => { }, repeat: () => false);
            var radialGaugeAnimation = new Animation(d => radialGauge.Value = d, radialGauge.Value, nextValue, Easing.CubicInOut);
            this.Animate("RadialGaugeAnimation", radialGaugeAnimation, rate: 60, length: 2000, finished: (d2, b) => AnimateNextStep(), repeat: () => false);
        }
    }
}
