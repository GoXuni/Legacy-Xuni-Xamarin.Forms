using FlexChartDemo.Data.Model;
using FlexChartDemo.Data.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xuni.Forms.FlexChart;

namespace FlexChartDemo.Data.Views.Samples
{
    public partial class UpdateAnimation : ContentPage
    {
        ObservableCollection<MyDataObject> objects;
        Random rnd = new Random();
        public UpdateAnimation()
        {
            InitializeComponent();
            Title = AppResources.UpdateAnimationTitle;

            // initialize pickers
            this.pickerChartType.Items.Add(ChartType.Column.ToString());
            this.pickerChartType.Items.Add(ChartType.Area.ToString());
            this.pickerChartType.Items.Add(ChartType.Line.ToString());
            this.pickerChartType.Items.Add(ChartType.LineSymbols.ToString());
            this.pickerChartType.Items.Add(ChartType.Spline.ToString());
            this.pickerChartType.Items.Add(ChartType.SplineSymbols.ToString());
            this.pickerChartType.Items.Add(ChartType.SplineArea.ToString());
            this.pickerChartType.Items.Add(ChartType.Scatter.ToString());
            this.pickerChartType.SelectedIndex = 0;
            this.pickerChartType.SelectedIndexChanged +=pickerChartType_SelectedIndexChanged;
            this.pickerUpdatePosition.Items.Add(UpdatePosition.Beginning.ToString());
            this.pickerUpdatePosition.Items.Add(UpdatePosition.Middle.ToString());
            this.pickerUpdatePosition.Items.Add(UpdatePosition.End.ToString());
            this.pickerUpdatePosition.SelectedIndex = 0;
            btnAdd.Text = AppResources.AddPoint;
            btnRemove.Text = AppResources.RemovePoint;

            // populate dummy data set using ObservableCollection
            // note: you should use ObservableCollection or anything else that implements INotifyPropertyChanged to see updates in the FlexChart
            objects = new ObservableCollection<MyDataObject>();
            for (int i = 0; i < 8; i++)
            {
                objects.Add(new MyDataObject { Value = rnd.Next(i, 10 + i * i), XValue = GetRandomLetter() });
            }
            this.flexChart.ItemsSource = objects;

            // misc chart properties
            this.flexChart.Palette = Xuni.Forms.ChartCore.ChartPalettes.Cocoa;
            this.flexChart.AxisY.AxisLineVisible = false;
            this.flexChart.AxisY.MajorTickWidth = 0;
            this.flexChart.Legend.Position = Xuni.Forms.ChartCore.ChartPositionType.None;
        }

        void btnAdd_Clicked(object sender, EventArgs e)
        {
            if (this.pickerUpdatePosition.SelectedIndex != -1 && this.flexChart != null)
            {
                if(this.pickerUpdatePosition.SelectedIndex == 0)
                {
                    objects.Insert(0, new MyDataObject { Value = rnd.Next(10, 80), XValue= GetRandomLetter() });
                }
                else if(this.pickerUpdatePosition.SelectedIndex == 1)
                {
                    objects.Insert(objects.Count / 2, new MyDataObject { Value = rnd.Next(10, 80), XValue = GetRandomLetter() });
                }
                else
                {
                    objects.Add(new MyDataObject { Value = rnd.Next(10, 80), XValue = GetRandomLetter() });
                }
            }
        }

        void btnRemove_Clicked(object sender, EventArgs e)
        {
            if (this.pickerUpdatePosition.SelectedIndex != -1 && this.flexChart != null)
            {
                if (this.pickerUpdatePosition.SelectedIndex == 0)
                {
                    objects.RemoveAt(0);
                }
                else if (this.pickerUpdatePosition.SelectedIndex == 1)
                {
                    objects.RemoveAt(objects.Count / 2);
                }
                else
                {
                    objects.RemoveAt(objects.Count - 1);
                }
            }
        }

        void pickerChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.pickerChartType.SelectedIndex != -1 && this.flexChart != null)
            {
                this.flexChart.ChartType = (ChartType)Enum.Parse(typeof(ChartType), this.pickerChartType.Items[this.pickerChartType.SelectedIndex]);
            }
        }


        string GetRandomLetter()
        {
            return Char.ConvertFromUtf32(rnd.Next(65, 90));
        }
    }

    class MyDataObject
    {
        public string XValue { get; set; }
        public double Value { get; set; }
    }

    enum UpdatePosition
    {
        Beginning,
        Middle,
        End
    }
}
