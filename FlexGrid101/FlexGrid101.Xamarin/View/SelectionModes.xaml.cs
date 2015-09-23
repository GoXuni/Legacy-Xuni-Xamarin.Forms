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
    public partial class SelectionModes : ContentPage
    {
        public SelectionModes()
        {
            InitializeComponent();

            this.Title = AppResources.SelectionModesTitle;
            foreach (var value in Enum.GetValues(typeof(GridSelectionMode)))
            {
                selectionMode.Items.Add(value.ToString());
            }
            selectionMode.SelectedIndex = selectionMode.Items.IndexOf(GridSelectionMode.CellRange.ToString());

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
        }

        private void SelectionModeChanged(object sender, EventArgs e)
        {
            grid.SelectionMode = (GridSelectionMode)Enum.Parse(typeof(GridSelectionMode), selectionMode.Items[selectionMode.SelectedIndex]);
        }

        private void OnSelectionChanging(object sender, GridCellRangeEventArgs e)
        {
            //e.Cancel = true;
        }

        private void OnSelectionChanged(object sender, GridCellRangeEventArgs e)
        {
        }
    }
}
