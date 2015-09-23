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
    public partial class TitleAndLegendSample
    {
        public TitleAndLegendSample()
        {
            InitializeComponent();
            Title = AppResources.LegendSampleTitle;

            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
        }
    }
}
