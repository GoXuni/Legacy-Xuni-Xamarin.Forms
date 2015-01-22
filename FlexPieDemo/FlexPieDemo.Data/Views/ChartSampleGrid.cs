using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using FlexPieDemo.Data.Repo;
using FlexPieDemo.Data.Chart;
using FlexPieDemo.Data.Views;

namespace FlexPieDemo.Data.Views
{
    public class TransparentImageCell : ImageCell
    {
    }

    public class ChartSampleGrid : ContentPage
    {
        ListView listView;

        public ChartSampleGrid()
        {
            this.Title = "Xuni FlexPie";
            BackgroundColor = Color.FromHex("#333333");

            FlexPieDemo.Data.Views.Common.Utility.CheckNavBar(this);

            List<PieChartSample> chartSampleList = new XmlRepository().GetPieChartSamples();

            listView = new ListView
            {
                ItemsSource = chartSampleList,
                ItemTemplate = new DataTemplate(typeof(TransparentImageCell))
                {
                    Bindings =
                    {
                        { ImageCell.TextProperty, new Binding("Name") },
                        { ImageCell.DetailProperty, new Binding("Description") },
                        { ImageCell.ImageSourceProperty, new Binding("ThumbnailImageSource") }
                    }
                }
            };

            listView.ItemSelected += async (sender, args) =>
            {
                if (args.SelectedItem != null)
                    await this.Navigation.PushAsync(ChartSampleViewFactory.GetChartContentPage((PieChartSample)args.SelectedItem));
            };

            Content = listView;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (listView != null)
            {
                listView.SelectedItem = null;
            }
        }
    }
}
