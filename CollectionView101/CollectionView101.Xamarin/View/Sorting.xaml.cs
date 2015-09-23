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
    public partial class Sorting : ContentPage
    {
        XuniCollectionView<YouTubeVideo> _collectionView;
        ObservableCollection<YouTubeVideo> _videos;

        public Sorting()
        {
            InitializeComponent();
            Title = AppResources.SortingTitle;
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
                _collectionView = new XuniCollectionView<YouTubeVideo>(_videos);
                list.ItemsSource = _collectionView;
                list.IsVisible = true;
                _collectionView.SortChanged += OnSortChanged;
                UpdateSortButton();
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

        void OnSortChanged(object sender, EventArgs e)
        {
            UpdateSortButton();
        }

        async void OnSortClicked(object sender, EventArgs e)
        {
            if (_collectionView != null)
            {
                var direction = GetCurrentSortDirection();
                await _collectionView.SortAsync(x => x.Title, direction == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending);
            }
        }

        private void UpdateSortButton()
        {
            ToolbarItem sortButton = ToolbarItems.FirstOrDefault(t => t.Text == "Sort");
            var direction = GetCurrentSortDirection();
            if (direction == SortDirection.Ascending)
            {
                sortButton.Icon = Device.OnPlatform<FileImageSource>(null, new FileImageSource() { File = "ic_sort_descending.png" }, new FileImageSource() { File = "Assets/AppBar/appbar.sort.alphabetical.descending.png" });
            }
            else
            {
                sortButton.Icon = Device.OnPlatform<FileImageSource>(null, new FileImageSource() { File = "ic_sort_ascending.png" }, new FileImageSource() { File = "Assets/AppBar/appbar.sort.alphabetical.ascending.png" });
            }
        }

        private SortDirection GetCurrentSortDirection()
        {
            var sort = _collectionView.SortDescriptions.FirstOrDefault(sd => sd.SortPath == "Title");
            return sort != null ? sort.Direction : SortDirection.Descending;
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
