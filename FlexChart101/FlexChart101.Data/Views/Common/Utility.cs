using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;
using System.Globalization;

namespace FlexChartDemo.Data.Views.Common
{
    public class Utility
    {
        public static void CheckNavBar(ContentPage page)
        {
            //remove navgiation bar on android
            Device.OnPlatform(Android: () => NavigationPage.SetHasNavigationBar(page, false));
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
