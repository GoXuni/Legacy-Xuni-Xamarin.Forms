using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using FlexChartDemo.Data.Model;
using FlexChartDemo.Data.Views;
using FlexChartDemo.Data;

namespace FlexChartDemo
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new FlexChartSamples());
        }
       
		protected override void OnStart ()
		{
			Xuni.Forms.Core.LicenseManager.Key = Xuni.FlexChartDemo.App.License.Key;
		}
    }
}
