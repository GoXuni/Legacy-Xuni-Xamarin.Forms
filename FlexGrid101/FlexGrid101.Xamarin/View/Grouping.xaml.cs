using FlexGrid101.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xuni.CollectionView;
using Xuni.Forms.FlexGrid;

namespace FlexGrid101
{
    public partial class Grouping : ContentPage
    {
        XuniGroupedCollectionView<string, Customer> _collectionView;

        public Grouping()
        {
            InitializeComponent();

            toolbarItemCollapse.Text = AppResources.Collapse;
            toolbarItemSort.Text = AppResources.Sort;

            this.Title = AppResources.GroupingTitle;
            //grid.IsGroupingEnabled = true;
            grid.GroupDisplayBinding = new Binding("Key");
            grid.SelectionChanging += OnSelectionChanging;

            var task = UpdateVideos();


        }

        private async Task UpdateVideos()
        {
            var data = Customer.GetCustomerList(100);
            _collectionView = new XuniGroupedCollectionView<string, Customer>(c => c.Country);
            //grid.ItemsSource = _collectionView;
            await _collectionView.SetSourceAsync(data);
            grid.ItemsSource = _collectionView; // iOS needs this to be called after SetSourceAsync
            _collectionView.SortChanged += OnSortChanged;
            UpdateSortButton();
        }

        private async void OnSortClicked(object sender, EventArgs e)
        {
            if (_collectionView != null)
            {
                var direction = GetCurrentSortDirection();
                await _collectionView.SortAsync(x => x.Name, direction == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending);
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
            var direction = GetCurrentSortDirection();
            if (direction == SortDirection.Ascending)
            {
                toolbarItemSort.Icon = Device.OnPlatform<FileImageSource>(null, new FileImageSource() { File = "ic_sort_descending.png" }, new FileImageSource() { File = "Assets/AppBar/appbar.sort.alphabetical.descending.png" });
            }
            else
            {
                toolbarItemSort.Icon = Device.OnPlatform<FileImageSource>(null, new FileImageSource() { File = "ic_sort_ascending.png" }, new FileImageSource() { File = "Assets/AppBar/appbar.sort.alphabetical.ascending.png" });
            }
        }

        private SortDirection GetCurrentSortDirection()
        {
            var sort = _collectionView.SortDescriptions.FirstOrDefault(sd => sd.SortPath == "Name");
            return sort != null ? sort.Direction : SortDirection.Descending;
        }

        public void OnSelectionChanging(object sender, GridCellRangeEventArgs e)
        {
            if (e.CellType == GridCellType.Cell || e.CellType == GridCellType.RowHeader)
            {
                var row = grid.Rows[e.CellRange.Row] as GridGroupRow;
                if (row != null)
                     e.Cancel = true;   
            }   
        } 
    } 
}
