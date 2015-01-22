using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlexChartDemo.Data.Chart;

namespace FlexChartDemo.Data.Repo
{
    public interface Repository
    {
        List<ChartSample> GetChartSamples();
    }
}
