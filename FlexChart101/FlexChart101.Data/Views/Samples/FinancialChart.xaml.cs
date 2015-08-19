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
    public partial class FinancialChart
    {
        public FinancialChart()
        {
            InitializeComponent();
            this.flexChart.ItemsSource = ChartSampleFactory.FinancialData();
            this.flexChart.ChartType = ChartType.Candle;
            this.flexChart.Legend.Position = Xuni.Forms.ChartCore.ChartPositionType.None;
            this.flexChart.AxisY.MajorGridFill = Color.FromRgba(50, 50, 50, 20);
            this.flexChart.AxisX.Format = "yyyy/MM/dd";
            this.pickerChartType.Items.Add(ChartType.Candle.ToString());
            this.pickerChartType.Items.Add(ChartType.Hloc.ToString());
            this.pickerChartType.SelectedIndex = 0;
        }

        void pickerChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexChart.ChartType = (ChartType)Enum.Parse(typeof(ChartType), this.pickerChartType.Items[this.pickerChartType.SelectedIndex]);
        }
    }
}
