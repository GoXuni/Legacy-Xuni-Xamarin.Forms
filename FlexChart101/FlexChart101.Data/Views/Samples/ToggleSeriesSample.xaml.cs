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
    public partial class ToggleSeriesSample
    {
        public ToggleSeriesSample()
        {
            InitializeComponent();
            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
            //foreach (var item in Enum.GetNames(typeof(ChartType)))
            //{
            //     this.pickerChartType.Items.Add(item);
            //}
            //foreach (var item in Enum.GetNames(typeof(ChartSelectionModeType)))
            //{
            //    this.pickerSelectionMode.Items.Add(item);
            //}
            //this.pickerChartType.SelectedIndex = 0;
            //this.pickerSelectionMode.SelectedIndex = 0;
        }

        //void pickerChartType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    this.flexChart.ChartType = (ChartType)Enum.Parse(typeof(ChartType), this.pickerChartType.Items[this.pickerChartType.SelectedIndex]);
        //}

        //void pickerSelectionMode_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    this.flexChart.SelectionMode = (ChartSelectionModeType)Enum.Parse(typeof(ChartSelectionModeType), this.pickerSelectionMode.Items[this.pickerSelectionMode.SelectedIndex]);
        //}      
    }
    public class SeriesVisibilityBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ChartSeriesVisibilityType visible = (ChartSeriesVisibilityType)value;
            return visible == ChartSeriesVisibilityType.Visible;
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            return val ? ChartSeriesVisibilityType.Visible : ChartSeriesVisibilityType.Hidden;
        }
    }

}
