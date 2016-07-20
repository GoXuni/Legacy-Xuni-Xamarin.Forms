using FlexGrid101.Resources;
using System;
using Xamarin.Forms;
using Xuni.CollectionView;
using Xuni.Forms.FlexGrid;

namespace FlexGrid101
{
    public partial class GettingStarted : ContentPage
    {
        private XuniCollectionView<Customer> _collView;


        public GettingStarted()
        {
            InitializeComponent();
            this.Title = AppResources.GettingStartedTitle;

            grid.AutoGeneratingColumn += OnAutoGeneratingColumn;
            var data = Customer.GetCustomerList(100);
            _collView = new XuniCollectionView<Customer>(data);
            grid.ItemsSource = _collView;
			//grid.SelectionChanged += OnSelectionChanged;
			//_collView.CurrentChanged += OnCurrentChanged;
        
            Appearing += OnAppearing;
        }

        private void OnAppearing(object sender, EventArgs e)
        {
            //grid.AutoSizeColumns(0, grid.Columns.Count - 1);
            //grid.AutoSizeRows(0, grid.Rows.Count - 1)
        } 

        private void OnAutoGeneratingColumn(object sender, GridAutoGeneratingColumnEventArgs e)
        {
            if (e.Property.Name == "Country" || e.Property.Name == "Name" || e.Property.Name == "OrderAverage")
            {
                //Avoids generating these columns
                e.Cancel = true;
            }
            else if (e.Property.Name == "Id")
            {
                e.Column.IsReadOnly = true;
            }
            else if (e.Property.Name == "CountryId")
            {
                //Sets the DataMap to the country column so a picker is used to select the country.
                e.Column.Header = "Country";
                e.Column.HorizontalAlignment = LayoutAlignment.Start;
                e.Column.DataMap = new GridDataMap() { ItemsSource = Customer.GetCountries(), DisplayMemberPath = "Value", SelectedValuePath = "Key" };
            } 
            else if (e.Property.Name == "OrderTotal" || e.Property.Name == "OrderAverage")
            {
                //Sets currency format the these columns
                e.Column.Format = "C";
            }
            else if (e.Property.Name == "LastOrderDate")
            {
                //Replaces the column so that the editor is a date-picker instead of an entry.
                e.Column = new GridDateTimeColumn(e.Property);
            }
            else if (e.Property.Name == "Address")
            {
                e.Column.WordWrap = true;
            }


        }

        private void OnFirstClicked(object sender, EventArgs e)
        {
            _collView.MoveCurrentToFirst();
        }

        private void OnPreviousClicked(object sender, EventArgs e)
        {
            _collView.MoveCurrentToPrevious();
        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            _collView.MoveCurrentToNext();
        }

        private void OnLastClicked(object sender, EventArgs e)
        {
            _collView.MoveCurrentToLast();
        }

        void OnCurrentChanged(object sender, EventArgs e)
        {
            if (grid.Selection == null)
                return;

            if (grid.Selection.Row != _collView.CurrentPosition)
            {
                grid.Selection = new GridCellRange(_collView.CurrentPosition, -1);
            }
        }

        void OnSelectionChanged(object sender, EventArgs e)
        {
            if (grid.Selection.Row != _collView.CurrentPosition)
            {
                _collView.MoveCurrentToPosition(grid.Selection.Row);
            }
        }
    }


}
