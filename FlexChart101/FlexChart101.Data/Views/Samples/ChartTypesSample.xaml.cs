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
    public partial class ChartTypesSample
    {
        public ChartTypesSample()
        {
            InitializeComponent();
            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();

            this.pickerChartType.Items.Add(ChartType.Column.ToString());
            this.pickerChartType.Items.Add(ChartType.Bar.ToString());
            this.pickerChartType.Items.Add(ChartType.Scatter.ToString());
            this.pickerChartType.Items.Add(ChartType.Line.ToString());
            this.pickerChartType.Items.Add(ChartType.LineSymbol.ToString());
            this.pickerChartType.Items.Add(ChartType.Area.ToString());
            foreach (var item in Enum.GetNames(typeof(ChartStackingType)))
            {
                this.pickerStackType.Items.Add(item);
            }
            this.pickerChartType.SelectedIndex = 0;
            this.pickerStackType.SelectedIndex = 0;
        }

        void pickerChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexChart.ChartType = (ChartType)Enum.Parse(typeof(ChartType), this.pickerChartType.Items[this.pickerChartType.SelectedIndex]);
        }

        void pickerStackType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexChart.Stacking = (ChartStackingType)Enum.Parse(typeof(ChartStackingType), this.pickerStackType.Items[this.pickerStackType.SelectedIndex]);
        }      
    }
}
