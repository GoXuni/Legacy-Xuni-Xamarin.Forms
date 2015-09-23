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
    public partial class MixedChartTypesSample
    {
        public MixedChartTypesSample()
        {
            InitializeComponent();
            Title = AppResources.MixedChartTypesTitle;

            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();

            this.flexChart.AxisX.LabelAngle = 45;
            this.flexChart.AxisX.MinorTickWidth = 1;
            this.flexChart.AxisX.MajorTickWidth = 0;
        }
    }
}
