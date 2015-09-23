using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexPieDemo.Data.Model;
using Xamarin.Forms;
using Xuni.Forms.ChartCore;
using FlexPieDemo.Data.Resources;

namespace FlexPieDemo.Data.Views.Samples
{
    public partial class LegendAndTitlesSample
    {
        public LegendAndTitlesSample()
        {
            InitializeComponent();
            Title = AppResources.LegendSampleTitle;

            this.flexPie.ItemsSource = PieChartSampleFactory.CreateEntiyList();
            //this.flexPie.Palette = Xuni.Forms.ChartCore.Palettes.Coral;
            this.flexPie.SelectedDashes = null;
            this.pickerLegendPosition.SelectedIndexChanged += pickerPosition_SelectedIndexChanged;

            foreach (var item in Enum.GetNames(typeof(ChartPositionType)))
            {
                this.pickerLegendPosition.Items.Add(item);
            }
            this.pickerLegendPosition.SelectedIndex = 0;
            this.flexPie.Legend.Position = ChartPositionType.Auto;
        }

        void pickerPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = this.pickerLegendPosition.Items[this.pickerLegendPosition.SelectedIndex];
            this.flexPie.Legend.Position = (ChartPositionType)(Enum.Parse(typeof(ChartPositionType), type));
        }
    }
}
