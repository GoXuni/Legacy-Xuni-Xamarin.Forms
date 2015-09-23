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
    public partial class Filtering : ContentPage
    {
        XuniCollectionView<YouTubeVideo> _collectionView;

        public Filtering()
        {
            InitializeComponent();
            Title = AppResources.FilteringTitle;
            filter.Placeholder = AppResources.FilterPlaceholderText;
            var task = UpdateVideos();
        }

        private async Task UpdateVideos()
        {
            try
            {
                message.IsVisible = false;
                list.IsVisible = false;
                activityIndicator.IsRunning = true;
                var _videos = new ObservableCollection<YouTubeVideo>((await YouTubeCollectionView.LoadVideosAsync("Xamarin Forms", "relevance", null, 50)).Item2);
                _collectionView = new XuniCollectionView<YouTubeVideo>(_videos);
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
