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
    public class CustomizingAxesSample : BaseSample
    {
        public CustomizingAxesSample(ChartSample chartSample)
            : base()
        {
            FlexChart chart = ChartSampleFactory.GetFlexChartSample(chartSample);

            chart.AxisY.LineWidth = 2;
            chart.AxisY.MajorTickWidth = 0;
            chart.AxisY.MajorGridColor = Color.FromHex("#C4C4C4");
            chart.AxisY.AxisLineVisible = true;
            chart.AxisY.MinorTickWidth = 1;
            chart.AxisY.Format = "c0";
            chart.AxisY.Max = 10000;
            chart.AxisY.MajorUnit = 2000;

            chart.AxisX.MajorTickWidth = 1;
            chart.AxisX.LineColor = Color.FromHex("#C4C4C4");
            chart.AxisX.MajorGridColor = Color.FromHex("#C4C4C4");
            chart.AxisX.MajorTickColor = Color.FromHex("#C4C4C4");



        Content = chart;
        }
    }
}
