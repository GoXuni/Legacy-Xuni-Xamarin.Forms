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
    public static class Switches
    {
        public static StackLayout GetRotatedSwitch(FlexPie flexPie)
        {
            Label label = new Label();

            label.Text = "Reversed?";

            label.VerticalOptions = LayoutOptions.FillAndExpand;
            label.HorizontalOptions = LayoutOptions.FillAndExpand;

            Switch toggleSwitch = new Switch();

            toggleSwitch.Toggled += (e, sender) =>
            {
                Switch sentSwitch = (Switch)e;

                flexPie.Reversed = sentSwitch.IsToggled;
            };

            StackLayout stack = new StackLayout();

            stack.Orientation = StackOrientation.Horizontal;

            stack.Children.Add(label);
            stack.Children.Add(toggleSwitch);

            return stack;
        }

        public static StackLayout GetAnimatedSwitch(FlexPie flexPie)
        {
            Label label = new Label();

            label.Text = "Animated?";

            label.VerticalOptions = LayoutOptions.FillAndExpand;
            label.HorizontalOptions = LayoutOptions.FillAndExpand;

            Switch toggleSwitch = new Switch();

            toggleSwitch.IsToggled = true;

            toggleSwitch.Toggled += (e, sender) =>
            {
                Switch sentSwitch = (Switch) e;

                flexPie.IsAnimated = sentSwitch.IsToggled;
            };

            StackLayout stack = new StackLayout();

            stack.Orientation = StackOrientation.Horizontal;

            stack.Children.Add(label);
            stack.Children.Add(toggleSwitch);

            return stack;
        }
    }
}
