using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin;
using Xamarin.Forms;

using Xuni.Xamarin.FlexChart;

using FlexChartDemo.Data.Chart;

namespace FlexChartDemo.Data.Views.Samples
{
    public class ToggleSeriesSample : BaseSample
    {
        private FlexChart chart;

        private Switch salesSwitch;
        private Switch expensesSwitch;
        private Switch downloadsSwitch;

        public ToggleSeriesSample(ChartSample chartSample)
            : base()
        {
            chart = ChartSampleFactory.GetFlexChartSample(chartSample);

            chart.LegendToggle = true;

            chart.SeriesVisibilityChanged += chart_SeriesVisibilityChanged;

            RelativeLayout mainRelativeLayout = new RelativeLayout();

            StackLayout pickerStack = new StackLayout();

            pickerStack.Orientation = StackOrientation.Vertical;

            salesSwitch = new Switch();
            salesSwitch.IsToggled = true;
            salesSwitch.Toggled += sales_Toggled;

            pickerStack.Children.Add(GetSwitchAndLabel("Sales", salesSwitch));

            expensesSwitch = new Switch();
            expensesSwitch.IsToggled = true;
            expensesSwitch.Toggled += expenses_Toggled;

            pickerStack.Children.Add(GetSwitchAndLabel("Expenses", expensesSwitch));

            downloadsSwitch = new Switch();
            downloadsSwitch.IsToggled = true;
            downloadsSwitch.Toggled += downloads_Toggled;

            pickerStack.Children.Add(GetSwitchAndLabel("Downloads", downloadsSwitch));

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

        void chart_SeriesVisibilityChanged(object sender, ChartSeriesEventArgs e)
        {
            ChartSeries series = e.Series;

            bool value = false;

            if (series.Visibility == Xuni.Xamarin.FlexChart.ChartSeriesVisibilityType.Visibile)
            {
                value = true;
            }

            if (series.Name == "Sales" && salesSwitch.IsToggled != value)
            {
                salesSwitch.IsToggled = value;
            }
            else if (series.Name == "Expenses" && expensesSwitch.IsToggled != value)
            {
                expensesSwitch.IsToggled = value;
            }
            else if (series.Name == "Downloads" && downloadsSwitch.IsToggled != value)
            {
                downloadsSwitch.IsToggled = value;
            }
        }


        private StackLayout GetSwitchAndLabel(string text, Switch switchh)
        {
            StackLayout stack = new StackLayout();

            stack.Orientation = StackOrientation.Horizontal;

            Label label = new Label();
            label.Text = text;

            stack.Children.Add(label);
            stack.Children.Add(switchh);

            return stack;
        }

        void sales_Toggled(object sender, ToggledEventArgs e)
        {
            UpdateSeriesVisibility(0, e.Value);
        }

        void expenses_Toggled(object sender, ToggledEventArgs e)
        {
            UpdateSeriesVisibility(1, e.Value);
        }

        void downloads_Toggled(object sender, ToggledEventArgs e)
        {
            UpdateSeriesVisibility(2, e.Value);
        }

        private void UpdateSeriesVisibility(int index, bool value)
        {
            if (chart != null && chart.Series != null)
            {
                if (value)
                {
                    chart.Series.ToList()[index].Visibility = Xuni.Xamarin.FlexChart.ChartSeriesVisibilityType.Visibile;
                }
                else
                {
                    chart.Series.ToList()[index].Visibility = Xuni.Xamarin.FlexChart.ChartSeriesVisibilityType.Legend;
                }
            }
        }
    }
}
