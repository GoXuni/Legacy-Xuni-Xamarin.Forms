using System;
using System.Globalization;
using Xamarin.Forms;
using Xuni.Forms.FlexGrid;

namespace FlexGrid101
{
    public class GridImageColumn : GridColumn
    {
        protected override object GetCellContentType(GridCellType cellType)
        {
            if (cellType == GridCellType.Cell)
                return typeof(Image);
            else
                return base.GetCellContentType(cellType);
        }

        protected override View CreateCellContent(GridCellType cellType, object cellContentType)
        {
            if (cellType == GridCellType.Cell)
                return new Image();
            else
                return base.CreateCellContent(cellType, cellContentType);
        }

        protected override void BindCellContent(View cellContent, GridCellType cellType, GridRow row)
        {
            if (cellType == GridCellType.Cell)
            {
                var dataItem = row.DataItem;
                var image = cellContent as Image;
                if (image != null && dataItem != null)
                {
                    var value = GetCellValue(cellType, row);
                    image.Source = new ImageConverter().Convert(value, typeof(ImageSource), null, CultureInfo.InvariantCulture) as ImageSource;
                    //image.SetBinding(Image.SourceProperty, new Binding(Binding, converter: new ImageConverter(), source: dataItem));
                }
            }
            else
            {
                base.BindCellContent(cellContent, cellType, row);
            }
        }
    }

    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string && Uri.IsWellFormedUriString(value as string, UriKind.RelativeOrAbsolute))
            {
                return ImageSource.FromUri(new Uri(value as string));
            }
            else if (value is Uri)
            {
                return ImageSource.FromUri(value as Uri);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
