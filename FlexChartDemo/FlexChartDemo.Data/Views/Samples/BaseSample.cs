using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;

namespace FlexChartDemo.Data.Views.Samples
{
    public class BaseSample : ContentPage
    {
        public BaseSample()
        {
            FlexChartDemo.Data.Views.Common.Utility.CheckNavBar(this);
        }
    }
}
