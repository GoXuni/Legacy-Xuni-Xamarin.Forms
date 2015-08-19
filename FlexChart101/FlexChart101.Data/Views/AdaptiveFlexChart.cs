using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xuni.Xamarin.FlexChart;

namespace FlexChartDemo.Data.Views
{
    public class AdaptiveFlexChart : FlexChart
    {
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (base.Legend != null)
            {
                // In Portrait
                if (width < height)
                {
                    base.Legend.Position = Xuni.Xamarin.ChartCore.ChartPositionType.Bottom;

                    base.AxisX.LabelAngle = -45;
                }
                // In Landscape
                else
                {
                    base.Legend.Position = Xuni.Xamarin.ChartCore.ChartPositionType.Right;

                    base.AxisX.LabelAngle = 0;
                }
            }
        }
    }
}
