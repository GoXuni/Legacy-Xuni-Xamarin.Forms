using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Xuni.Xamarin.Gauge.Render.WinPhone;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

namespace GaugeDemo.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        // Constructor
        public MainPage()
        {
            Startup startup = new Startup();

            InitializeComponent();

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new GaugeDemo.App()); 
        }
    }
}