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
    public class SelectionSample : BaseSample
    {
        public SelectionSample(PieChartSample chartSample)
            : base()
        {
            FlexPie chart = PieChartSampleFactory.GetFlexChartSample(chartSample);
            chart.SelectionMode = Xuni.Xamarin.ChartCore.ChartSelectionModeType.Point;
            chart.SelectedItemOffset = .2;
            chart.SelectedDashes = new double[] { 20, 10 };
            chart.SelectedBorderColor = Color.FromRgb(255, 0, 0);
            chart.SelectedBorderWidth = 3;

          
            chart.SelectedItemPosition = Xuni.Xamarin.ChartCore.ChartPositionType.Top;
            chart.IsAnimated = true;

            RelativeLayout mainRelativeLayout = new RelativeLayout();

            WrapLayout stepperStack = new WrapLayout();

            stepperStack.Orientation = StackOrientation.Horizontal;

            stepperStack.Children.Add(Steppers.GetSelectedOffsetStepper(chart));
            stepperStack.Children.Add(Pickers.GetSelectedItemPositionPicker(chart));
            stepperStack.Children.Add(Switches.GetAnimatedSwitch(chart));

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
                stepperStack.WidthRequest = mainRelativeLayout.Width;
            };

            Content = mainRelativeLayout;
        }
    }
}
