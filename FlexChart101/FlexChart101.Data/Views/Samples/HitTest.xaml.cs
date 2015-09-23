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
    public partial class HitTest
    {
        public HitTest()
        {
            InitializeComponent();
            Title = AppResources.HitTestTitle;

            int len = 40;
            List<Point> listCosTuple = new List<Point>();
            List<Point> listSinTuple = new List<Point>();

            for (int i = 0; i < len; i++)
            {
                listCosTuple.Add(new Point(i, Math.Cos(0.12 * i)));
                listSinTuple.Add(new Point(i, Math.Sin(0.12 * i)));
            }

            this.flexChart.AxisY.Format = "n2";

            this.seriesCosX.ItemsSource = listCosTuple;
            this.seriesSinX.ItemsSource = listSinTuple;
        }

        void flexChart_Tapped(object sender, Xuni.Forms.Core.XuniTappedEventArgs e)
        {
            var hitTest = this.flexChart.HitTest(e.HitPoint);

            this.stackHitTest.BindingContext = hitTest;
            this.stackData.BindingContext = hitTest.DataPoint;

			this.stackSeries.IsVisible = hitTest.DataPoint != null && hitTest.DataPoint.SeriesIndex != -1;
			this.stackData.IsVisible = hitTest.DataPoint != null && hitTest.DataPoint.PointIndex != -1;
        }
    }
}
