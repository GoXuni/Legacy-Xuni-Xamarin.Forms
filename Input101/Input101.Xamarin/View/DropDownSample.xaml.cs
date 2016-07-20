using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Input101.Resources;
using Xuni.Forms.Calendar;

namespace Input101
{
    public partial class DropDownSample
    {
        public DropDownSample()
        {
            InitializeComponent();
            Title = AppResources.DropDownTitle;
            this.calendar.SelectionChanged += CalendarSelectionChanged;
            Action act = () => this.mask.BackgroundColor = Color.Transparent;
			Device.OnPlatform(iOS: act,WinPhone:act);

			Action act1 = () => this.calendar.BackgroundColor = Color.White;
			Device.OnPlatform(iOS: act1);
        }
        private void CalendarSelectionChanged(object sender, CalendarSelectionChangedEventArgs e)
        {
            this.dropdown.IsDropDownOpen = false;
        }
    }
    public class DateTimeStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DateTime)
            {
                return ((DateTime)value).ToString("MM/dd/yyyy");
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
