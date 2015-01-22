using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using Xuni.Xamarin.FlexChart;
using Xuni.Xamarin.ChartCore;

namespace FlexChartDemo.Data.Views.Common
{
    public static class Pickers
    {
        public static Picker GetSelectionModeTypePicker(FlexChart chart)
        {
            Picker picker = new Picker();

            picker.VerticalOptions = LayoutOptions.FillAndExpand;
            picker.HorizontalOptions = LayoutOptions.FillAndExpand;
            picker.Title = "Selection Type";

            picker.Items.Add("None");
            picker.Items.Add("Point");
            picker.Items.Add("Series");

            picker.SelectedIndexChanged += (e, sender) =>
            {
                Picker sentPicker = (Picker)e;

                ChartSelectionModeType selectionModeTypeEnum = ChartSelectionModeType.None;

                switch (sentPicker.SelectedIndex)
                {
                    case 0:
                        selectionModeTypeEnum = ChartSelectionModeType.None;
                        break;
                    case 1:
                        selectionModeTypeEnum = ChartSelectionModeType.Point;
                        break;
                    case 2:
                        selectionModeTypeEnum = ChartSelectionModeType.Series;
                        break;
                }

                if (chart.SelectionMode != selectionModeTypeEnum)
                {
                    chart.SelectionMode = selectionModeTypeEnum;
                }
            };

            return picker;

        }

        public static Picker GetChartTypePicker(FlexChart chart)
        {
            Picker picker = new Picker();

            picker.VerticalOptions = LayoutOptions.CenterAndExpand;
            picker.HorizontalOptions = LayoutOptions.FillAndExpand;
            picker.Title = "Chart Type";

            picker.Items.Add("Column");
            picker.Items.Add("Bar");
            picker.Items.Add("Scatter");
            picker.Items.Add("Line");
            picker.Items.Add("LineSymbols");
            picker.Items.Add("Area");

            picker.SelectedIndexChanged += (e, sender) =>
            {
                Picker sentPicker = (Picker)e;

                ChartType chartTypeEnum = ChartType.Column;

                switch (sentPicker.SelectedIndex)
                {
                    case 0:
                        chartTypeEnum = ChartType.Column;
                        break;
                    case 1:
                        chartTypeEnum = ChartType.Bar;
                        break;
                    case 2:
                        chartTypeEnum = ChartType.Scatter;
                        break;
                    case 3:
                        chartTypeEnum = ChartType.Line;
                        break;
                    case 4:
                        chartTypeEnum = ChartType.LineSymbol;
                        break;
                    case 5:
                        chartTypeEnum = ChartType.Area;
                        break;
                }

                if(chart.ChartType != chartTypeEnum)
                {
                    chart.ChartType = chartTypeEnum;
                }
            };

            return picker;
        }

        public static Picker GetChartStackingTypePicker(FlexChart chart)
        {
            Picker picker = new Picker();

            picker.VerticalOptions = LayoutOptions.FillAndExpand;
            picker.HorizontalOptions = LayoutOptions.FillAndExpand;
            picker.Title = "Stacking Type";

            picker.Items.Add("None");
            picker.Items.Add("Stacked");
            picker.Items.Add("Stacked 100%");

            picker.SelectedIndexChanged += (e, sender) =>
            {
                Picker sentPicker = (Picker)e;

                ChartStackingType stackingTypeEnum = ChartStackingType.None;

                switch (sentPicker.SelectedIndex)
                {
                    case 0:
                        stackingTypeEnum = ChartStackingType.None;
                        break;
                    case 1:
                        stackingTypeEnum = ChartStackingType.Stacked;
                        break;
                    case 2:
                        stackingTypeEnum = ChartStackingType.Stacked100pc;
                        break;
                }

                if(chart.Stacking != stackingTypeEnum)
                {
                    chart.Stacking = stackingTypeEnum;
                }
            };

            return picker;

        }

        public static Picker GetChartRotationTypePicker(FlexChart chart)
        {
            Picker picker = new Picker();

            picker.VerticalOptions = LayoutOptions.FillAndExpand;
            picker.HorizontalOptions = LayoutOptions.FillAndExpand;
            picker.Title = "Rotated";

            picker.Items.Add("False");
            picker.Items.Add("True");

            picker.SelectedIndexChanged += (e, sender) =>
            {
                Picker sentPicker = (Picker)e;

                Boolean rotated = false;

                if (sentPicker.SelectedIndex == 1)
                {
                    rotated = true;
                }

                if (chart.Rotated != rotated)
                {
                    chart.Rotated = rotated;
                }
            };

            return picker;

        }
    }
}
