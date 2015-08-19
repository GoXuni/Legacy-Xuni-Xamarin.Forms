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
    public partial class BubbleChartSample
    {
        public BubbleChartSample()
        {
            InitializeComponent();
            
            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
            this.flexChart.LoadAnimation.AnimationMode = Xuni.Forms.ChartCore.Enums.AnimationMode.Series;
        }
    }
}
