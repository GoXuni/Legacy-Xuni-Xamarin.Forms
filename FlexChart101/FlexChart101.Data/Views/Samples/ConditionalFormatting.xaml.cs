using FlexChartDemo.Data.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xuni.Forms.FlexChart;

namespace FlexChartDemo.Data.Views.Samples
{
    public partial class ConditionalFormatting : ContentPage
    {
        public ConditionalFormatting()
        {
            InitializeComponent();
            Title = AppResources.ConditionalFormattingTitle;

            List<Point> listPoints = new List<Point>();
            for (int i = 0; i < 30; i++)
            {
                listPoints.Add(new Point(0.16 * i, Math.Cos(0.12 * i)));
            }
            this.flexChart2.ItemsSource = listPoints;
			this.flexChart2.AxisY.Format = "F1";
            this.flexChart2.AxisX.Format = "F1";
        }

        void OnPlotElementLoading(object sender, ChartPlotElementLoadingEventArgs e)
        {
            Point pnt;
            if (e.DataItem == null)
            {
                pnt = ((List<Point>)flexChart2.ItemsSource).ElementAt(e.PointIndex);
            }
            else
            {
                pnt = (Point)e.DataItem;
            }

            double y = pnt.Y;
            var r = (y >= 0 ? 1 : ((1 + y)));
            var b = (y < 0 ? 1 : ((1 - y)));
            var g = ((1 - Math.Abs(y)));
            var a = 0.8;
            e.PlotElement.Content.BackgroundColor = Color.FromRgba(r, g, b, a);
        }
    }
}
