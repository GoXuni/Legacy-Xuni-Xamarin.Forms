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
