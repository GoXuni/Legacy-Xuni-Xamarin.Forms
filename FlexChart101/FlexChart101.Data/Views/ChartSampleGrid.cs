using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using FlexChartDemo.Data.Repo;
using FlexChartDemo.Data.Chart;
using FlexChartDemo.Data.Views;

namespace FlexChartDemo.Data.Views
{
	public class TransparentImageCell : ImageCell
	{
	}

    public class ChartSampleGrid : ContentPage
    {
        ListView listView;

        public ChartSampleGrid()
        {
            this.Title = "FlexChart101";

            //FlexChartDemo.Data.Views.Common.Utility.CheckNavBar(this);

            List<ChartSample> chartSampleList = new XmlRepository().GetChartSamples();

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
                    },
                    Values = 
                    {
                        { ImageCell.TextColorProperty, Color.FromHex("#B00F50")},
                        { ImageCell.DetailColorProperty, Color.Gray},
                    }
                }
            };

			listView.ItemSelected += async (sender, args) =>
                {
                    if (args.SelectedItem != null)
                    await this.Navigation.PushAsync(ChartSampleViewFactory.GetChartContentPage((ChartSample)args.SelectedItem));
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
