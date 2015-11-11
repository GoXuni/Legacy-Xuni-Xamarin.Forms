using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.Runtime.InteropServices.WindowsRuntime;

[assembly: Xamarin.Forms.Dependency(typeof(FlexGrid101.WinPhone.FileSystem))]
namespace FlexGrid101.WinPhone
{
    public class FileSystem : IFileSystem
    {
        public async Task SaveFileToDisk(string fileName, string data)
        {
            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, Windows.Storage.CreationCollisionOption.ReplaceExisting);
            using (var transaction = await file.OpenTransactedWriteAsync())
            {
                await transaction.Stream.WriteAsync(UTF8Encoding.UTF8.GetBytes(data).AsBuffer());
                await transaction.CommitAsync();
            }
        }

        public async Task<string> ReadFileFromDisk(string fileName)
        {
            try
            {
                var file = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                if (file != null)
                {
                    using (var stream = await file.OpenStreamForReadAsync())
                    {
                        var reader = new StreamReader(stream);
                        return await reader.ReadToEndAsync();
                    }
                }
            }
            catch { }
            return null;
        }
    }
}
