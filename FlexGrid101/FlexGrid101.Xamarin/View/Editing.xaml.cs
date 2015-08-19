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
    public partial class Editing : ContentPage
    {
        GridCellRange selectedRange;
        public Editing()
        {
            InitializeComponent();

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
            grid.HeadersVisibility = GridHeadersVisibility.All;
            grid.SelectionChanged += grid_SelectionChanged;
            grid.IsReadOnly = true;

            toolbarItemEdit.Text = AppResources.EditRow;
            lblTitle.Text = AppResources.EditingTitle;
        }

        void grid_SelectionChanged(object sender, GridCellRangeEventArgs e)
        {
            this.selectedRange = e.CellRange;
        }

        private async void OnEditButtonClicked(object sender, EventArgs e)
        {
            if (this.selectedRange != null)
            {
                Customer c = grid.Rows[this.selectedRange.Row].DataItem as Customer;
                if(c != null)
                    await Navigation.PushModalAsync(new EditCustomerForm(c));
            }

        }

    }
}
