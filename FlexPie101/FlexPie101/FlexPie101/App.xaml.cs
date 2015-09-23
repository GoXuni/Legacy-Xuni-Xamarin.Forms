using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using FlexPieDemo.Data.Views;
using FlexPieDemo.Data;

namespace FlexPieDemo
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new FlexPieSamples());
        }

		protected override void OnStart ()
		{
			Xuni.Forms.Core.LicenseManager.Key = Xuni.FlexPieDemo.App.License.Key;
		}
    }
}
