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

namespace FlexChartDemo.Data.Views.Samples
{
    public class StylingSeriesSample : BaseSample
    {
        public StylingSeriesSample(ChartSample chartSample)
            : base()
        {
            FlexChart chart = ChartSampleFactory.GetFlexChartSample(chartSample);

            IEnumerable<ChartSeries> seriesList = chart.Series;

            ChartSeries[] seriesArray = chart.Series.ToArray();

            seriesArray[0].Color = Color.Green;
            seriesArray[0].BorderColor = Color.Lime;
            seriesArray[0].BorderWidth = 2;

            seriesArray[1].Color = Color.Red;
            seriesArray[1].BorderColor = Color.Maroon;
            seriesArray[1].BorderWidth = 2;

            seriesArray[2].ChartType = Xuni.Xamarin.FlexChart.ChartType.LineSymbol;
            seriesArray[2].Color = Color.FromHex("#FF6A00");
            seriesArray[2].BorderWidth = 10;
            seriesArray[2].SymbolColor = Color.Yellow;
            seriesArray[2].SymbolBorderColor = Color.Yellow;
            seriesArray[2].SymbolBorderWidth = 5;

            Content = chart;
        }
    }
}
