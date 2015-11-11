using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexPieDemo.Data
{
    public interface IPicture
    {
        void SavePictureToDisk(string filename, byte[] imageData);

    }
}
