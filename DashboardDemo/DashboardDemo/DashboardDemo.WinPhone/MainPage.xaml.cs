using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace DashboardDemo.WinPhone
{
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();
            Xuni.Xamarin.FlexChart.Platform.WinPhone.FlexChartRenderer.Init();
            Xuni.Xamarin.FlexPie.Platform.WinPhone.FlexPieRenderer.Init();
            Xuni.Xamarin.Gauge.Platform.WinPhone.GaugeRenderer.Init();

            LoadApplication(new DashboardDemo.App());
        }
    }
}
