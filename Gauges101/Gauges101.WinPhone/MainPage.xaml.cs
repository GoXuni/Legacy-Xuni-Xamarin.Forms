using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Xuni.Forms.Gauge.Platform.WinPhone;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

namespace Gauges101.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        // Constructor
        public MainPage()
        {
            GaugeRenderer.Init();
            InitializeComponent();
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new Gauges101.App()); 
        }
    }
}