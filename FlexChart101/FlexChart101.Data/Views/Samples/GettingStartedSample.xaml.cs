using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexChartDemo.Data.Model;
using Xamarin.Forms;
using Xuni.Forms.FlexChart;

namespace FlexChartDemo.Data.Views.Samples
{
    public partial class GettingStartedSample
    {
        public GettingStartedSample()
        {
            InitializeComponent();
            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();

            this.flexChart.AxisX.MinorTickWidth = 1;
            this.flexChart.AxisX.MajorTickWidth = 0;

			this.flexChart.Tooltip.Threshold = 50;
        }


    }
}
