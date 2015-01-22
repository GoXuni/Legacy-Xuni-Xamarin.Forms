using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;

using Xuni.Xamarin.FlexChart;

using FlexChartDemo.Data.Chart;

namespace FlexChartDemo.Data.Views.Samples
{
    public class MixedChartTypesSample : BaseSample
    {
        public MixedChartTypesSample(ChartSample chartSample)
            : base()
        {
            FlexChart chart = ChartSampleFactory.GetFlexChartSample(chartSample);

            IEnumerable<ChartSeries> seriesList = chart.Series;

            seriesList.ToArray()[2].ChartType = Xuni.Xamarin.FlexChart.ChartType.Line;

            Content = chart;
        }
    }
}
