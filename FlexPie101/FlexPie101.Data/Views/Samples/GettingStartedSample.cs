using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;

using Xuni.Xamarin.FlexPie;

using FlexPieDemo.Data.Chart;

namespace FlexPieDemo.Data.Views.Samples
{
    public class GettingStartedSample : BaseSample
    {
        RelativeLayout mainRelativeLayout;

        FlexPie pieChart;
        FlexPie donutChart;

        public GettingStartedSample(PieChartSample chartSample)
            : base()
        {
            pieChart = PieChartSampleFactory.GetFlexChartSample(chartSample);
            donutChart = PieChartSampleFactory.GetFlexChartSample(chartSample);

            donutChart.InnerRadius = .6;

            mainRelativeLayout = new RelativeLayout();

            mainRelativeLayout.Children.Add(pieChart, Constraint.Constant(0), Constraint.Constant(0),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height / 2;
                }));

            mainRelativeLayout.Children.Add(donutChart,
            Constraint.Constant(0),
            Constraint.RelativeToView(pieChart, (parent, sibling) =>
            {
                return sibling.Y + sibling.Height;
            }),
            Constraint.RelativeToParent((parent) =>
            {
                return parent.Width;
            }),
            Constraint.RelativeToParent((parent) =>
            {
                return parent.Height / 2;
            }));

            Content = mainRelativeLayout;
        }
    }
}
