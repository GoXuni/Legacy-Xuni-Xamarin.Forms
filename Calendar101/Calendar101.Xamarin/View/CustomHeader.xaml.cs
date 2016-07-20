using System;
using Xuni.Forms.Calendar;
using Calendar101.Resources;
using System.Globalization;

namespace Calendar101
{
    public partial class CustomHeader
    {
        public CustomHeader()
        {
            InitializeComponent();
            Title = AppResources.CustomHeaderTitle;

            modePicker.Items.Add(AppResources.MonthLabel);
            modePicker.Items.Add(AppResources.YearLabel);
            modePicker.Items.Add(AppResources.DecadeLabel);
            modePicker.SelectedIndex = 0;
            modePicker.SelectedIndexChanged += OnModeChanged;

            todayButton.Clicked += OnTodayClicked;
            calendar.ViewModeChanged += OnViewModeChanged;
            calendar.DisplayDateChanged += OnDisplayDateChanged;
            UpdateMonthLabel();
        }

        public string TodayLabel
        {
            get
            {
                return AppResources.TodayLabel;
            }
        }

        private async void OnModeChanged(object sender, System.EventArgs e)
        {
            switch (modePicker.SelectedIndex)
            {
                case 0:
                    await calendar.ChangeViewModeAsync(CalendarViewMode.Month);
                    break;
                case 1:
                    await calendar.ChangeViewModeAsync(CalendarViewMode.Year);
                    break;
                case 2:
                    await calendar.ChangeViewModeAsync(CalendarViewMode.Decade);
                    break;
            }
        }

        private async void OnTodayClicked(object sender, System.EventArgs e)
        {
            await calendar.ChangeViewModeAsync(CalendarViewMode.Month, DateTime.Today);
            calendar.SelectedDate = DateTime.Today;
        }

        private void OnViewModeChanged(object sender, EventArgs e)
        {
            switch (calendar.ViewMode)
            {
                case CalendarViewMode.Month:
                    modePicker.SelectedIndex = 0;
                    break;
                case CalendarViewMode.Year:
                    modePicker.SelectedIndex = 1;
                    break;
                case CalendarViewMode.Decade:
                    modePicker.SelectedIndex = 2;
                    break;
            }
        }

        private void OnDisplayDateChanged(object sender, EventArgs e)
        {
            UpdateMonthLabel();
        }

        private void UpdateMonthLabel()
        {
            monthLabel.Text = calendar.DisplayDate.ToString("Y");
        }
    }
}
