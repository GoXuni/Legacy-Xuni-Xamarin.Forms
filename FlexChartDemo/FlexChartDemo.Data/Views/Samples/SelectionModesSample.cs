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
    public class SelectionModesSample : BaseSample
    {
        public SelectionModesSample(ChartSample chartSample)
            : base()
        {
            FlexChart chart = ChartSampleFactory.GetFlexChartSample(chartSample);

            chart.SelectedBorderColor = Color.FromRgb(255, 0, 0);
            chart.SelectedBorderWidth = 3;
            chart.SelectedDashes = new double[] { 20, 10 };
            RelativeLayout mainRelativeLayout = new RelativeLayout();

            WrapLayout pickerStack = new WrapLayout();

            pickerStack.Orientation = StackOrientation.Horizontal;

            Picker chartType = Pickers.GetChartTypePicker(chart);
            Picker selectionType = Pickers.GetSelectionModeTypePicker(chart);
            chartType.SelectedIndex = 0;
            selectionType.SelectedIndex = 1;

            pickerStack.Children.Add(chartType);
            pickerStack.Children.Add(selectionType);

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
