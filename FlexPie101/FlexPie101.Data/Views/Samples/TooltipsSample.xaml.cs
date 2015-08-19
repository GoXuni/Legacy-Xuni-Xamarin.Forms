using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexPieDemo.Data.Model;
using Xamarin.Forms;
using Xuni.Forms.ChartCore;
using Xuni.Forms.FlexPie;
using System.Reflection;
namespace FlexPieDemo.Data.Views.Samples
{
    public partial class TooltipsSample
    {
        public TooltipsSample()
        {
            InitializeComponent();
            this.flexPie.ItemsSource = PieChartSampleFactory.CreateEntiyList();

            //pieChart.Tooltip.Content = GetChartTooltip();
        }

        // different approach to set custom tooltip in code
        //public static StackLayout GetChartTooltip()
        //{
        //    //Add labels
        //    Label title = new Label();
        //    title.SetBinding(Label.TextProperty, "Name");
        //    title.TextColor = Color.FromHex("#8A2BE2");

        //    Label content = new Label();
        //    content.SetBinding(Label.TextProperty, "Value");
        //    content.TextColor = Color.Black;



        //    //Add the labels and image to the container
        //    StackLayout verticalContainer = new StackLayout();
        //    verticalContainer.Orientation = StackOrientation.Vertical;
        //    verticalContainer.Padding = 5;
        //    verticalContainer.BackgroundColor = Color.FromHex("#eeffbd");

        //    verticalContainer.Children.Add(title);
        //    verticalContainer.Children.Add(content);

        //    return verticalContainer;
        //}
    }
}
