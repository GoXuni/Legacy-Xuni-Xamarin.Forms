using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexChartDemo.Data.Model;
using Xamarin.Forms;
using Xuni.Forms.FlexChart;
using FlexChartDemo.Data.Resources;
using FlexChartDemo.Data.Views.Common;
using System.Globalization;

namespace FlexChartDemo.Data.Views.Samples
{
    public partial class CustomizingAxesSample
    {
        FlagConverter flagConverter = new FlagConverter();
        public CustomizingAxesSample()
        {
            InitializeComponent();

            Title = AppResources.CustomizingAxesTitle;

            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
            this.flexChart.AxisX.LabelLoading += AxisXLabeLoading;
            this.flexChart.AxisY.LabelLoading += AxisYLabeLoading;
        }

        void AxisXLabeLoading(object sender, LabelLoadingEventArgs e)
        {
            Image img = new Image();
            ImageSource src = this.flagConverter.Convert(e.Text,typeof(ImageSource),null,CultureInfo.CurrentUICulture) as ImageSource;
            img.Source = src;
            e.Label = img;
        }
        void AxisYLabeLoading(object sender, LabelLoadingEventArgs e)
        {
            Label  label = new Label();
            label.YAlign = TextAlignment.Center;
            label.XAlign = TextAlignment.End;

            if (e.Value > 7000)
            {
                label.TextColor = Color.Green;
            }
            else if (e.Value <= 4000)
            {
                label.TextColor = Color.Red;
            }
            label.Text=string.Format("${0}K",e.Value/1000);
			Device.OnPlatform(iOS: () => label.FontSize = 12);
            e.Label = label;
        }
    }
}
