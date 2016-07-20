using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar101
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();
            if (Xamarin.Forms.Device.OS == Xamarin.Forms.TargetPlatform.Windows)
                Resources["TitleVisible"] = false;
            MainPage = new Xamarin.Forms.NavigationPage(new CalendarSamples());
        }

        protected override void OnStart()
        {
            Xuni.Forms.Core.LicenseManager.Key = License.Key;
        }
    }
}
