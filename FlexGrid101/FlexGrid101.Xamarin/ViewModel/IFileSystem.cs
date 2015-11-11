using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexGrid101
{
    public interface IFileSystem
    {
        Task SaveFileToDisk(string fileName, string data);
        Task<string> ReadFileFromDisk(string fileName);
    }
}
