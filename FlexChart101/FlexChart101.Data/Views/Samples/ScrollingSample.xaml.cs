using FlexChartDemo.Data.Model;
using FlexChartDemo.Data.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlexChartDemo.Data.Views.Samples
{
    public partial class ScrollingSample : ContentPage
    {
        public ScrollingSample()
        {
            InitializeComponent();
            this.flexChart.ItemsSource = ChartSampleFactory.FinancialData();
            this.flexChart.Palette = Xuni.Forms.ChartCore.Palettes.Midnight;
            this.flexChart.HeaderText = AppResources.ScrollZoomInstructions;
        }
    }
}
