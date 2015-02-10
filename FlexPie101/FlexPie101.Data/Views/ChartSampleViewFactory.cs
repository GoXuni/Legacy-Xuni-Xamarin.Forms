using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using FlexPieDemo.Data.Chart;
using FlexPieDemo.Data.Views.Samples;

namespace FlexPieDemo.Data.Views
{
    public static class ChartSampleViewFactory
    {
        public static ContentPage GetChartContentPage(PieChartSample chartSample)
        {
            ContentPage page = null;

            switch (chartSample.PieChartSampleViewType)
            {
                case (int)PieChartSampleViewType.GETTING_STARTED:
                    page = new GettingStartedSample(chartSample);
                    break;
                case (int)PieChartSampleViewType.BASIC_FEATURES:
                    page = new BasicFeaturesSample();
                    break;
                case (int)PieChartSampleViewType.LEGEND_AND_TITLES:
                    page = new LegendAndTitlesSample();
                    break;
                case (int)PieChartSampleViewType.SELECTION:
                    page = new SelectionSample();
                    break;
                case (int)PieChartSampleViewType.THEMING:
                    page = new ThemingSample(chartSample);
                    break;
            }

            page.Title = chartSample.Name;

            return page;
        }
    }
}
