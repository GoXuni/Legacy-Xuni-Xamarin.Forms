using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DashboardDemo
{
    public partial class TabletDash : ContentPage
    {
        public TabletDash()
        {
            InitializeComponent();
            this.Title = "Sales Dashboard";
            DataSource ds = new DataSource();
            this.chart.BindingContext = ds;
            this.pie.BindingContext = ds;

            this.chart.AxisY.AxisLineVisible = false;

            double[] dashes = new double[] { 3, 1 };

            Device.OnPlatform(Android: () =>
                dashes = new double[] { 21, 7 }
            );

            Device.OnPlatform(WinPhone: () =>
               dashes = new double[] { 3, 1 }
                );

            Device.OnPlatform(iOS: () =>
                dashes = new double[] { 7.5, 2.5 }
                );

            this.pie.SelectedDashes = null;
            this.chart.SelectedDashes = null;
            this.pie.SelectedBorderWidth = 2;
            this.chart.SelectedBorderWidth = 2;
            this.chart.SelectionMode = Xuni.Forms.ChartCore.ChartSelectionModeType.Series;
            this.chart.SelectionChanged += chart_SelectionChanged;
            this.chart.AxisY.MajorTickWidth = 0;
            this.graph.IsReadOnly = true;
            this.graph2.IsReadOnly = true;
            this.graph3.IsReadOnly = true;
        }

        void chart_SelectionChanged(object sender, Xuni.Forms.FlexChart.ChartSelectionChangedEventArgs e)
        {
            if (e.HitTestInfo.DataPoint != null && e.HitTestInfo.DataPoint.SeriesName != null)
            {
                this.pie.Binding = e.HitTestInfo.DataPoint.SeriesName;
                this.pie.HeaderText = e.HitTestInfo.DataPoint.SeriesName;
            }
        }

    }
}
