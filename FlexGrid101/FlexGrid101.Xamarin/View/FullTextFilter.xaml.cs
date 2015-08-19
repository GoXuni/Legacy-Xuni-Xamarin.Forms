using FlexGrid101.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlexGrid101
{
    public partial class FullTextFilter : ContentPage
    {
        public FullTextFilter()
        {
            InitializeComponent();

            lblTitle.Text = AppResources.FullTextFilterTitle;
            filter.Placeholder = AppResources.FilterPlaceholderText;

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
        }
    }
}
