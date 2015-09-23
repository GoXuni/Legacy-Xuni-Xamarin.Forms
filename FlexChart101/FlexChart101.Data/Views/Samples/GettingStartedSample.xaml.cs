using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexChartDemo.Data.Model;
using Xamarin.Forms;
using Xuni.Forms.FlexChart;
using FlexChartDemo.Data.Resources;

namespace FlexChartDemo.Data.Views.Samples
{
    public partial class GettingStartedSample
    {
        public GettingStartedSample()
        {
            InitializeComponent();

            Title = AppResources.GettingStartedTitle;
            flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();

            flexChart.AxisX.MinorTickWidth = 1;
            flexChart.AxisX.MajorTickWidth = 0;

            flexChart.Tooltip.Threshold = 50;
        }
    }
}
