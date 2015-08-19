using CollectionView101.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xuni.CollectionView;

namespace CollectionView101
{
    public partial class Grouping : ContentPage
    {
        XuniGroupedCollectionView<string, YouTubeVideo> _collectionView;
        ObservableCollection<YouTubeVideo> _videos;

        public Grouping()
        {
            InitializeComponent();

            list.IsGroupingEnabled = true;
            list.GroupDisplayBinding = new Binding("Key");
            var task = UpdateVideos();
        }

        private async Task UpdateVideos()
        {
            try
            {
                message.IsVisible = false;
                list.IsVisible = false;
                activityIndicator.IsRunning = true;
                _videos = new ObservableCollection<YouTubeVideo>((await YouTubeCollectionView.LoadVideosAsync("Xamarin Forms", "relevance", null, 50)).Item2);
                _collectionView = new XuniGroupedCollectionView<string, YouTubeVideo>(_videos, v => v.ChannelTitle);
                list.ItemsSource = _collectionView;
                list.IsVisible = true;
            }
            catch
            {
                message.Text = AppResources.InternetConnectionError;
                message.IsVisible = true;
            }
            finally
            {
                activityIndicator.IsRunning = false;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is YouTubeVideo)
            {
                var video = e.Item as YouTubeVideo;
                Device.OpenUri(new Uri(video.Link));
            }
        }
    }
}
