using FlexGrid101.Resources;
using Xamarin.Forms;

namespace FlexGrid101
{
    public partial class CustomCells : ContentPage
    {
        public CustomCells()
        {
            InitializeComponent();

            this.Title = AppResources.CustomCellsTitle;
            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
        }
    }
}
