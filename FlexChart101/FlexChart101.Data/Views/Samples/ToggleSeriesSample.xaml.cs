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
    public partial class ToggleSeriesSample
    {
        public ToggleSeriesSample()
        {
            InitializeComponent();
            Title = AppResources.ToggleSeriesTitle;

            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
            this.flexChart.Palette = Xuni.Forms.ChartCore.ChartPalettes.Darkly;
            this.flexChart.AxisX.Format = "M/dd";
            this.flexChart.LegendToggle = true;
        }
    }
    public class SeriesVisibilityBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ChartSeriesVisibilityType visible = (ChartSeriesVisibilityType)value;
            return visible != ChartSeriesVisibilityType.Hidden;
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            return val ? ChartSeriesVisibilityType.Visible : ChartSeriesVisibilityType.Hidden;
        }
    }

}
