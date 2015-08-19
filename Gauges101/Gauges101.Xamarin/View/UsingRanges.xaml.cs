using Gauges101.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges101
{
    public partial class UsingRanges
    {
        public UsingRanges()
        {
            InitializeComponent();
            lblTitle.Text = AppResources.UsingRangesTitle;

            BindingContext = new SampleViewModel() { Value = 25 };

            linearGauge.Pointer.Thickness = 0.5;
            radialGauge.Pointer.Thickness = 0.5;
        }
    }
}
