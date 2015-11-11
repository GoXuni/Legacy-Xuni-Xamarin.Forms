using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;



[assembly: Xamarin.Forms.Dependency(typeof(FlexGrid101.iOS.FileSystem))]
namespace FlexGrid101.iOS
{
    public class FileSystem : IFileSystem
    {
        public async Task SaveFileToDisk(string fileName, string data)
        {
			var dir = Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData);
			var file = Path.GetFullPath(Path.Combine (dir, fileName));

			if (!System.IO.File.Exists (file)) {
				System.IO.File.WriteAllText(file, "dummy");
			}

			using (var stream = System.IO.File.Open(file, System.IO.FileMode.Truncate, System.IO.FileAccess.ReadWrite))
			{
				var buffer = UTF8Encoding.UTF8.GetBytes(data);
				await stream.WriteAsync(buffer, 0, buffer.Length);
				await stream.FlushAsync();
			}
        }

        public async Task<string> ReadFileFromDisk(string fileName)
        {
			var dir = Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData);
			var file = Path.GetFullPath(Path.Combine (dir, fileName));

			if (System.IO.File.Exists (file)) {
				using (var stream = System.IO.File.Open(file, System.IO.FileMode.Open, FileAccess.Read))
				{
					var reader = new StreamReader(stream);
					return await reader.ReadToEndAsync();
				}
			}

			return null;
        }
    }
}
