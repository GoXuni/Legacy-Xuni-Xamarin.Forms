using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Xuni.Xamarin.FlexChart.Render.WinPhone;
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
            // ViewRenderer can not be loaded from an external dll.
            //http://forums.xamarin.com/discussion/18456/custom-renderer-in-external-dll-not-working
            Startup startup = new Startup();
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new FlexChartDemo.App()); 
            
            //Forms.Init();
            //Content = FlexChartDemo.App.GetMainPage().ConvertPageToUIElement(this);
        }
    }
}
