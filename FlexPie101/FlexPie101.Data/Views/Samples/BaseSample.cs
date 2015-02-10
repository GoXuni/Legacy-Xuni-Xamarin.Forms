using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;

namespace FlexPieDemo.Data.Views.Samples
{
    public class BaseSample : ContentPage
    {
        public BaseSample()
        {
            FlexPieDemo.Data.Views.Common.Utility.CheckNavBar(this);
        }
    }
}
