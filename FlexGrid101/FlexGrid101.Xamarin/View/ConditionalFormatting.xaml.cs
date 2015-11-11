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
    public partial class ConditionalFormatting : ContentPage
    {
        public ConditionalFormatting()
        {
            InitializeComponent();
            this.Title = AppResources.ConditionalFormattingTitle;
            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
            grid.Columns[5].DataMap = new GridDataMap() { ItemsSource = Customer.GetCountries(), DisplayMemberPath = "Value", SelectedValuePath = "Key" };

            grid.CellFactory = new MyCellFactory();
        }
    }

    public class MyCellFactory : GridCellFactory
    {
        /// <summary>
        /// Creates the cell.
        /// </summary>
        /// <param name="cellType">Type of the cell.</param>
        /// <param name="range">The range.</param>
        /// <returns></returns>
        public override GridCellView CreateCell(GridCellType cellType, GridCellRange range)
        {
            var cell = base.CreateCell(cellType, range);
            if (cellType == GridCellType.Cell && range.Column == 4)
            {
                var cellValue = Grid[range.Row, range.Column] as int?;
                if (cellValue.HasValue)
                {
                    cell.BackgroundColor = cellValue < 50.0 ? Color.Red : Color.Green;
                }
            }
            return cell;
        }

        /// <summary>
        /// Binds the content of the cell.
        /// </summary>
        /// <param name="cellType">Type of the cell.</param>
        /// <param name="range">The range.</param>
        /// <param name="cellContent">Content of the cell.</param>
        public override void BindCellContent(GridCellType cellType, GridCellRange range, View cellContent)
        {
            base.BindCellContent(cellType, range, cellContent);
            if (cellType == GridCellType.Cell && range.Column == 3)
            {
                var label = cellContent as Label;
                if (label != null)
                {
                    var cellValue = Grid[range.Row, range.Column] as double?;
                    if (cellValue.HasValue)
                    {
                        label.TextColor = cellValue < 5000.0 ? Color.Red : Color.Green;
                    }
                }
            }
            if (cellType == GridCellType.Cell && range.Column == 4)
            {
                var label = cellContent as Label;
                if (label != null)
                {
                    var cellValue = Grid[range.Row, range.Column] as int?;
                    if (cellValue.HasValue)
                    {
                        label.BackgroundColor = cellValue < 50 ? Color.Red : Color.Green;
                    }
                }
            }
        }
    }
}
