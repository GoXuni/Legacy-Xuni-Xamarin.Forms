using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;
using System.Windows.Media.Imaging;
using Microsoft.Xna.Framework.Media;
using System.IO.IsolatedStorage;
using FlexPieDemo.Data;
using FlexPieDemo.WinPhone;


[assembly: Xamarin.Forms.Dependency(typeof(Picture_WinPhone))]

namespace FlexPieDemo.WinPhone
{
    public class Picture_WinPhone : IPicture
    {
        public async void SavePictureToDisk(string filename, byte[] imageData)
        {
            //adding a timestamp to create a unique name
            string name = filename + System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";

            //this could also be accomplished with a guid instead
            //var tempName = Guid.NewGuid().ToString();

            var store = IsolatedStorageFile.GetUserStoreForApplication();
            var bitmapImage = new BitmapImage();
            var memoryStream = new MemoryStream(imageData);
            bitmapImage.SetSource(memoryStream);
            WriteableBitmap b = new WriteableBitmap(bitmapImage);
            using (var fileStream = store.CreateFile(name))
            {
                Extensions.SaveJpeg(b, fileStream, b.PixelWidth, b.PixelHeight, 0, 100);
            }
            using (var fileStream = store.OpenFile(name, FileMode.Open, FileAccess.Read))
            {
                var library = new MediaLibrary();
                try
                {
                    library.SavePicture(filename, fileStream);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
