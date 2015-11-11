using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexChartDemo.Data.Model;
using Xamarin.Forms;
using Xuni.Forms.FlexChart;
using FlexChartDemo.Data.Resources;
using Xuni.Forms.FlexChart.Enums;
using Xuni.Forms.ChartCore;
namespace FlexChartDemo.Data.Views.Samples
{
    public partial class LineMarkerSample
    {
        double[] verticalPositions = { double.NaN,0, 0.25, 0.5, 0.75, 1 };
        public LineMarkerSample()
        {
            InitializeComponent();
            Title = AppResources.LineMarkerTitle;
            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
            this.flexChart.LineMarker.IsVisible = true;

            foreach (var item in Enum.GetNames(typeof(ChartMarkerInteraction)))
            {
                this.pickerInteraction.Items.Add(item);
            }
            foreach (var item in verticalPositions)
            {
                this.pickerVerPosition.Items.Add(item.ToString());
            }
            this.pickerInteraction.SelectedIndex = 1;
            this.pickerVerPosition.SelectedIndex = 1;
        }
        void pickerInterraction_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexChart.LineMarker.Interaction = (ChartMarkerInteraction)Enum.Parse(typeof(ChartMarkerInteraction), this.pickerInteraction.Items[this.pickerInteraction.SelectedIndex]);
        }
        void pickerVerPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexChart.LineMarker.VerticalPosition = this.verticalPositions[this.pickerVerPosition.SelectedIndex];
        }
    }
}
