using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xuni.CollectionView;

using Xamarin.Forms;
using CollectionView101.Resources;

namespace CollectionView101
{
    public partial class SimpleOnDemand : ContentPage
    {
        public SimpleOnDemand()
        {
            InitializeComponent();

            Title = AppResources.SimpleOnDemandTitle;

            // instantiate our on demand collection view
            SimpleOnDemandCollectionView myCollectionView = new SimpleOnDemandCollectionView();
            list.ItemsSource = myCollectionView;

            // start on demand loading
            list.LoadItemsOnDemand(myCollectionView);
            
        }
    }

    public class SimpleOnDemandCollectionView : XuniCursorCollectionView<MyDataItem>
    {
        public SimpleOnDemandCollectionView()
        {
            PageSize = 10;
        }

        public int PageSize { get; set; }
        protected override async Task<Tuple<string, IReadOnlyList<MyDataItem>>> GetPageAsync(string pageToken, int? count = null)
        {
            // create new page of items
            var newItems = new List<MyDataItem>();
            for (int i = 0; i < this.PageSize; i++)
            {
                newItems.Add(new MyDataItem(this.Count + i));
            }

            return new Tuple<string, IReadOnlyList<MyDataItem>>("token not used", newItems);
        }
    }
    public class MyDataItem
    {
        public MyDataItem(int index)
        {
            this.ItemName = "My Data Item #" + index.ToString();
            this.ItemDateTime = DateTime.Now;
        }
        public string ItemName { get; set; }
        public DateTime ItemDateTime { get; set; }

    }
}
