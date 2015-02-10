using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexPieDemo.Data.Chart;
using Xamarin.Forms;
using Xuni.Xamarin.ChartCore;

namespace FlexPieDemo.Data.Views.Samples
{
    public partial class LegendAndTitlesSample
    {
        public LegendAndTitlesSample()
        {
            InitializeComponent();
            this.flexPie.ItemsSource = PieChartSampleFactory.CreateEntiyList();
            this.pickerLegendPosition.SelectedIndexChanged += pickerPosition_SelectedIndexChanged;
            
            foreach (var item in Enum.GetNames(typeof(ChartPositionType)))
            {
                this.pickerLegendPosition.Items.Add(item);
            }
            this.pickerLegendPosition.SelectedIndex = 4;
        }
        void pickerPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = this.pickerLegendPosition.Items[this.pickerLegendPosition.SelectedIndex];
            this.flexPie.Legend.Position = (ChartPositionType)(Enum.Parse(typeof(ChartPositionType), type));
        }
    }
}
