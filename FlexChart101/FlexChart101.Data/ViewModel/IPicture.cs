using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexChartDemo.Data
{
    public interface IPicture
    {
        void SavePictureToDisk(string filename, byte[] imageData);

    }
}
