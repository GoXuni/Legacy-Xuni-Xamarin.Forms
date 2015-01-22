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
    public class LegendAndTitlesSample : BaseSample
    {
        public LegendAndTitlesSample(PieChartSample chartSample)
            : base()
        {
            FlexPie chart = PieChartSampleFactory.GetFlexChartSample(chartSample);

            chart.HeaderText = EntryInputs.headerText;
            chart.HeaderFont = Font.SystemFontOfSize(30);
            chart.HeaderTextColor = Color.FromHex("#666666");

            chart.FooterText = EntryInputs.footerText;
            chart.FooterFont = Font.SystemFontOfSize(15);
            chart.FooterTextColor = Color.FromHex("#666666");

            chart.Legend.Position = Xuni.Xamarin.ChartCore.ChartPositionType.Bottom;

            RelativeLayout mainRelativeLayout = new RelativeLayout();

            WrapLayout stepperStack = new WrapLayout();

            stepperStack.Orientation = StackOrientation.Horizontal;

            Entry headerEntry = new Entry();

            headerEntry.VerticalOptions = LayoutOptions.FillAndExpand;
            headerEntry.HorizontalOptions = LayoutOptions.FillAndExpand;

            stepperStack.Children.Add(EntryInputs.getHeaderEntry(chart));
            stepperStack.Children.Add(EntryInputs.getFooterEntry(chart));
            stepperStack.Children.Add(Pickers.GetLegendPositionPicker(chart));

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
