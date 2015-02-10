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
    public static class EntryInputs
    {
        public static string headerText = "Fruit By Value";
        public static string footerText = "2014 GrapeCity, inc.";

        public static StackLayout getHeaderEntry(FlexPie chart)
        {
            Label label = new Label();

            label.VerticalOptions = LayoutOptions.FillAndExpand;
            label.HorizontalOptions = LayoutOptions.FillAndExpand;

            label.Text = "Header";

            Entry entry = new Entry();

            entry.Text = headerText;

            entry.VerticalOptions = LayoutOptions.FillAndExpand;
            entry.HorizontalOptions = LayoutOptions.FillAndExpand;

            entry.TextChanged += (e, sender) =>
            {
                Entry sentEntry = (Entry) e;

                chart.HeaderText = sentEntry.Text;
            };

            StackLayout stack = new StackLayout();

            stack.Orientation = StackOrientation.Vertical;

            stack.Children.Add(label);
            stack.Children.Add(entry);

            return stack;
        }

        public static StackLayout getFooterEntry(FlexPie chart)
        {
            Label label = new Label();

            label.VerticalOptions = LayoutOptions.FillAndExpand;
            label.HorizontalOptions = LayoutOptions.FillAndExpand;

            label.Text = "Footer";

            Entry entry = new Entry();

            entry.Text = footerText;

            entry.VerticalOptions = LayoutOptions.FillAndExpand;
            entry.HorizontalOptions = LayoutOptions.FillAndExpand;

            entry.TextChanged += (e, sender) =>
            {
                Entry sentEntry = (Entry)e;

                chart.FooterText = sentEntry.Text;
            };

            StackLayout stack = new StackLayout();

            stack.Orientation = StackOrientation.Vertical;

            stack.Children.Add(label);
            stack.Children.Add(entry);

            return stack;
        }
    }
}
