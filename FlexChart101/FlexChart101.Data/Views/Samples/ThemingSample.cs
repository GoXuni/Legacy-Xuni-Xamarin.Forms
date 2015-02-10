using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;
using Xamarin;
using Xamarin.Forms;

using Xuni.Xamarin.FlexChart;

using FlexChartDemo.Data.Chart;
using Xuni.Xamarin.ChartCore;

namespace FlexChartDemo.Data.Views.Samples
{
    public class ThemingSample : BaseSample
    {
        FlexChart chart;
        public ThemingSample(ChartSample chartSample)
            : base()
        {
            StackLayout grid = new StackLayout() { VerticalOptions = LayoutOptions.FillAndExpand };
            Picker picker = this.CreatePalettesPicker();
            picker.VerticalOptions = LayoutOptions.Start;
            grid.Children.Add(picker);            
            chart = ChartSampleFactory.GetFlexChartSample(chartSample);
            grid.Children.Add(chart);
            chart.VerticalOptions = LayoutOptions.FillAndExpand;
            picker.SelectedIndex = 0;
            Content = grid;
        }
        Picker CreatePalettesPicker()
        {
            IEnumerable<FieldInfo> fields = typeof(Palettes).GetRuntimeFields();
            Picker picker = new Picker();
            picker.VerticalOptions = LayoutOptions.CenterAndExpand;
            picker.HorizontalOptions = LayoutOptions.FillAndExpand;
            picker.Title = "Palettes";
            foreach (var item in fields)
            {
                picker.Items.Add(item.Name);
            }
            picker.SelectedIndexChanged += picker_SelectedIndexChanged;
            return picker;
        }

        void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker= sender as Picker;
            string fieldName = picker.Items[picker.SelectedIndex];
            foreach (var field in typeof(Palettes).GetRuntimeFields())
            {
                if(field.Name==fieldName)
                {
                    this.chart.Palette = field.GetValue(null) as Color[];
                }
            }
        }
    }
}
