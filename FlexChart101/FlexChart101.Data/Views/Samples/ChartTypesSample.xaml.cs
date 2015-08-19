using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexChartDemo.Data.Model;
using Xamarin.Forms;
using Xuni.Forms.FlexChart;

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
            this.pickerChartType.Items.Add(ChartType.LineSymbols.ToString());
            this.pickerChartType.Items.Add(ChartType.Area.ToString());
            this.pickerChartType.Items.Add(ChartType.Spline.ToString());
            this.pickerChartType.Items.Add(ChartType.SplineSymbols.ToString());
            this.pickerChartType.Items.Add(ChartType.SplineArea.ToString());
            foreach (var item in Enum.GetNames(typeof(ChartStackingType)))
            {
                this.pickerStackType.Items.Add(item);
            }
            this.pickerChartType.SelectedIndex = 5;
            this.pickerStackType.SelectedIndex = 1;
            this.flexChart.ZoomMode = ZoomMode.XY;
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
