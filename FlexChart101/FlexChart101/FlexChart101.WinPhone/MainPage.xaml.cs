using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Xuni.Xamarin.FlexChart.Platform.WinPhone;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;


namespace FlexChartDemo.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        public MainPage()
        {
            FlexChartRenderer.Init();
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new FlexChartDemo.App()); 
        }
    }
}
