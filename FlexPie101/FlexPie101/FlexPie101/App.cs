using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using FlexPieDemo.Data.Repo;

using FlexPieDemo.Data.Views;

namespace FlexPieDemo
{
    public class App : Xamarin.Forms.Application
    {
        public App()
        {
            //MainPage = ChartSampleViewFactory.GetChartContentPage(new XmlRepository().GetPieChartSamples()[2]);

            MainPage = new NavigationPage(new ChartSampleGrid());
        }
    }
}
