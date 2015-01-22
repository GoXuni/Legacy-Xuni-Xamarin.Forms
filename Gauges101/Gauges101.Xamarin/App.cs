using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaugeDemo
{
    public class App : Xamarin.Forms.Application
    {
        public App()
        {
            MainPage = new Xamarin.Forms.NavigationPage(new GaugeSamples());
        }
    }
}
