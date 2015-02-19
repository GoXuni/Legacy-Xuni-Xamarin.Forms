using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using FlexChartDemo.Data.Chart;
using FlexChartDemo.Data.Repo;
using FlexChartDemo.Data.Views;

namespace FlexChartDemo
{
    public class App : Xamarin.Forms.Application
    {
        public App()
        {
            MainPage = new NavigationPage(new ChartSampleGrid());
        }
       
		protected override void OnStart ()
		{
			Xuni.Xamarin.Core.LicenseManager.Key = Xuni.FlexChartDemo.App.License.Key;
		}
    }
}
