using CollectionView101.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xuni.CollectionView;

namespace CollectionView101
{
    public partial class OnDemand: ContentPage
    {
        YouTubeCollectionView _collectionView;

        public OnDemand()
        {
            InitializeComponent();

            _collectionView = new YouTubeCollectionView();
            list.ItemsSource = _collectionView;
            list.LoadItemsOnDemand(_collectionView);
            orderBy.Items.Add("relevance");
            orderBy.Items.Add("date");
            orderBy.Items.Add("viewCount");
            orderBy.Items.Add("rating");
            orderBy.Items.Add("title");
        }

        private async void OnCompleted(object sender, EventArgs e)
        {
            try
            {
                message.IsVisible = false;
                list.IsVisible = false;
                activityIndicator.IsRunning = true;
                await _collectionView.SearchAsync(search.Text);
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

        private async void OrderByChanged(object sender, EventArgs e)
        {
            try
            {
                activityIndicator.IsRunning = true;
                await _collectionView.OrderAsync(orderBy.Items[orderBy.SelectedIndex]);
            }
            finally
            {
                activityIndicator.IsRunning = false;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var video = e.Item as YouTubeVideo;
            Device.OpenUri(new Uri(video.Link));
        }
    }
}
