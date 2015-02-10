using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;

namespace FlexPieDemo.Data.Views.Common
{
    public class Utility
    {
        public static void CheckNavBar(ContentPage page)
        {
            //remove navgiation bar on android
            Device.OnPlatform(Android: () => NavigationPage.SetHasNavigationBar(page, false));
        }
    }
}
