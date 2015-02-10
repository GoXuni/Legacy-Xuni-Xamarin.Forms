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
    public partial class SelectionSample
    {
        public SelectionSample()
        {
            InitializeComponent();
            this.flexPie.ItemsSource = PieChartSampleFactory.CreateEntiyList();

            this.pickerPosition.SelectedIndexChanged += pickerPosition_SelectedIndexChanged;
            foreach (var item in Enum.GetNames(typeof(ChartPositionType)))
            {
                this.pickerPosition.Items.Add(item);
            }
            this.pickerPosition.SelectedIndex = 2;
        }
        void pickerPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type=this.pickerPosition.Items[this.pickerPosition.SelectedIndex];
            this.flexPie.SelectedItemPosition=(ChartPositionType)(Enum.Parse(typeof(ChartPositionType),type));
        }
    }
}
