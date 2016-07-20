using FlexGrid101.Resources;
using Xamarin.Forms;

namespace FlexGrid101
{
    public partial class StarSizing : ContentPage
    {
        public StarSizing()
        {
            InitializeComponent();

            Title = AppResources.StarSizingTitle;

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
        }
    }
}
