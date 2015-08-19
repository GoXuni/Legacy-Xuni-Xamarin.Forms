using FlexGrid101.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xuni.CollectionView;

namespace FlexGrid101
{
    public partial class Grouping : ContentPage
    {
        XuniGroupedCollectionView<string, YouTubeVideo> _collectionView;
        ObservableCollection<YouTubeVideo> _videos;

        public Grouping()
        {
            InitializeComponent();

            toolbarItemCollapse.Text = AppResources.Collapse;
            toolbarItemSort.Text = AppResources.Sort;
            lblTitle.Text = AppResources.GroupingTitle;

            //grid.IsGroupingEnabled = true;
            grid.GroupDisplayBinding = new Binding("Key");
            var task = UpdateVideos();
        }

        private async Task UpdateVideos()
        {
            try
            {
                activityIndicator.IsRunning = true;
                emptyListLabel.IsVisible = false;
                grid.IsVisible = false;
                message.IsVisible = false;

                _videos = new ObservableCollection<YouTubeVideo>((await YouTubeCollectionView.LoadVideosAsync("Xamarin Forms", "relevance", null, 50)).Item2);
                _collectionView = new XuniGroupedCollectionView<string, YouTubeVideo>(v => v.Snippet.ChannelTitle);
				grid.ItemsSource = _collectionView;
                await _collectionView.SetSourceAsync(_videos);
                _collectionView.SortChanged += OnSortChanged;
                UpdateSortButton();
            }
            catch
            {
                message.Text = "There was a problem when trying to get the data from internet. \nPlease check your internet connection";
                message.IsVisible = true;
            }
            finally
            {
                activityIndicator.IsRunning = false;
            }
        }

        private async void OnSortClicked(object sender, EventArgs e)
        {
            if (_collectionView != null)
            {
                var direction = GetCurrentSortDirection();
                await _collectionView.SortAsync(x => x.Snippet.Title, direction == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending);
            }
        }

        private void OnCollapseClicked(object sender, EventArgs e)
        {
            grid.CollapseGroups();
        }

        void OnSortChanged(object sender, EventArgs e)
        {
            UpdateSortButton();
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
            var sort = _collectionView.SortDescriptions.FirstOrDefault(sd => sd.SortPath == "Snippet.Title");
            return sort != null ? sort.Direction : SortDirection.Descending;
        }
    }
}
