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
    public partial class EditConfirmation : ContentPage
    {
        public EditConfirmation()
        {
            InitializeComponent();

            Title = AppResources.EditConfirmationTitle;

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
        }

        private object _originalValue;
		private int row;
		private int column;

        private void OnBeginningEdit(object sender, GridCellRangeEventArgs e)
        {
            _originalValue = grid[e.CellRange.Row, e.CellRange.Column];
			row = e.CellRange.Row;
			column = e.CellRange.Column;
        }

        private void OnCellEditEnded(object sender, GridCellRangeEventArgs e)
        {
            DisplayAlert(AppResources.EditConfirmationQuestionTitle, AppResources.EditConfirmationQuestion, AppResources.Apply, AppResources.Cancel).ContinueWith(t =>
            {
                if (!t.Result)
                {
					grid[row, column] = _originalValue;
                    grid.Refresh(range: e.CellRange);
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
