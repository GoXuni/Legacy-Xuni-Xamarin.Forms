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

            int len = 40;
            List<Point> listCosTuple = new List<Point>();
            List<Point> listSinTuple = new List<Point>();

            for (int i = 0; i < len; i++)
            {
                listCosTuple.Add(new Point(i, Math.Cos(0.12 * i)));
                listSinTuple.Add(new Point(i, Math.Sin(0.12 * i)));
            }
            this.seriesCosX.ItemsSource = listCosTuple;
            this.seriesSinX.ItemsSource = listSinTuple;
        }

        void flexChart_Tapped(object sender, Xuni.Xamarin.Core.Events.XuniTappedEventArgs e)
        {
            FlexChartHitTestInfo hitTest = this.flexChart.HitTest(e.HitPoint);
            this.stackHitTest.BindingContext = hitTest;
            this.stackSeries.IsVisible = hitTest.Series != null;
            this.stackData.IsVisible = hitTest.PointIndex != -1;
        }
    }
}
