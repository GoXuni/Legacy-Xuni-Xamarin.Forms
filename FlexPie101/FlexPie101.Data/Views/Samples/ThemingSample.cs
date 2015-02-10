using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;

using Xuni.Xamarin.FlexPie;

using FlexPieDemo.Data.Chart;
using FlexPieDemo.Data.Views.Common;

namespace FlexPieDemo.Data.Views.Samples
{
    public class ThemingSample : BaseSample
    {
        public ThemingSample(PieChartSample chartSample)
            : base()
        {
            FlexPie chart = PieChartSampleFactory.GetFlexChartSample(chartSample);
 
            RelativeLayout mainRelativeLayout = new RelativeLayout();

            WrapLayout stepperStack = new WrapLayout();

            stepperStack.Orientation = StackOrientation.Horizontal;


            Picker picker = Pickers.GetPalettePicker(chart);
            stepperStack.Children.Add(picker);

            mainRelativeLayout.Children.Add(stepperStack, Constraint.Constant(0),
                Constraint.Constant(0));

            mainRelativeLayout.Children.Add(chart, Constraint.Constant(0), Constraint.RelativeToView(stepperStack, (parent, sibling) =>
            {
                return sibling.Y + sibling.Height;
            }),
           Constraint.RelativeToView(stepperStack, (parent, sibling) =>
           {
               return parent.Width;
           }),
           Constraint.RelativeToView(stepperStack, (parent, sibling) =>
           {
               return parent.Height - sibling.Height;
           }));
            // On Windows Phone,StackLayout and Picker will shrink automatically.
            // http://forums.xamarin.com/discussion/22436/picker-is-shrink-on-windows-phone-8
            mainRelativeLayout.SizeChanged += (s, e) =>
            {
                picker.WidthRequest = mainRelativeLayout.Width;
            };

            Content = mainRelativeLayout;
        }
    }
}
