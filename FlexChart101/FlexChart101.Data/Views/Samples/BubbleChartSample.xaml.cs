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
    public partial class BubbleChartSample
    {
        public BubbleChartSample()
        {
            InitializeComponent();
            Title = AppResources.BubbleChartTitle;

            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
            this.flexChart.LoadAnimation.AnimationMode = Xuni.Forms.ChartCore.ChartAnimationMode.Series;
        }
    }
}
