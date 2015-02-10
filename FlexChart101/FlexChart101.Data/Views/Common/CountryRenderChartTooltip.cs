using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

using Xamarin;
using Xamarin.Forms;

using Xuni.Xamarin.FlexChart;

namespace FlexChartDemo.Data.Views.Common
{
    public class CountryRenderChartTooltip
    {
        

        public static StackLayout GetCountryRenderChartTooltip(FlexChart flexChart)
        {
            Image image = new Image();
            Label title = new Label();
            Label content = new Label();

            StackLayout container = new StackLayout();
            container.Padding = 5;


            container.BackgroundColor = Color.FromHex("#FFFFCA");

            title.SetBinding(Label.TextProperty, "SeriesName");
            title.TextColor = Color.Black;
            title.FontAttributes = FontAttributes.Bold;
            title.FontSize = 14;
            image.SetBinding(Image.SourceProperty, "XValue", BindingMode.OneWay, new FlagConverter());

            StackLayout horizontalContainer = new StackLayout();
            horizontalContainer.Orientation = StackOrientation.Horizontal;

            content.SetBinding(Label.TextProperty, "YValue");
            content.TextColor = Color.Black;
            content.FontSize = 14;

            horizontalContainer.Children.Add(image);
            horizontalContainer.Children.Add(title);

            container.Children.Add(horizontalContainer);
            container.Children.Add(content);

            return container;

            //((RelativeLayout)flexChart.Parent).Children.Add(this, Constraint.Constant(50), Constraint.Constant(50));
        }

      
    }
    public class FlagConverter : IValueConverter
    {
        private static ImageSource us = ImageSource.FromResource("FlexChartDemo.Data.Images.US.png");
        private static ImageSource germany = ImageSource.FromResource("FlexChartDemo.Data.Images.Germany.png");
        private static ImageSource uk = ImageSource.FromResource("FlexChartDemo.Data.Images.UK.png");
        private static ImageSource japan = ImageSource.FromResource("FlexChartDemo.Data.Images.Japan.png");
        private static ImageSource italy = ImageSource.FromResource("FlexChartDemo.Data.Images.Italy.png");
        private static ImageSource greece = ImageSource.FromResource("FlexChartDemo.Data.Images.Greece.png");
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                String flag = value.ToString().ToUpper();

                switch (flag)
                {
                    case "US":
                        return us;

                    case "UK":
                        return uk;

                    case "GERMANY":
                        return germany;

                    case "JAPAN":
                        return japan;

                    case "ITALY":
                        return italy;

                    case "GREECE":
                        return greece;

                }
            }

            return us;
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            return us;
        }
    }
}
