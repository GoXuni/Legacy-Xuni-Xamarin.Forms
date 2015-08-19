using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexChartDemo.Data.Model;
using Xamarin.Forms;

namespace FlexChartDemo.Data.Views.Samples
{
    public partial class TooltipsSample : ContentPage
    {
        public TooltipsSample()
        {
            InitializeComponent();
            
            this.chart.ItemsSource = ChartSampleFactory.CreateEntityList();
            this.chart.Palette = Xuni.Forms.ChartCore.Palettes.Zen;
            this.chart.LoadAnimation.AnimationMode = Xuni.Forms.ChartCore.Enums.AnimationMode.Series;
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
