using FlexGrid101.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlexGrid101
{
    public partial class CustomCells : ContentPage
    {
        public CustomCells()
        {
            InitializeComponent();

            lblTitle.Text = AppResources.CustomCellsTitle;

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
        }
    }
}
