using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin;
using Xamarin.Forms;

using Xuni.Xamarin.FlexPie;

namespace FlexPieDemo.Data.Views.Common
{
    public static class Steppers
    {
        public static StackLayout GetSelectedOffsetStepper(FlexPie flexPie)
        {
            Label label = new Label();

            label.Text = "Selected Item Offset";

            label.VerticalOptions = LayoutOptions.FillAndExpand;
            label.HorizontalOptions = LayoutOptions.FillAndExpand;

            Label value = new Label();

            value.Text = "0.2";

            value.VerticalOptions = LayoutOptions.FillAndExpand;
            value.HorizontalOptions = LayoutOptions.FillAndExpand;

            StackLayout labelStack = new StackLayout();

            labelStack.Orientation = StackOrientation.Vertical;

            labelStack.Children.Add(label);
            labelStack.Children.Add(value);

            Stepper stepper = new Stepper();

            stepper.VerticalOptions = LayoutOptions.FillAndExpand;
            stepper.HorizontalOptions = LayoutOptions.FillAndExpand;

            stepper.Value = 0.2;
            stepper.Increment = .10;
            stepper.Minimum = 0;
            stepper.Maximum = .50;

            stepper.ValueChanged += (e, sender) =>
            {
                Stepper sentStepper = (Stepper)e;

                value.Text = String.Format("{0:F1}", sentStepper.Value);

                flexPie.SelectedItemOffset = sentStepper.Value;
            };

            StackLayout stack = new StackLayout();

            stack.Orientation = StackOrientation.Horizontal;

            stack.Children.Add(labelStack);
            stack.Children.Add(stepper);

            return stack;
        }

        public static StackLayout GetInnerRadiusStepper(FlexPie flexPie)
        {
            Label label = new Label();

            label.Text = "Inner Radius";

            label.VerticalOptions = LayoutOptions.FillAndExpand;
            label.HorizontalOptions = LayoutOptions.FillAndExpand;

            Label value = new Label();

            value.Text = "0.3";

            value.VerticalOptions = LayoutOptions.FillAndExpand;
            value.HorizontalOptions = LayoutOptions.FillAndExpand;

            StackLayout labelStack = new StackLayout();

            labelStack.Orientation = StackOrientation.Vertical;

            labelStack.Children.Add(label);
            labelStack.Children.Add(value);

            Stepper stepper = new Stepper();

            stepper.VerticalOptions = LayoutOptions.FillAndExpand;
            stepper.HorizontalOptions = LayoutOptions.FillAndExpand;

            stepper.Value = 0.3;
            stepper.Increment = .10;
            stepper.Minimum = 0;
            stepper.Maximum = 1.00;

            stepper.ValueChanged += (e, sender) =>
            {
                Stepper sentStepper = (Stepper)e;

                value.Text = String.Format("{0:F1}", sentStepper.Value);

                flexPie.InnerRadius =sentStepper.Value;
            };

            StackLayout stack = new StackLayout();

            stack.Orientation = StackOrientation.Horizontal;

            stack.Children.Add(labelStack);
            stack.Children.Add(stepper);

            return stack;
        }

        public static StackLayout GetStartAngleStepper(FlexPie flexPie)
        {
            Label label = new Label();

            label.Text = "StartAngle";

            label.VerticalOptions = LayoutOptions.FillAndExpand;
            label.HorizontalOptions = LayoutOptions.FillAndExpand;

            Label value = new Label();

            value.Text = "0";

            value.VerticalOptions = LayoutOptions.FillAndExpand;
            value.HorizontalOptions = LayoutOptions.FillAndExpand;

            StackLayout labelStack = new StackLayout();

            labelStack.Orientation = StackOrientation.Vertical;

            labelStack.Children.Add(label);
            labelStack.Children.Add(value);

            Stepper stepper = new Stepper();

            stepper.VerticalOptions = LayoutOptions.FillAndExpand;
            stepper.HorizontalOptions = LayoutOptions.FillAndExpand;

            stepper.Increment = 45;
            stepper.Minimum = 0;
            stepper.Maximum = 360;

            stepper.ValueChanged += (e, sender) =>
            {
                Stepper sentStepper = (Stepper)e;

                if (sentStepper.Value > 0)
                {
                    value.Text = sentStepper.Value.ToString();
                }
                else
                {
                    value.Text = "0";
                }

                flexPie.StartAngle = sentStepper.Value;
            };

            StackLayout stack = new StackLayout();

            stack.Orientation = StackOrientation.Horizontal;

            stack.Children.Add(labelStack);
            stack.Children.Add(stepper);

            return stack;
        }

        public static StackLayout GetOffsetStepper(FlexPie flexPie)
        {
            Label label = new Label();

            label.Text = "Offset";

            label.VerticalOptions = LayoutOptions.FillAndExpand;
            label.HorizontalOptions = LayoutOptions.FillAndExpand;

            Label value = new Label();

            value.Text = "0.0";

            value.VerticalOptions = LayoutOptions.FillAndExpand;
            value.HorizontalOptions = LayoutOptions.FillAndExpand;

            StackLayout labelStack = new StackLayout();

            labelStack.Orientation = StackOrientation.Vertical;

            labelStack.Children.Add(label);
            labelStack.Children.Add(value);

            Stepper stepper = new Stepper();

            stepper.VerticalOptions = LayoutOptions.FillAndExpand;
            stepper.HorizontalOptions = LayoutOptions.FillAndExpand;

            stepper.Increment = .10;
            stepper.Minimum = 0;
            stepper.Maximum = 1.00;

            stepper.ValueChanged += (e, sender) =>
            {
                Stepper sentStepper = (Stepper)e;

                if (sentStepper.Value > 0)
                {
                    value.Text = sentStepper.Value.ToString();
                }
                else
                {
                    value.Text = "0.0";
                }

                flexPie.Offset = sentStepper.Value;
            };

            StackLayout stack = new StackLayout();

            stack.Orientation = StackOrientation.Horizontal;

            stack.Children.Add(labelStack);
            stack.Children.Add(stepper);

            return stack;
        }
    }
}
