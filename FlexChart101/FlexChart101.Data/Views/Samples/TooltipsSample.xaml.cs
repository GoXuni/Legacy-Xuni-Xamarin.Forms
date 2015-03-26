using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexChartDemo.Data.Chart;
using Xamarin.Forms;

namespace FlexChartDemo.Data.Views.Samples
{
    public partial class TooltipsSample : ContentPage
    {
        public TooltipsSample()
        {
            InitializeComponent();
            
            this.chart.ItemsSource = ChartSampleFactory.CreateEntityList();
        }
    }
}
