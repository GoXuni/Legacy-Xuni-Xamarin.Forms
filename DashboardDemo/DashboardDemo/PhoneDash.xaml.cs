using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DashboardDemo
{
    public partial class PhoneDash : ContentPage
    {
        public PhoneDash()
        {
            InitializeComponent();
            this.Title = "Sales Dashboard";
            DataSource ds = new DataSource();
            this.chart.BindingContext = ds;
            this.pie.BindingContext = ds;

            this.chart.AxisY.AxisLineVisible = false;

            double[] dashes = new double[] { 3, 1};

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
            this.pie.SelectionChanged += pie_SelectionChanged;
            this.chart.AxisY.MajorTickWidth = 0;
            this.SizeChanged += PhoneDash_SizeChanged;
            this.graph3.IsReadOnly = true;
            
        }

        void pie_SelectionChanged(object sender, Xuni.Forms.FlexPie.SelectionChangedEventArgs e)
        {
			if (e.HitTestInfo.DataPoint != null && e.HitTestInfo.DataPoint.DataObject != null) 
			{
				//this.graph3.SetBinding(Xuni.Forms.Gauge.XuniBulletGraph.ValueProperty, new Binding("DownloadsGoal"));
				Quarter selectedQuarter = e.HitTestInfo.DataPoint.DataObject as Quarter;
				if(pie.Binding.Equals("Downloads"))
				{
					this.graph3.Value = selectedQuarter.DownloadsGoal;
					this.label1.Text = selectedQuarter.Name + " Downloads Goal";
				}
				else if (pie.Binding.Equals("Sales"))
				{
					this.graph3.Value = selectedQuarter.SalesGoal;
					this.label1.Text = selectedQuarter.Name + " Sales Goal";
				}
				else if (pie.Binding.Equals("Expenses"))
				{
					this.graph3.Value = selectedQuarter.ExpensesGoal;
					this.label1.Text = selectedQuarter.Name + " Expenses Goal";
				}
			}
        }

        void PhoneDash_SizeChanged(object sender, EventArgs e)
        {
            gridLayout.RowDefinitions.Clear();
            gridLayout.ColumnDefinitions.Clear();
            if(this.Width > this.Height)
            {
                gridLayout.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                gridLayout.RowDefinitions.Add(new RowDefinition());
                gridLayout.ColumnDefinitions.Add(new ColumnDefinition());
                gridLayout.ColumnDefinitions.Add(new ColumnDefinition());
                gridLayout.ColumnDefinitions.Add(new ColumnDefinition() { Width = 50 });
                Grid.SetColumn(chart, 0);
                Grid.SetRow(chart, 0);
                Grid.SetRowSpan(chart, 2);
                Grid.SetColumn(pie, 1);
                Grid.SetRow(pie, 0);
                Grid.SetRowSpan(pie, 2);
                Grid.SetColumn(graph3, 2);
                Grid.SetRow(graph3, 1);
                Grid.SetColumn(label1, 2);
                Grid.SetRow(label1, 0);
                chart.Legend.Position = Xuni.Forms.ChartCore.ChartPositionType.Bottom;
                graph3.Direction = Xuni.Forms.Gauge.LinearGaugeDirection.Up;

            }
            else
            {
                gridLayout.RowDefinitions.Add(new RowDefinition());
                gridLayout.RowDefinitions.Add(new RowDefinition());
                gridLayout.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                gridLayout.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50) });
                Grid.SetColumn(chart, 0);
                Grid.SetRow(chart, 0);
                Grid.SetRowSpan(chart, 1);
                Grid.SetColumn(pie, 0);
                Grid.SetRow(pie, 1);
                Grid.SetRowSpan(pie, 1);
                Grid.SetColumn(pie, 0);
                Grid.SetRow(label1, 2);
                Grid.SetColumn(label1, 0);
                Grid.SetRow(graph3, 3);
                Grid.SetColumn(graph3, 0);
                chart.Legend.Position = Xuni.Forms.ChartCore.ChartPositionType.Right;
                graph3.Direction = Xuni.Forms.Gauge.LinearGaugeDirection.Right;
            }
        }


        void chart_SelectionChanged(object sender, Xuni.Forms.FlexChart.SelectionChangeEventArgs e)
        {
            if (e.HitTestInfo.DataPoint != null && e.HitTestInfo.DataPoint.SeriesName != null)
            {
                this.pie.Binding = e.HitTestInfo.DataPoint.SeriesName;
                this.pie.HeaderText = e.HitTestInfo.DataPoint.SeriesName;
            }
        }
    }
}
