using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(FlexGrid101.Android.FileSystem))]
namespace FlexGrid101.Android
{
    public class FileSystem : IFileSystem
    {
        public async Task SaveFileToDisk(string fileName, string data)
        {
            var dir = Application.Context.FilesDir;
            var file = new Java.IO.File(dir, fileName);
            if (!file.Exists())
                file.CreateNewFile();
            using (var stream = System.IO.File.Open(file.AbsolutePath, System.IO.FileMode.Truncate, System.IO.FileAccess.ReadWrite))
            {
                var buffer = UTF8Encoding.UTF8.GetBytes(data);
                await stream.WriteAsync(buffer, 0, buffer.Length);
                await stream.FlushAsync();
            }
        }

        public async Task<string> ReadFileFromDisk(string fileName)
        {
            var dir = Application.Context.FilesDir;
            var file = new Java.IO.File(dir, fileName);
            if (file.Exists())
            {
                using (var stream = System.IO.File.Open(file.AbsolutePath, System.IO.FileMode.Open, FileAccess.Read))
                {
                    var reader = new StreamReader(stream);
                    return await reader.ReadToEndAsync();
                }
            }
            return null;
        }
    }
}