using FlexChartDemo.Data.Resources;
using FlexChartDemo.Data.Views.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlexChartDemo.Data
{
    public partial class FlexChartSamples : ContentPage
    {
        public FlexChartSamples()
        {
            InitializeComponent();
            BindingContext = GetSamples();
        }

        private List<Sample> GetSamples()
        {
            return new List<Sample>
            {
                new Sample() { Name = AppResources.GettingStartedTitle, Description = AppResources.GettingStartedDescription, SampleViewType = 1 , Thumbnail="chart_column.png"},
                new Sample() { Name = AppResources.BasicChartTypesTitle, Description = AppResources.BasicChartTypesDescription, SampleViewType = 2 , Thumbnail="chart_area.png"},
                new Sample() { Name = AppResources.MixedChartTypesTitle, Description = AppResources.MixedChartTypesDescription, SampleViewType = 3 , Thumbnail="chart_composite.png"},
                new Sample() { Name = AppResources.FinancialChartTitle, Description = AppResources.FinancialChartDescription, SampleViewType = 4 , Thumbnail="chart_finance.png"},
                new Sample() { Name = AppResources.BubbleChartTitle, Description = AppResources.BubbleChartDescription, SampleViewType = 5 , Thumbnail="chart_bubble.png"},
                new Sample() { Name = AppResources.CustomTooltipsTitle, Description = AppResources.CustomTooltipsDescription, SampleViewType = 6 , Thumbnail="chart_tooltip.png"},
                new Sample() { Name = AppResources.DataLabelsTitle, Description = AppResources.DataLabelsDescription, SampleViewType = 7 , Thumbnail="chart_tooltip.png"},
                new Sample() { Name = AppResources.CustomizingAxesTitle, Description = AppResources.CustomizingAxesDescription, SampleViewType = 8 , Thumbnail="chart_axes.png"},
                new Sample() { Name = AppResources.MultipleAxesTitle, Description = AppResources.MultipleAxesDescription, SampleViewType = 9 , Thumbnail="chart_multiaxes.png"},
                new Sample() { Name = AppResources.LegendSampleTitle, Description = AppResources.LegendSampleDescription, SampleViewType = 10 , Thumbnail="chart_title.png"},
                new Sample() { Name = AppResources.ConditionalFormattingTitle, Description = AppResources.ConditionalFormattingDescription, SampleViewType = 11, Thumbnail="chart_format.png"},
                new Sample() { Name = AppResources.CustomPlotElementsTitle, Description = AppResources.CustomPlotElementsDescription, SampleViewType = 12, Thumbnail="custom.png"},
                new Sample() { Name = AppResources.SelectionModesTitle, Description = AppResources.SelectionModesDescription, SampleViewType = 13, Thumbnail="chart_selection.png"},
                new Sample() { Name = AppResources.ToggleSeriesTitle, Description = AppResources.ToggleSeriesDescription, SampleViewType = 14, Thumbnail="chart_column.png"},
                new Sample() { Name = AppResources.LoadAnimationTitle, Description = AppResources.LoadAnimationDescription, SampleViewType = 15, Thumbnail="chart_animation.png"},
                new Sample() { Name = AppResources.UpdateAnimationTitle, Description = AppResources.UpdateAnimationDescription, SampleViewType = 16, Thumbnail="chart_animation.png"},
                new Sample() { Name = AppResources.DynamicChartTitle, Description = AppResources.DynamicChartDescription, SampleViewType = 17, Thumbnail="chart_dynamic.png"},
                new Sample() { Name = AppResources.HitTestTitle, Description = AppResources.HitTestDescription, SampleViewType = 18, Thumbnail="chart_selection.png"},
                new Sample() { Name = AppResources.ScrollingTitle, Description = AppResources.ScrollingDescription, SampleViewType = 19, Thumbnail="chart_scrolling.png"},
                new Sample() { Name = AppResources.ZoomingScrollingTitle, Description = AppResources.ZoomingScrollingDescription, SampleViewType = 20, Thumbnail="chart_scatter.png"},
                new Sample() { Name = AppResources.ThemingTitle, Description = AppResources.ThemingDescription, SampleViewType = 21, Thumbnail="themes.png"},
                new Sample() { Name = AppResources.StylingSeriesTitle, Description = AppResources.StylingSeriesDescription, SampleViewType = 22, Thumbnail="chart_composite.png"},
                new Sample() { Name = AppResources.ExportImageTitle, Description = AppResources.ExportImageDescription, SampleViewType = 23, Thumbnail="export_image.png"},
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
                case 2: return new ChartTypesSample();
                case 3: return new MixedChartTypesSample();
                case 4: return new FinancialChart();
                case 5: return new BubbleChartSample();
                case 6: return new TooltipsSample();
                case 7: return new DataLabelSample();
                case 8: return new CustomizingAxesSample();
                case 9: return new MultipleAxesSamples();
                case 10: return new TitleAndLegendSample();
                case 11: return new ConditionalFormatting();
                case 12: return new CustomPlotElements();
                case 13: return new SelectionModesSample();
                case 14: return new ToggleSeriesSample();
                case 15: return new AnimationOptions();
                case 16: return new UpdateAnimation();
                case 17: return new DynamicChartsSample();
                case 18: return new HitTest();
                case 19: return new ScrollingSample();
                case 20: return new ZoomingAndScrolling();
                case 21: return new ThemingSample();
                case 22: return new StylingSeriesSample();
                case 23: return new Snapshot();
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
