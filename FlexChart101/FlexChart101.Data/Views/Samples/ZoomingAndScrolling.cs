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
    public class ZoomingAndScrolling : BaseSample
    {
        FlexChart chart;

        public ZoomingAndScrolling(ChartSample chartSample)
        {
            StackLayout grid = new StackLayout() { VerticalOptions = LayoutOptions.FillAndExpand };
            StackLayout stackMode = new StackLayout() { Orientation = StackOrientation.Horizontal };
            stackMode.Children.Add(new Label() { Text = "Zoom Mode", HorizontalOptions = LayoutOptions.Start,VerticalOptions=LayoutOptions.Center });
            Picker picker = this.CreateZoomModePicker();
            picker.VerticalOptions = LayoutOptions.Start;
            stackMode.Children.Add(picker);

            chart = ChartSampleFactory.GetFlexChartSample(chartSample);
            chart.ZoomMode = ZoomMode.XY;
            chart.ChartType = ChartType.Area;
            chart.Stacking = ChartStackingType.Stacked;

            grid.Children.Add(stackMode);
            grid.Children.Add(chart);
            chart.VerticalOptions = LayoutOptions.FillAndExpand;
            picker.SelectedIndex = 0;
            Content = grid;

            chart.AxisX.Scale = 0.5;
			chart.AxisY.DisplayedRange = 16000;

            chart.ChartTooltip.ShowTooltip = false;

        }
        Picker CreateZoomModePicker()
        {
            Picker picker = new Picker();
            picker.VerticalOptions = LayoutOptions.CenterAndExpand;
            picker.HorizontalOptions = LayoutOptions.FillAndExpand;
            picker.Title = "ZoomMode";
            picker.Items.Add("X");
            picker.Items.Add("Y");
            picker.Items.Add("XY");
            picker.SelectedIndexChanged += picker_SelectedIndexChanged;
            return picker;
        }

        void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Picker picker=sender as Picker;
            if (picker.SelectedIndex < 0) return;
            string str = picker.Items[picker.SelectedIndex];
            switch (str)
            {
                case "X":
                    //chart.AxisY.MinScale = 1;
                    //chart.AxisY.Scale = 1;
                    //chart.AxisY.Value = 0.5;
                    //chart.AxisX.MinScale = 0.001;
                    chart.ZoomMode = ZoomMode.X;
                    break;
                case "Y":
                    chart.ZoomMode = ZoomMode.Y;
                    break;
                default:
                    chart.ZoomMode = ZoomMode.XY;
                    break;
            }
        }
    }
}
