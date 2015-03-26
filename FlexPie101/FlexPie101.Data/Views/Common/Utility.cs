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
    public class PreciseStepper : Stepper
    {
        public PreciseStepper()
        {
            this.ValueChanged += PreciseStepper_ValueChanged;
        }


        public PreciseStepper(double min, double max, double val, double increment)
            : base(min, max, val, increment)
        {
            this.ValueChanged += PreciseStepper_ValueChanged;
        }
        void PreciseStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (Math.Abs(this.Value - 0) < 0.000000000001)
                this.Value = 0;
        }
    }
}
