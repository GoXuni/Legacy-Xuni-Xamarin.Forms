using FlexGrid101.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xuni.Forms.FlexGrid;

namespace FlexGrid101
{
    public partial class ColumnDefinitions : ContentPage
    {
        public ColumnDefinitions()
        {
            InitializeComponent();

            lblTitle.Text = AppResources.ColumnDefinitionTitle;

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
            var countries = Customer.GetCountries().Select((name, index) => new KeyValuePair<int, string>(index, name)).ToList();
            grid.Columns[4].DataMap = new GridDataMap() { ItemsSource = countries, DisplayMemberPath = "Value", SelectedValuePath = "Key" };
        }
    }
}
