using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GaugeDemo
{
    public class GaugeSamples : ContentPage
    {
        private ListView listView;

        public GaugeSamples()
        {
            this.Title = "Gauges 101";

            List<Sample> sampleList = new XmlRepository().GetSamples();

            listView = new ListView
            {
                ItemsSource = sampleList,
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
                    {
                        var sample =args.SelectedItem as Sample;
                        await this.Navigation.PushAsync(GetSample(sample.SampleViewType));
                    }
                };

            Content = listView;
        }

        private Page GetSample(int sampleViewType)
        {
            switch (sampleViewType)
            {
                case 0: return new GettingStarted();
                case 1: return new DisplayingValues();
                case 2: return new UsingRanges();
                case 3: return new AutomaticScaling();
                case 4: return new Direction();
                case 5: return new BulletGraph();
                case 6: return new CustomAnimation();
            }
            return null;
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

    public class TransparentImageCell : ImageCell
    {
    }
}
