using FlexPieDemo.Data.Resources;
using FlexPieDemo.Data.Views.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlexPieDemo.Data
{
    public partial class FlexPieSamples : ContentPage
    {
        public FlexPieSamples()
        {
            InitializeComponent();
            BindingContext = GetSamples();
        }

        private List<Sample> GetSamples()
        {
            return new List<Sample>
            {
                new Sample() { Name = AppResources.GettingStartedTitle, Description = AppResources.GettingStartedDescription, SampleViewType = 1 , Thumbnail="pie.png"},
                new Sample() { Name = AppResources.BasicFeaturesTitle, Description = AppResources.BasicFeaturesDescription, SampleViewType = 2 , Thumbnail="pie_doughnut.png"},
                new Sample() { Name = AppResources.LegendSampleTitle, Description = AppResources.LegendSampleDescription, SampleViewType = 3 , Thumbnail="pie_title.png"},
                new Sample() { Name = AppResources.SelectionTitle, Description = AppResources.SelectionDescription, SampleViewType = 4 , Thumbnail="pie_selection.png"},
                new Sample() { Name = AppResources.CustomTooltipsTitle, Description = AppResources.CustomTooltipsDescription, SampleViewType = 5 , Thumbnail="pie.png"},
                new Sample() { Name = AppResources.DataLabelsTitle, Description = AppResources.DataLabelsDescription, SampleViewType = 6 , Thumbnail="pie_labels.png"},
                new Sample() { Name = AppResources.AnimationTitle, Description = AppResources.AnimationDescription, SampleViewType = 7 , Thumbnail="pie_load.png"},
                new Sample() { Name = AppResources.ThemingTitle, Description = AppResources.ThemingDescription, SampleViewType = 8 , Thumbnail="themes.png"},
                new Sample() { Name = AppResources.ExportImageTitle, Description = AppResources.ExportImageDescription, SampleViewType = 9 , Thumbnail="pie.png"},
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
                case 1: return new GettingStartedSample();
                case 2: return new BasicFeaturesSample();
                case 3: return new LegendAndTitlesSample();
                case 4: return new SelectionSample();
                case 5: return new TooltipsSample();
                case 6: return new DataLabel();
                case 7: return new AnimationSample();
                case 8: return new ThemingSample();
                case 9: return new Snapshot();
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
