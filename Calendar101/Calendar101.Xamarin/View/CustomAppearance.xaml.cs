using Xuni.Forms.Calendar;
using Calendar101.Resources;

namespace Calendar101
{
    public partial class CustomAppearance
    {
        public CustomAppearance()
        {
            InitializeComponent();
            Title = AppResources.CustomAppearanceTitle;

            calendar.ViewModeAnimation.AnimationMode = CalendarViewModeAnimationMode.ZoomOutIn;
            calendar.ViewModeAnimation.ScaleFactor = 1.1;
            calendar.ViewModeAnimation.Duration = 150;

            calendar.NavigateAnimation.Duration = 150;
        }

    }
}
