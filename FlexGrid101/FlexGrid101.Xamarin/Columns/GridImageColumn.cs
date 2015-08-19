using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xuni.Core;
using Xuni.Forms.FlexGrid;

namespace FlexGrid101
{
    public class GridImageColumn : GridColumn
    {
        protected override object GetCellContentType()
        {
            return typeof(Image);
        }

        protected override View CreateCellContent(object cellContentType)
        {
            return new Image();
        }

        protected override void BindCellContent(View cellContent, GridRow row)
        {
            var dataItem = row.DataItem;
            var image = cellContent as Image;
            if (image != null && dataItem != null)
            {
                var value = GetCellValue(row);
                image.Source = new ImageConverter().Convert(value, typeof(ImageSource), null, CultureInfo.InvariantCulture) as ImageSource;
                //image.SetBinding(Image.SourceProperty, new Binding(Binding, converter: new ImageConverter(), source: dataItem));
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
            else if(value is Uri)
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
