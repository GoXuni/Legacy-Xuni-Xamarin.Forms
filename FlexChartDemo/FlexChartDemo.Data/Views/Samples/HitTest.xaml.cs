using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexChartDemo.Data.Chart;
using Xamarin.Forms;
using Xuni.Xamarin.FlexChart;

namespace FlexChartDemo.Data.Views.Samples
{
    public partial class HitTest
    {
        public HitTest()
        {
            InitializeComponent();
            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
        }

        void flexChart_Tapped(object sender, Xuni.Xamarin.Core.Events.XuniTappedEventArgs e)
        {
            FlexChartHitTestInfo hitTest = this.flexChart.HitTest(e.HitPoint);
            this.stackHitTest.BindingContext = hitTest;
            this.stackSeries.IsVisible = hitTest.Series != null;
        }
    }
}
