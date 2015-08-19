using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using FlexGrid101.WinPhone.Resources;
using Xuni.Forms.FlexGrid.Platform.WinPhone;
using Xamarin.Forms.Platform.WinPhone;
using Xuni.Forms.Gauge.Platform.WinPhone;
using Xuni.Forms.Core.Platform.WinPhone;

namespace FlexGrid101.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        // Constructor
        public MainPage()
        {
            FlexGridRenderer.Init();
            GaugeRenderer.Init();
            CoreRenderer.Init();
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new FlexGrid101.App());
        }
    }
}