using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using Xuni.Xamarin.FlexPie.Render.WinPhone;


namespace FlexPieDemo.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        public MainPage()
        {
            Startup Startup = new Xuni.Xamarin.FlexPie.Render.WinPhone.Startup();
            InitializeComponent();

            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new FlexPieDemo.App()); 
        }
    }
}
