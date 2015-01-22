using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexChartDemo.Data.Chart;
using Xuni.Xamarin.FlexChart;

namespace FlexChartDemo.Data.Views.Samples
{
    public class FinancialChart : BaseSample
    {
        public FinancialChart(ChartSample chartSample)
        {
            FlexChart chart = ChartSampleFactory.GetFlexChartSample(chartSample);
            Content = chart;
        }
    }
}
