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
    public class GettingStartedSample : BaseSample
    {
        FlexChart chart;

        public GettingStartedSample(ChartSample chartSample) : base()
        {
            chart = ChartSampleFactory.GetFlexChartSample(chartSample);

            Content = chart;
        }
    }
}
