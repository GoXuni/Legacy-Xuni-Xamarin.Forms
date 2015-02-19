using FlexChartDemo.Data.Chart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xuni.Xamarin.ChartCore;
using Xuni.Xamarin.ChartCore.Enums;
using Xuni.Xamarin.FlexChart;

namespace FlexChartDemo.Data.Views.Samples
{
    public partial class AnimationOptions
    {
        public AnimationOptions()
        {
            InitializeComponent();
            FlexChartDemo.Data.Views.Common.Utility.CheckNavBar(this);
            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
            this.pickerChartType.Items.Add(ChartType.Column.ToString());
            this.pickerChartType.Items.Add(ChartType.Bar.ToString());
            this.pickerChartType.Items.Add(ChartType.Scatter.ToString());
            this.pickerChartType.Items.Add(ChartType.Line.ToString());
            this.pickerChartType.Items.Add(ChartType.LineSymbol.ToString());
            this.pickerChartType.Items.Add(ChartType.Area.ToString());

			foreach (var item in Enum.GetNames(typeof(AnimationMode)))
            {
                this.pickerAnimationMode.Items.Add(item);
            }
            this.pickerChartType.SelectedIndex = 0;
            this.pickerAnimationMode.SelectedIndex = 1;

            // customize animation
            this.flexChart.LoadAnimation.Duration = 900;
            this.flexChart.LoadAnimation.Easing = Easing.SpringIn;
        }

        void pickerChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.pickerChartType.SelectedIndex != -1 && this.flexChart != null)
            {
                this.flexChart.ChartType = (ChartType)Enum.Parse(typeof(ChartType), this.pickerChartType.Items[this.pickerChartType.SelectedIndex]);
            }
        }

        void pickerAnimationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.pickerAnimationMode.SelectedIndex != -1 && this.flexChart != null)
            {
                this.flexChart.LoadAnimation.AnimationMode = (AnimationMode)Enum.Parse(typeof(AnimationMode), this.pickerAnimationMode.Items[this.pickerAnimationMode.SelectedIndex]);
            }
        }  
    }
}
