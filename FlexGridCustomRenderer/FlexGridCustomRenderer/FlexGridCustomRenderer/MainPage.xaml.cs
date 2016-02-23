using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FlexGridCustomRenderer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Xuni.Forms.Core.LicenseManager.Key = License.Key;

            var data = StockSymbol.GetStockSymbolList(100);
            grid1.ItemsSource = data;
            grid2.ItemsSource = data;

			if (Device.OS == TargetPlatform.iOS) {
				this.Padding = new Thickness (0, 20, 0, 0);
			}
        }
    }

    public class ChangeTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double change = (double)value;
            if (change < 0)
            {
                return Color.FromRgb(231, 76, 60);
            }
            else if (change > 0)
            {
                return Color.FromRgb(46, 204, 113);
            }
            return Color.Default;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

}
