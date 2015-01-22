using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace FlexChartDemo.Data.Chart
{
    public class ChartSample
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int SampleDataType { get; set; }

        public int SampleViewType { get; set; }

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
                ThumbnailImageSource = ImageSource.FromResource("FlexChartDemo.Data.Images." + value); //ImageSource.FromUri(new Uri(value));
            }
        }
        [XmlIgnore]
        public ImageSource ThumbnailImageSource { get; private set; }
    }
}
