using FlexGrid101.Resources;
using Xamarin.Forms;
using Xuni.Forms.FlexGrid;

namespace FlexGrid101
{
    public partial class ColumnDefinitions : ContentPage
    {
        public ColumnDefinitions()
        {
            InitializeComponent();

            this.Title = AppResources.ColumnDefinitionTitle;
			var data = Customer.GetCustomerList(1000);
            grid.ItemsSource = data;
            grid.Columns[5].DataMap = new GridDataMap() { ItemsSource = Customer.GetCountries(), DisplayMemberPath = "Value", SelectedValuePath = "Key" };
            grid.BeginningEdit += OnBeginningEdit;
        }

        public void OnBeginningEdit(object sender, GridCellRangeEventArgs e)
        {

        }
    }
}
