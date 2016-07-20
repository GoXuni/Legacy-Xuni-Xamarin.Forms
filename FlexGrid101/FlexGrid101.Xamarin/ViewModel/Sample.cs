using Xamarin.Forms;

namespace FlexGrid101
{
    public class Sample
    {
        public string Name { get; set; }

        public int SampleViewType { get; set; }

        public string Description { get; set; }

        public string Thumbnail { get; set;}

        public ImageSource ThumbnailImageSource
        {
            get
            {
                return ImageSource.FromResource("FlexGrid101.Images." + Thumbnail);
            }
        }
    }
}
