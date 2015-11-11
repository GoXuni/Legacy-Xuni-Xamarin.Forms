using FlexGrid101.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlexGrid101
{
    public partial class OnDemand : ContentPage
    {
        YouTubeCollectionView _collectionView;

        public OnDemand()
        {
            InitializeComponent();

            this.Title = AppResources.OnDemandTitle;
            search.Placeholder = AppResources.SearchPlaceholderText;
            emptyListLabel.Text = AppResources.EmptyListText;

            _collectionView = new YouTubeCollectionView() { PageSize = 25 };
            grid.ItemsSource = _collectionView;
            orderBy.Items.Add("relevance");
            orderBy.Items.Add("date");
            orderBy.Items.Add("viewCount");
            orderBy.Items.Add("rating");
            orderBy.Items.Add("title");
            orderBy.SelectedIndex = 0;
            search.Text = "Xamarin.Forms";
            var task = PerformSearch();
        }

        private async void OnCompleted(object sender, EventArgs e)
        {
            await PerformSearch();
            grid.Focus();
        }

        private async Task PerformSearch()
        {
            try
            {
                activityIndicator.IsRunning = true;
                grid.Focus();
                await _collectionView.SearchAsync(search.Text);
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
    }
}
