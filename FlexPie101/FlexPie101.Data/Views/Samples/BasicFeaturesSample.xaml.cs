using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexPieDemo.Data.Chart;
using Xamarin.Forms;

namespace FlexPieDemo.Data.Views.Samples
{
    public partial class BasicFeaturesSample
    {
        public BasicFeaturesSample()
        {
            InitializeComponent();
            this.flexPie.ItemsSource = PieChartSampleFactory.CreateEntiyList();
        }
    }
}
