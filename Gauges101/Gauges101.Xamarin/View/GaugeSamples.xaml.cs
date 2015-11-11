using Gauges101.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Gauges101
{
    public partial class GaugeSamples : ContentPage
    {
        public GaugeSamples()
        {
            InitializeComponent();

            Title = "Gauges101";

            BindingContext = GetSamples();
        }

        private List<Sample> GetSamples()
        {
            return new List<Sample>
            {
                new Sample() { Name = AppResources.GettingStartedTitle, Description = AppResources.GettingStartedDescription, SampleViewType = 1 , Thumbnail="gauge_basic.png"},
                new Sample() { Name = AppResources.DisplayingValuesTitle, Description = AppResources.DisplayingValuesDescription, SampleViewType = 2 , Thumbnail="gauge_radial.png"},
                new Sample() { Name = AppResources.UsingRangesTitle, Description = AppResources.UsingRangesDescription, SampleViewType = 3 , Thumbnail="gauge_ranges.png"},
                new Sample() { Name = AppResources.AutomaticScalingTitle, Description = AppResources.AutomaticScalingDescription, SampleViewType = 4 , Thumbnail="gauge_scaling.png"},
                new Sample() { Name = AppResources.DirectionTitle, Description = AppResources.DirectionDescription, SampleViewType = 5 , Thumbnail="gauge_linear.png"},
                new Sample() { Name = AppResources.BulletGraphTitle, Description = AppResources.BulletGraphDescription, SampleViewType = 6 , Thumbnail="gauge_bullet.png"},
                new Sample() { Name = AppResources.AnimationTitle, Description = AppResources.AnimationDescription, SampleViewType = 7 , Thumbnail="gauge_basic.png"},
                new Sample() { Name = AppResources.ExportImageTitle, Description = AppResources.ExportImageDescription, SampleViewType = 8 , Thumbnail="gauge_basic.png"},
            };
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var sample = e.Item as Sample;
            await this.Navigation.PushAsync(GetSample(sample.SampleViewType));
        }

        private Page GetSample(int sampleViewType)
        {
            switch (sampleViewType)
            {
                case 1: return new GettingStarted();
                case 2: return new DisplayingValues();
                case 3: return new UsingRanges();
                case 4: return new AutomaticScaling();
                case 5: return new Direction();
                case 6: return new BulletGraph();
                case 7: return new CustomAnimation();
                case 8: return new Snapshot();
            }
            return null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (listView != null)
            {
                listView.SelectedItem = null;
            }
        }
    }
}
