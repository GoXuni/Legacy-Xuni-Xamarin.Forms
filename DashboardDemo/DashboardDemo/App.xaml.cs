using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xuni.DashboardDemo.App;

namespace DashboardDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Xuni.Forms.Core.LicenseManager.Key = License.Key;
            
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
