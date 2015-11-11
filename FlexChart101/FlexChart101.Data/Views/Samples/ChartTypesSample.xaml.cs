using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexChartDemo.Data.Model;
using Xamarin.Forms;
using Xuni.Forms.FlexChart;
using FlexChartDemo.Data.Resources;

namespace FlexChartDemo.Data.Views.Samples
{
    public partial class ChartTypesSample
    {
        public ChartTypesSample()
        {
            InitializeComponent();
            Title = AppResources.BasicChartTypesTitle;
            
            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();

            foreach (var item in ChartSampleFactory.GetBasicChartTypes())
            {
                this.pickerChartType.Items.Add(item.ToString());
            }
            foreach (var item in Enum.GetNames(typeof(ChartStackingType)))
            {
                this.pickerStackType.Items.Add(item);
            }
            this.pickerChartType.SelectedIndex = 5;
            this.pickerStackType.SelectedIndex = 1;
            this.flexChart.ZoomMode = ChartZoomMode.XY;
        }

        void pickerChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
           this.flexChart.ChartType = (ChartType)Enum.Parse(typeof(ChartType), this.pickerChartType.Items[this.pickerChartType.SelectedIndex]);
        }

        void pickerStackType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChartStackingType stacking=(ChartStackingType)Enum.Parse(typeof(ChartStackingType), this.pickerStackType.Items[this.pickerStackType.SelectedIndex]);
            this.flexChart.Stacking = stacking;
            this.flexChart.AxisY.Format = stacking == ChartStackingType.Stacked100pc ? "F2" : string.Empty;
        }      
    }
}
