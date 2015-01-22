using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin;
using Xamarin.Forms;

using Xuni.Xamarin.FlexChart;

using FlexChartDemo.Data.Chart;
using FlexChartDemo.Data.Views.Common;

namespace FlexChartDemo.Data.Views.Samples
{
    public class TooltipsSample : BaseSample
    {
        public TooltipsSample(ChartSample chartSample)
            : base()
        {
            FlexChart chart = ChartSampleFactory.GetFlexChartSample(chartSample);

            chart.ChartTooltip.Content = CountryRenderChartTooltip.GetCountryRenderChartTooltip(chart);

            Content = chart;
        }
    }
}
