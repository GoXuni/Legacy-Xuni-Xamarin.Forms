using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CalendarCustomHeader
{
    public partial class CustomButtons : ContentPage
    {
        public CustomButtons()
        {
            InitializeComponent();
            calendar.DisplayDateChanged += Calendar_DisplayDateChanged;
            //calendar.ViewModeChanged += Calendar_ViewModeChanged;

            TapGestureRecognizer tgrNextMonth = new TapGestureRecognizer();
            tgrNextMonth.Tapped += TgrNextMonth_Tapped;
            btnNextMonth.GestureRecognizers.Add(tgrNextMonth);

            TapGestureRecognizer tgrPrevMonth = new TapGestureRecognizer();
            tgrPrevMonth.Tapped += TgrPrevMonth_Tapped;
            btnPrevMonth.GestureRecognizers.Add(tgrPrevMonth);

            TapGestureRecognizer tgrMonthYear = new TapGestureRecognizer();
            tgrMonthYear.Tapped += TgrMonthYear_Tapped;
            lblMonthYear.GestureRecognizers.Add(tgrMonthYear);

            UpdateHeaderText();
        }

        async private void Calendar_ViewModeChanged(object sender, EventArgs e)
        {
            // MOVED: I found it behaves better when we update the header text in the TgrMonthYear_Tapped event
            //await UpdateHeaderText();
            
        }

        async private void TgrMonthYear_Tapped(object sender, EventArgs e)
        {
            if(calendar.ViewMode == Xuni.Forms.Calendar.CalendarViewMode.Month)
            {
                await calendar.ChangeViewModeAsync(Xuni.Forms.Calendar.CalendarViewMode.Year);
            }
            else if(calendar.ViewMode == Xuni.Forms.Calendar.CalendarViewMode.Year)
            {
                await calendar.ChangeViewModeAsync(Xuni.Forms.Calendar.CalendarViewMode.Decade);
            }
            else
            {
                await calendar.ChangeViewModeAsync(Xuni.Forms.Calendar.CalendarViewMode.Month);
            }
            // added: update header text here when we change
            await UpdateHeaderText();
        }

        async private void TgrPrevMonth_Tapped(object sender, EventArgs e)
        {
            await calendar.GoBackAsync();
        }

        async private void TgrNextMonth_Tapped(object sender, EventArgs e)
        {
            await calendar.GoForwardAsync();
        }

        async private void Calendar_DisplayDateChanged(object sender, EventArgs e)
        {
            await UpdateHeaderText();
        }

        async private Task UpdateHeaderText()
        {
            // animate label
            lblMonthYear.TranslationY = 20;
            await lblMonthYear.TranslateTo(0, 0, 100, Easing.CubicOut);

            if (calendar.ViewMode == Xuni.Forms.Calendar.CalendarViewMode.Month)
            {
                lblMonthYear.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(calendar.DisplayDate.Month) + " " + calendar.DisplayDate.Year.ToString();
            }
            else if(calendar.ViewMode == Xuni.Forms.Calendar.CalendarViewMode.Year)
            {
                lblMonthYear.Text = calendar.DisplayDate.Year.ToString();
            }
            else
            {
                lblMonthYear.Text = calendar.DisplayDate.Year.ToString().Substring(0, 3) + "0 - " + calendar.DisplayDate.Year.ToString().Substring(0, 3) + "9";
            }
        }

    }
}
