using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xuni.Forms.FlexGrid;

namespace FlexGrid101
{
    public partial class ConditionalFormatting : ContentPage
    {
        public ConditionalFormatting()
        {
            InitializeComponent();

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
            var countries = Customer.GetCountries().Select((name, index) => new KeyValuePair<int, string>(index, name)).ToList();
            grid.Columns[4].DataMap = new GridDataMap() { ItemsSource = countries, DisplayMemberPath = "Value", SelectedValuePath = "Key" };

            grid.CellFactory = new MyCellFactory();
        }
    }

    public class MyCellFactory : GridCellFactory
    {
        ///
        /// Override CreateCell to customize the cell frame/gridlines
        ///
        //public override GridCellView CreateCell(GridCellType cellType, GridCellRange range)
        //{
        //    if (cellType == GridCellType.Cell && range.Column == 3)
        //    {
        //        var cell = new GridCellView();
        //        cell.BackgroundColor = Color.Green;
        //        cell.BorderThickness = new Thickness(0, 0, Grid.GridLinesWidth, Grid.GridLinesWidth);
        //        cell.BorderColor = cellType == GridCellType.Cell ? Grid.GridLinesColor : Grid.HeadersGridLinesColor;
        //        cell.Padding = Grid.CellPadding;
        //        return cell;
        //    }
        //    else
        //    {
        //        return base.CreateCell(cellType, range);
        //    }
        //}

        ///
        /// Override BindCellContent to customize the cell content
        /// 
        public override void BindCellContent(GridCellType cellType, GridCellRange range, View cellContent)
        {
            base.BindCellContent(cellType, range, cellContent);
            if (cellType == GridCellType.Cell && cellType != GridCellType.ColumnHeader && range.Column == 3)
            {
                var label = cellContent as Label;
                if (label != null)
                {
                    var originalText = label.Text;
                    double cellValue;
                    if (double.TryParse(originalText, out cellValue))
                    {
                        label.TextColor = cellValue < 70.0 ? Color.Red : Color.Green;
                        label.Text = String.Format("{0:n2}", cellValue);
                    }
                }
            }
        }

        ///
        /// Override CreateCellContent to return your own custom view as a cell
        ///
        //public override View CreateCellContent(GridCellType cellType, GridCellRange range, object cellContentType)
        //{
        //    if(cellType == GridCellType.Cell)
        //    {
        //        if (Grid.Columns.Count > range.Column)
        //        {
        //            var r = Grid.Rows[range.Row];
        //            var c = Grid.Columns[range.Column];
        //            return base.CreateCellContent(cellType, range, cellContentType);
        //        }
        //        return null;
        //    }
        //    else if (cellType == GridCellType.ColumnHeader)
        //    {
        //        return new Label();
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
