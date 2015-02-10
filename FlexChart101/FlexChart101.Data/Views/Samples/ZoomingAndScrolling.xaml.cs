using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexChartDemo.Data.Chart;
using Xamarin.Forms;
using Xuni.Xamarin.ChartCore;
using Xuni.Xamarin.FlexChart;

namespace FlexChartDemo.Data.Views.Samples
{
    public partial class ZoomingAndScrolling
    {
        public ZoomingAndScrolling()
        {
            InitializeComponent();
            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
            foreach (var item in Enum.GetNames(typeof(ZoomMode)))
            {
                this.pickerZoomMode.Items.Add(item);
            }
            this.pickerZoomMode.SelectedIndex = 2;
        }

        void pickerZoomMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexChart.ZoomMode = (ZoomMode)Enum.Parse(typeof(ZoomMode), this.pickerZoomMode.Items[this.pickerZoomMode.SelectedIndex]);
        }
    }
}
