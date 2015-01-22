using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using Xuni.Xamarin.Core;

using Xuni.Xamarin.FlexPie;

using Xuni.Xamarin.ChartCore;

namespace FlexPieDemo.Data.Views.Common
{
    public static class Pickers
    {
        public static StackLayout GetSelectedItemPositionPicker(FlexPie chart)
        {
            StackLayout stack = new StackLayout();

            stack.Orientation = StackOrientation.Horizontal;

            Label label = new Label();

            label.Text = "Selected Item Position";

            Picker picker = new Picker();

            picker.VerticalOptions = LayoutOptions.FillAndExpand;
            picker.HorizontalOptions = LayoutOptions.FillAndExpand;
            picker.Title = "Selected Item Position";

            picker.Items.Add("None");
            picker.Items.Add("Left");
            picker.Items.Add("Top");
            picker.Items.Add("Right");
            picker.Items.Add("Bottom");

            picker.SelectedIndex = 2;

            picker.SelectedIndexChanged += (e, sender) =>
            {
                Picker sentPicker = (Picker)e;

                ChartPositionType legendPoistion = ChartPositionType.Bottom;

                switch (sentPicker.SelectedIndex)
                {
                    case 0:
                        legendPoistion = ChartPositionType.None;
                        break;
                    case 1:
                        legendPoistion = ChartPositionType.Left;
                        break;
                    case 2:
                        legendPoistion = ChartPositionType.Top;
                        break;
                    case 3:
                        legendPoistion = ChartPositionType.Right;
                        break;
                    case 4:
                        legendPoistion = ChartPositionType.Bottom;
                        break;
                }

                chart.SelectedItemPosition = legendPoistion;
            };

            stack.Children.Add(label);
            stack.Children.Add(picker);

            return stack;

        }

        public static Picker GetLegendPositionPicker(FlexPie chart)
        {
            Picker picker = new Picker();

            picker.VerticalOptions = LayoutOptions.FillAndExpand;
            picker.HorizontalOptions = LayoutOptions.FillAndExpand;
            picker.Title = "Legend Position";

            
            picker.Items.Add("None");
            picker.Items.Add("Left");
            picker.Items.Add("Top");
            picker.Items.Add("Right");
            picker.Items.Add("Bottom");

            picker.SelectedIndex = 4;

            picker.SelectedIndexChanged += (e, sender) =>
            {
                Picker sentPicker = (Picker)e;

                ChartPositionType legendPoistion = ChartPositionType.Bottom;

                switch (sentPicker.SelectedIndex)
                {
                    case 0:
                        legendPoistion = ChartPositionType.None;
                        break;
                    case 1:
                        legendPoistion = ChartPositionType.Left;
                        break;
                    case 2:
                        legendPoistion = ChartPositionType.Top;
                        break;
                    case 3:
                        legendPoistion = ChartPositionType.Right;
                        break;
                    case 4:
                        legendPoistion = ChartPositionType.Bottom;
                        break;
                }

                chart.Legend.Position = legendPoistion;
            };

            return picker;

        }

        public static Picker GetPalettePicker(FlexPie chart)
        {
            Picker picker = new Picker();

            picker.VerticalOptions = LayoutOptions.FillAndExpand;
            picker.HorizontalOptions = LayoutOptions.FillAndExpand;
            picker.Title = "Palette";

            picker.Items.Add("standard");
            picker.Items.Add("cocoa");
            picker.Items.Add("coral");
            picker.Items.Add("dark");
            picker.Items.Add("highconstrast");
            picker.Items.Add("light");
            picker.Items.Add("midnight");
            picker.Items.Add("minimal");
            picker.Items.Add("modern");
            picker.Items.Add("organic");
            picker.Items.Add("slate");

            picker.SelectedIndexChanged += (e, sender) =>
            {
                Picker sentPicker = (Picker)e;

                Color[] palette = null;

                switch (sentPicker.SelectedIndex)
                {
                    case 0:
                        palette = Palettes.Standard;
                        break;
                    case 1:
                        palette = Palettes.Cocoa;
                        break;
                    case 2:
                        palette = Palettes.Coral;
                        break;
                    case 3:
                        palette = Palettes.Dark;
                        break;
                    case 4:
                        palette = Palettes.HighContrast;
                        break;
                    case 5:
                        palette = Palettes.Light;
                        break;
                    case 6:
                        palette = Palettes.Midnight;
                        break;
                    case 7:
                        palette = Palettes.Minimal;
                        break;
                    case 8:
                        palette = Palettes.Modern;
                        break;
                    case 9:
                        palette = Palettes.Organic;
                        break;
                    case 10:
                        palette = Palettes.Slate;
                        break;
                }

                if(palette != null)
                {
                    chart.Palette = palette;
                }
            };

            return picker;

        }
    }
}
