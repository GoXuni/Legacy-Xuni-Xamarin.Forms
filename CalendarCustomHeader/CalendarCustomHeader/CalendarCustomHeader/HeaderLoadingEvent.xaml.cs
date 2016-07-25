using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CalendarCustomHeader
{
    public partial class HeaderLoadingEvent : ContentPage
    {
        public HeaderLoadingEvent()
        {
            InitializeComponent();
            calendar.HeaderLoading += Calendar_HeaderLoading;
        }

        private void Calendar_HeaderLoading(object sender, Xuni.Forms.Calendar.CalendarHeaderLoadingEventArgs e)
        {
            if(e.ViewMode == Xuni.Forms.Calendar.CalendarViewMode.Month)
            {
                e.Header = e.Date.Month.ToString() + " " + e.Header;
            }
            else if(e.ViewMode == Xuni.Forms.Calendar.CalendarViewMode.Year)
            {
                e.Header = e.Header + "!";
            }
            else if(e.ViewMode == Xuni.Forms.Calendar.CalendarViewMode.Decade)
            {
                e.Header = "Select a year";
            }
        }
    }
}
