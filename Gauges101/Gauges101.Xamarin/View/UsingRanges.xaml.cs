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

            BindingContext = new SampleViewModel() { Value = 25 };
        }
    }
}
