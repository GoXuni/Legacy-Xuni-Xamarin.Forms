using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xuni.DashboardDemo.App;

namespace DashboardDemo
{
    public class App : Application
    {
        public App()
        {

            MainPage = GetMainPage();

        }
        public static Page GetMainPage()
        {

            if (Device.Idiom == TargetIdiom.Phone)
            {
                return new NavigationPage(new PhoneDash());
            }
            else
            {
                return new NavigationPage(new TabletDash());
            }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
            Xuni.Xamarin.Core.LicenseManager.Key = License.Key;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
