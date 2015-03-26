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
    public partial class DataLabelSample
    {
        public DataLabelSample()
        {
            InitializeComponent();
            
            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
            foreach (var item in Enum.GetNames(typeof(ChartLabelPosition)))
            {
                this.pickPostion.Items.Add(item);
            }
            this.pickPostion.SelectedIndex = 3;
        }

        void pickPostion_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexChart.DataLabel.Position = (ChartLabelPosition)Enum.Parse(typeof(ChartLabelPosition), this.pickPostion.Items[this.pickPostion.SelectedIndex]);
        }
          
    }
}
