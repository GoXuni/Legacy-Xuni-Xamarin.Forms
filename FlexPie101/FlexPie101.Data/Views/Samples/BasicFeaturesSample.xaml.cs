using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexPieDemo.Data.Model;
using Xamarin.Forms;
using Xuni.Forms.FlexPie;

namespace FlexPieDemo.Data.Views.Samples
{
    public partial class BasicFeaturesSample
    {
        public BasicFeaturesSample()
        {
            InitializeComponent();
            this.flexPie.ItemsSource = PieChartSampleFactory.CreateEntiyList();
            this.flexPie.Palette = Xuni.Forms.ChartCore.Palettes.Midnight;
            this.SizeChanged += gr_SizeChanged;
        }

        void gr_SizeChanged(object sender, EventArgs e)
        {
            if (root.Width > root.Height)
            {
                Grid.SetColumn(gridOption, 0);
                Grid.SetRow(gridOption, 0);
                Grid.SetRowSpan(gridOption, 2);

                Grid.SetRow(flexPie, 0);
                Grid.SetColumn(flexPie, 1);
                Grid.SetRowSpan(flexPie, 2);
            }
            else
            {
                Grid.SetRow(gridOption, 0);
                Grid.SetColumn(gridOption, 0);
                Grid.SetColumnSpan(gridOption, 2);

                Grid.SetRow(flexPie, 1);
                Grid.SetColumn(flexPie, 0);
                Grid.SetColumnSpan(flexPie, 2);
            }
        }
    }
}
