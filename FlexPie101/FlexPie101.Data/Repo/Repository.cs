using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlexPieDemo.Data.Chart;

namespace FlexPieDemo.Data.Repo
{
    public interface Repository
    {
        List<PieChartSample> GetPieChartSamples();
    }
}
