using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaugeDemo
{
    public interface Repository
    {
        List<Sample> GetSamples();
    }
}
