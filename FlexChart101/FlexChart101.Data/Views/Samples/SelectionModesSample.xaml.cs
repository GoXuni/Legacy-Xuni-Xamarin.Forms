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
    public partial class SelectionModesSample
    {
        public SelectionModesSample()
        {
            InitializeComponent();
            FlexChartDemo.Data.Views.Common.Utility.CheckNavBar(this);
            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
            this.pickerChartType.Items.Add(ChartType.Column.ToString());
            this.pickerChartType.Items.Add(ChartType.Bar.ToString());
            this.pickerChartType.Items.Add(ChartType.Scatter.ToString());
            this.pickerChartType.Items.Add(ChartType.Line.ToString());
            this.pickerChartType.Items.Add(ChartType.LineSymbol.ToString());
            this.pickerChartType.Items.Add(ChartType.Area.ToString());
            this.pickerChartType.Items.Add(ChartType.Column.ToString());
            foreach (var item in Enum.GetNames(typeof(ChartSelectionModeType)))
            {
                this.pickerSelectionMode.Items.Add(item);
            }
            this.pickerChartType.SelectedIndex = 0;
			this.pickerSelectionMode.SelectedIndex = 1;
        }

        void pickerChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexChart.ChartType = (ChartType)Enum.Parse(typeof(ChartType), this.pickerChartType.Items[this.pickerChartType.SelectedIndex]);
        }

        void pickerSelectionMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexChart.SelectionMode = (ChartSelectionModeType)Enum.Parse(typeof(ChartSelectionModeType), this.pickerSelectionMode.Items[this.pickerSelectionMode.SelectedIndex]);
        }      
    }
}
