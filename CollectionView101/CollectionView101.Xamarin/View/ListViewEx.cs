using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xuni.CollectionView;

namespace CollectionView101
{
    public static class ListViewEx
    {
        public static void LoadItemsOnDemand<T>(this ListView listview, XuniCursorCollectionView<T> collectionView) where T : class
        {
            listview.ItemAppearing += (s, e) =>
            {
                var index = collectionView.IndexOf((T)e.Item);
                if (index == collectionView.Count - 1)
                {
                    if (collectionView.HasMoreItems)
                    {
                        collectionView.LoadMoreItemsAsync();
                    }
                }
            };
            listview.Refreshing += async (s, e) =>
            {
                listview.IsRefreshing = true;
                await collectionView.RefreshAsync();
                listview.IsRefreshing = false;
            };
            listview.IsPullToRefreshEnabled = true;
            if (collectionView.HasMoreItems)
            {
                collectionView.LoadMoreItemsAsync();
            }
        }
    }
}
