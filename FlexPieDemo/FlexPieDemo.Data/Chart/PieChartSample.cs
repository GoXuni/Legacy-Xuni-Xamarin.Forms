using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin.Forms;


namespace FlexPieDemo.Data.Chart
{
    public class PieChartSample
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int PieChartSampleDataType { get; set; } 

        public int PieChartSampleViewType { get; set; }

        private string _thumbnailImage { get; set; }

        public string ThumbnailImage
        {
            get
            {
                return _thumbnailImage;
            }
            set
            {
                _thumbnailImage = value;
                ThumbnailImageSource = ImageSource.FromResource("FlexPieDemo.Data.Images." + value); //ImageSource.FromUri(new Uri(value));
            }
        }
        [XmlIgnore]
        public ImageSource ThumbnailImageSource { get; private set; }
    }
}
