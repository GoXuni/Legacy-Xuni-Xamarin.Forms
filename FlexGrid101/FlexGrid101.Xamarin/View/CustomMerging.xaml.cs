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
    public partial class CustomMerging : ContentPage
    {
        public CustomMerging()
        {
            InitializeComponent();

            Title = AppResources.CustomMergingTitle;
            grid.SelectionChanged += Grid_SelectionChanged;
            if (Xuni.Forms.Core.ColorEx.IsDarkTheme)
                imgTV.Source = ImageSource.FromResource("FlexGrid101.Images.retro_TV_filled-50_dark.png");
            else
                imgTV.Source = ImageSource.FromResource("FlexGrid101.Images.retro_TV_filled-50_light.png");
			
            PopulateGrid();

        }

        private void Grid_SelectionChanged(object sender, GridCellRangeEventArgs e)
        {

            string selectedText = grid[e.CellRange.Row, e.CellRange.Column].ToString();
            labelShowName.Text = selectedText;
            labelShowTimes.Text = "";
            for (int c = 0; c < grid.Columns.Count; c++)
            {
                string dayName = grid.GetCellValue(GridCellType.ColumnHeader, new GridCellRange(0, c)).ToString();
                string startTime = "";
                for (int r = 0; r < grid.Rows.Count; r++)
                {
                    string cellValue = grid[r, c].ToString();

                    if (cellValue.Equals(selectedText))
                    {
                        if (startTime == "")
                        {
                            startTime = grid.GetCellValue(GridCellType.RowHeader, grid.Rows[r], grid.Columns[0]).ToString();
                            labelShowTimes.Text = labelShowTimes.Text + dayName + " " + startTime + "-";
                        }
                    }
                    else if (startTime != "" && labelShowTimes.Text.EndsWith("-"))
                    {
                        string endTime = grid.GetCellValue(GridCellType.RowHeader, grid.Rows[r], grid.Columns[0]).ToString();
                        labelShowTimes.Text = labelShowTimes.Text + endTime + "\n";
                    }

                    // handle last row exception
                    if (r == grid.Rows.Count - 1 && startTime != "" && labelShowTimes.Text.EndsWith("-"))
                    {
                        labelShowTimes.Text = labelShowTimes.Text + "19:00\n";
                    }
                }
            }
        }

        protected override void OnAppearing()
        {
            grid.AutoSizeColumn(0, true);
        }

        private void PopulateGrid()
        {

			grid.SetCellValue(GridCellType.RowHeader, 0, 0, "12:00");
            grid.SetCellValue(GridCellType.RowHeader, 1, 0, "13:00");
            grid.SetCellValue(GridCellType.RowHeader, 2, 0, "14:00");
            grid.SetCellValue(GridCellType.RowHeader, 3, 0, "15:00");
            grid.SetCellValue(GridCellType.RowHeader, 4, 0, "16:00");
            grid.SetCellValue(GridCellType.RowHeader, 5, 0, "17:00");
            grid.SetCellValue(GridCellType.RowHeader, 6, 0, "18:00");

            grid[0, 0] = "Walker";
            grid[0, 1] = "Morning Show";
            grid[0, 2] = "Morning Show";
            grid[0, 3] = "Sports";
            grid[0, 4] = "Weather";
            grid[0, 5] = "N/A";
            grid[0, 6] = "N/A";
            grid[1, 5] = "N/A";
            grid[1, 6] = "N/A";
            grid[2, 5] = "N/A";
            grid[2, 6] = "N/A";
            grid[3, 5] = "N/A";
            grid[3, 6] = "N/A";
            grid[4, 5] = "N/A";
            grid[4, 6] = "N/A";
            grid[1, 0] = "Today Show";
            grid[1, 1] = "Today Show";
            grid[2, 0] = "Today Show";
            grid[2, 1] = "Today Show";
            grid[1, 2] = "Sesame Street";
            grid[1, 3] = "Football";
            grid[2, 3] = "Football";
            grid[1, 4] = "Market Watch";
            grid[2, 2] = "Kids Zone";
            grid[2, 4] = "Soap Opera";
            grid[3, 0] = "News";
            grid[3, 1] = "News";
            grid[3, 2] = "News";
            grid[3, 3] = "News";
            grid[3, 4] = "News";
            grid[4, 0] = "News";
            grid[4, 1] = "News";
            grid[4, 2] = "News";
            grid[4, 3] = "News";
            grid[4, 4] = "News";
            grid[5, 0] = "Weel of Fortune";
            grid[5, 1] = "Weel of Fortune";
            grid[5, 2] = "Weel of Fortune";
            grid[5, 3] = "Jeopardy";
            grid[5, 4] = "Jeopardy";
            grid[5, 5] = "Movie";
            grid[6, 5] = "Movie";
            grid[5, 6] = "Golf";
            grid[6, 6] = "Golf";
            grid[6, 0] = "Night Show";
            grid[6, 1] = "Night Show";
            grid[6, 2] = "Sports";
            grid[6, 3] = "Big Brother";
            grid[6, 4] = "Big Brother";
        }
    }
}
