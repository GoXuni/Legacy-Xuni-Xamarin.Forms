using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexChartDemo.Data.Model;
using Xamarin.Forms;
using Xuni.Forms.ChartCore;
using Xuni.Forms.FlexChart;
using FlexChartDemo.Data.Resources;

namespace FlexChartDemo.Data.Views.Samples
{
    public partial class ZoomingAndScrolling
    {
        Random rnd = new Random();
        public ZoomingAndScrolling()
        {
            InitializeComponent();
            Title = AppResources.ZoomingScrollingTitle;

            this.flexChart.ItemsSource = GenerateRandNormal(500);
            this.flexChart.Palette = Xuni.Forms.ChartCore.ChartPalettes.Superhero;
            this.flexChart.HeaderText = AppResources.ScrollZoomInstructions;
            this.flexChart.AxisY.Format = "n2";
            
            //disable tooltip on android
            Device.OnPlatform(Android: () => this.flexChart.Tooltip = null);
            
            foreach (var item in Enum.GetNames(typeof(ChartZoomMode)))
            {
                this.pickerZoomMode.Items.Add(item);
            }
            this.pickerZoomMode.SelectedIndex = 2;
        }

        // generates normally distributed random numbers
        List<Point> GenerateRandNormal(int n)
        {
            if (n % 2 == 1)
                n++;

            List<Point> points = new List<Point>(n);

            for (int i = 0; i < n / 2; i++)
            {
                do
                {
                    double u = 2 * rnd.NextDouble() - 1;
                    double v = 2 * rnd.NextDouble() - 1;

                    double s = u * u + v * v;

                    if (s < 1)
                    {
                        s = Math.Sqrt(-2 * Math.Log(s) / s);
                        points.Add(new Point(i, u * s));
                        points.Add(new Point(i + 1, v * s));
                        break;
                    }
                } while (true);
            }

            return points;
        }


        void pickerZoomMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexChart.ZoomMode = (ChartZoomMode)Enum.Parse(typeof(ChartZoomMode), this.pickerZoomMode.Items[this.pickerZoomMode.SelectedIndex]);
        }
    }
}
