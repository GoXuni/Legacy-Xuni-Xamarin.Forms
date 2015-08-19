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

[assembly: Xamarin.Forms.Dependency(typeof(Gauges101.Picture_WinPhone))]

namespace Gauges101
{
    public class Picture_WinPhone : IPicture
    {
        public async void SavePictureToDisk(string filename, byte[] imageData)
        {
            //adding a timestamp to create a unique name
            string name = filename + System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".png";

            var library = new MediaLibrary();
            try
            {

                library.SavePicture(name, imageData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
