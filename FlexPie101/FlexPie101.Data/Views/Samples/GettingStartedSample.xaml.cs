using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexPieDemo.Data.Chart;
using Xamarin.Forms;
using Xuni.Xamarin.FlexPie;

namespace FlexPieDemo.Data.Views.Samples
{
    public partial class GettingStartedSample
    {
        public GettingStartedSample()
        {
            InitializeComponent();
            this.pieChart.ItemsSource = PieChartSampleFactory.CreateEntiyList();
            this.dountChart.ItemsSource = PieChartSampleFactory.CreateEntiyList();
            this.root.SizeChanged += root_SizeChanged;
        }

        void root_SizeChanged(object sender, EventArgs e)
        {
            if (root.Width > root.Height)
            {
                Grid.SetColumn(pieChart, 0);
                Grid.SetRow(pieChart, 0);
                Grid.SetRowSpan(pieChart, 2);
                Grid.SetColumnSpan(pieChart, 1);

                Grid.SetRow(dountChart, 0);
                Grid.SetColumn(dountChart, 1);
                Grid.SetRowSpan(dountChart, 2);
                Grid.SetColumnSpan(dountChart, 1);
            }
            else
            {
                Grid.SetRow(pieChart, 0);
                Grid.SetColumn(pieChart, 0);
                Grid.SetColumnSpan(pieChart, 2);
                Grid.SetRowSpan(pieChart, 1);

                Grid.SetRow(dountChart, 1);
                Grid.SetColumn(dountChart, 0);
                Grid.SetColumnSpan(dountChart, 2);
                Grid.SetRowSpan(dountChart, 1);
            }
        }
    }
}
