using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CalendarCustomHeader
{
    public partial class CalendarPage : TabbedPage
    {
        public CalendarPage()
        {
            InitializeComponent();
            Xuni.Forms.Core.LicenseManager.Key = License.Key;
            this.Title = "Xuni Calendar";
        }
    }
}
