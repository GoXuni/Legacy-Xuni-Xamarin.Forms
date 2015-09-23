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
    public partial class CustomizingAxesSample
    {
        public CustomizingAxesSample()
        {
            InitializeComponent();
            Title = AppResources.CustomizingAxesTitle;

            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
            this.flexChart.Legend.Position = Xuni.Forms.ChartCore.ChartPositionType.Top;
            this.flexChart.Legend.Orientation = Xuni.Forms.ChartCore.ChartLegendOrientation.Horizontal;
            this.flexChart.SizeChanged += flexChart_SizeChanged;
        }

        void flexChart_SizeChanged(object sender, EventArgs e)
        {
            if(this.flexChart.Width > this.flexChart.Height)
            {
                this.flexChart.AxisX.LabelAngle = 0;
                this.flexChart.AxisY.LabelAngle = 0;
            }
            else
            {
                this.flexChart.AxisX.LabelAngle = 90;
                this.flexChart.AxisY.LabelAngle = 90;
            }
            //this.flexChart.Refresh();
        }
    }
}
