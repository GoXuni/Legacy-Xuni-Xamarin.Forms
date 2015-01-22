using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin;
using Xamarin.Forms;

using Xuni.Xamarin.FlexChart;

using FlexChartDemo.Data.Chart;

namespace FlexChartDemo.Data.Views.Samples
{
    public class DynamicChartsSample : BaseSample
    {
        List<DummyObject> list = new List<DummyObject>();

        FlexChart chart;

        public DynamicChartsSample(ChartSample chartSample)
            : base()
        {
            chart = new FlexChart();

            chart.BindingX = "Name";



			chart.ChartType = Xuni.Xamarin.FlexChart.ChartType.Area;

            //bug on android, path rendering cant happen with hardware acceleration on
            Device.OnPlatform(Android: () => chart.ChartType = Xuni.Xamarin.FlexChart.ChartType.Line);

            chart.Series.Add(new ChartSeries(chart, "Trucks", "Trucks"));
            chart.Series.Add(new ChartSeries(chart, "Ships", "Ships"));
            chart.Series.Add(new ChartSeries(chart, "Planes", "Planes"));

            
            

            list.Add(getItem());
            list.Add(getItem());
            list.Add(getItem());
            list.Add(getItem());
            list.Add(getItem());
            list.Add(getItem());
            list.Add(getItem());
            list.Add(getItem());

            chart.ItemsSource = list;

            Content = chart;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.StartTimer(TimeSpan.FromSeconds(Device.OnPlatform<Double>(1.0,2.0,1.0)), () =>
            {
				list.RemoveAt(0);
				list.Add(getItem());
                chart.ItemsSource = list.ToArray();

                return true;
            });
        }

        public DummyObject getItem()
        {
            Random random = new Random();

            double nextDouble = random.Next(0, 1000);

            while(nextDouble < 900)
            {
                nextDouble = random.Next(0, 1000);
            }

            double trucks = nextDouble + 20;
            double ships = nextDouble + 10;
            double planes = nextDouble;

            DateTime now = DateTime.Now;

            return new DummyObject(now.ToString("mm:ss"), trucks, ships, planes);
        }

        public class DummyObject
        {
            public String Name { get; set; }

            public double Trucks { get; set; }

            public double Ships { get; set; }

            public double Planes { get; set; }

            public DummyObject(String name, double trucks, double ships, double planes)
            {
                this.Name = name;
                this.Trucks = trucks;
                this.Ships = ships;
                this.Planes = planes;
            }

        }
    }
}
