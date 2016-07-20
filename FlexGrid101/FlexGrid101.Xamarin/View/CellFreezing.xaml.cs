using FlexGrid101.Resources;
using Xamarin.Forms;

namespace FlexGrid101
{
    public partial class CellFreezing : ContentPage
    {
        public CellFreezing()
        {
            InitializeComponent();

            Title = AppResources.CellFreezingTitle;

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
            grid.Columns["Country"].AllowMerging = true;
        }
    }
}
