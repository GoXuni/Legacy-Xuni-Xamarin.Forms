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

            this.Title = AppResources.ColumnDefinitionTitle;
            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
            grid.Columns[5].DataMap = new GridDataMap() { ItemsSource = Customer.GetCountries(), DisplayMemberPath = "Value", SelectedValuePath = "Key" };
            grid.BeginningEdit += OnBeginningEdit;
        }

        public void OnBeginningEdit(object sender, GridCellRangeEventArgs e)
        {

        }
    }
}
