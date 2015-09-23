using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexGrid101
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Xamarin.Forms.NavigationPage(new FlexGridSamples());
        }

        protected override void OnStart()
        {
            Xuni.Forms.Core.LicenseManager.Key = License.Key;
        }
    }
}
