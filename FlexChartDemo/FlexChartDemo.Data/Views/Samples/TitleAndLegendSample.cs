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
    public class TitleAndLegendSample : BaseSample
    {
        public TitleAndLegendSample(ChartSample chartSample)
            : base()
        {
            FlexChart chart = ChartSampleFactory.GetFlexChartSample(chartSample);

            chart.HeaderText = "Sample Chart";
            chart.HeaderTextColor = Color.FromHex("#80044d");
            chart.HeaderFont = Font.SystemFontOfSize(30);
            chart.HeaderXAlign = TextAlignment.Center;

            chart.FooterText = "2014 GrapeCity, Inc.";
            chart.FooterTextColor = Color.FromHex("#80044d");
            chart.FooterFont = Font.SystemFontOfSize(14);
            chart.FooterXAlign = TextAlignment.Center;

            chart.AxisX.TitleText = "Amount";
            chart.AxisX.TitleFont = Font.SystemFontOfSize(14, FontAttributes.Bold | FontAttributes.Italic);

            chart.AxisY.TitleText = "Country";
            chart.AxisY.TitleFont = Font.SystemFontOfSize(14, FontAttributes.Bold | FontAttributes.Italic);

            Content = chart;
        }
    }
}
