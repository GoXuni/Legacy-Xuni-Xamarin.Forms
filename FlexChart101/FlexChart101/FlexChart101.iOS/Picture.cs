using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;
using System.IO;
using System.Threading.Tasks;
using FlexChartDemo.Data;
using FlexChartDemo.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(Picture_iOS))]

namespace FlexChartDemo.iOS
{
    public class Picture_iOS : IPicture
    {
        public void SavePictureToDisk(string filename, byte[] imageData)
        {
            var chartImage = new UIImage(NSData.FromArray(imageData));
            chartImage.SaveToPhotosAlbum((image, error) =>
            {
                //you can retrieve the saved UI Image as well if needed using
                //var i = image as UIImage;
                if (error != null)
                {
                    Console.WriteLine(error.ToString());
                }
            });
        }
    }
}