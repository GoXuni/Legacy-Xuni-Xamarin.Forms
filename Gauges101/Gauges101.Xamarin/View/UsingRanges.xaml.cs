using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaugeDemo
{
    public partial class UsingRanges
    {
        public UsingRanges()
        {
            InitializeComponent();

            BindingContext = new SampleViewModel() { Value = 25 };
        }
    }
}
