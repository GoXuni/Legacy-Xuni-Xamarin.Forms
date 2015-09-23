using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexChartDemo.Data.Model;
using Xamarin.Forms;
using FlexChartDemo.Data.Resources;

namespace FlexChartDemo.Data.Views.Samples
{
    public partial class TooltipsSample : ContentPage
    {
        public TooltipsSample()
        {
            InitializeComponent();
            Title = AppResources.CustomTooltipsTitle;

            this.chart.ItemsSource = ChartSampleFactory.CreateEntityList();
            this.chart.Palette = Xuni.Forms.ChartCore.ChartPalettes.Zen;
            this.chart.LoadAnimation.AnimationMode = Xuni.Forms.ChartCore.ChartAnimationMode.Series;
            this.chart.AxisX.MinorTickWidth = 1;
            this.chart.AxisX.MajorTickWidth = 0;
            this.chart.AxisX.LabelFontSize = 16;
            this.chart.AxisY.MajorTickWidth = 0;
            this.chart.AxisY.MajorUnit = 2000;
            this.chart.AxisY.AxisLineVisible = false;
            this.chart.AxisY.LabelFontSize = 16;
        }
    }
}
