using FlexChartDemo.Data.Model;
using FlexChartDemo.Data.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xuni.Forms.ChartCore;
using Xuni.Forms.FlexChart;

namespace FlexChartDemo.Data.Views.Samples
{
    public partial class AnimationOptions
    {
        public AnimationOptions()
        {
            InitializeComponent();
            Title = AppResources.LoadAnimationTitle;

            //FlexChartDemo.Data.Views.Common.Utility.CheckNavBar(this);
            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
            this.pickerChartType.Items.Add(ChartType.Column.ToString());
            this.pickerChartType.Items.Add(ChartType.Area.ToString());
            this.pickerChartType.Items.Add(ChartType.Line.ToString());
            this.pickerChartType.Items.Add(ChartType.LineSymbols.ToString());
            this.pickerChartType.Items.Add(ChartType.Spline.ToString());
            this.pickerChartType.Items.Add(ChartType.SplineSymbols.ToString());
            this.pickerChartType.Items.Add(ChartType.SplineArea.ToString());
            this.pickerChartType.Items.Add(ChartType.Scatter.ToString());
            
			foreach (var item in Enum.GetNames(typeof(ChartAnimationMode)))
            {
                this.pickerAnimationMode.Items.Add(item);
            }
            this.pickerChartType.SelectedIndex = 0;
            this.pickerAnimationMode.SelectedIndex = 1;

            // customize animation
            this.flexChart.LoadAnimation.Duration = 1200;
            this.flexChart.LoadAnimation.StartDelay = 300;
            //this.flexChart.LoadAnimation.Easing = Easing.SpringIn;

            this.flexChart.Palette = Xuni.Forms.ChartCore.ChartPalettes.Modern;
            this.flexChart.AxisX.Format = "M/dd";
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
                this.flexChart.LoadAnimation.AnimationMode = (ChartAnimationMode)Enum.Parse(typeof(ChartAnimationMode), this.pickerAnimationMode.Items[this.pickerAnimationMode.SelectedIndex]);
            }
        }  
    }
}
