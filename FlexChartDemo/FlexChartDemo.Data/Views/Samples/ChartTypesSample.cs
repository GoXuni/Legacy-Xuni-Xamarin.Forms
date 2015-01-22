using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;

using Xuni.Xamarin.FlexChart;

using FlexChartDemo.Data.Chart;

using FlexChartDemo.Data.Views.Common;

namespace FlexChartDemo.Data.Views.Samples
{
    public class ChartTypesSample : BaseSample
    {
        public ChartTypesSample(ChartSample chartSample)
            : base()
        {
            FlexChart chart = ChartSampleFactory.GetFlexChartSample(chartSample);


            RelativeLayout mainRelativeLayout = new RelativeLayout();

            WrapLayout pickerStack = new WrapLayout();

            pickerStack.Orientation = StackOrientation.Horizontal;

            Picker chartType = Pickers.GetChartTypePicker(chart);
            Picker stackingType = Pickers.GetChartStackingTypePicker(chart);
            Picker rotationType = Pickers.GetChartRotationTypePicker(chart);

            pickerStack.Children.Add(chartType);
            pickerStack.Children.Add(stackingType);
            pickerStack.Children.Add(rotationType);

            mainRelativeLayout.Children.Add(pickerStack, Constraint.Constant(0),
                Constraint.Constant(0));

            mainRelativeLayout.Children.Add(chart, Constraint.Constant(0), Constraint.RelativeToView(pickerStack, (parent, sibling) =>
            {
                return sibling.Y + sibling.Height;
            }),
            Constraint.RelativeToView(pickerStack, (parent, sibling) =>
            {
                return parent.Width;
            }),
            Constraint.RelativeToView(pickerStack, (parent, sibling) =>
            {
                return parent.Height - sibling.Height;
            }));
            // On Windows Phone,StackLayout and Picker will shrink automatically.
            // http://forums.xamarin.com/discussion/22436/picker-is-shrink-on-windows-phone-8
            mainRelativeLayout.SizeChanged += (s, e) =>
                {
                    pickerStack.WidthRequest = mainRelativeLayout.Width;
                };
            Content = mainRelativeLayout;

            
        }


    }
}
