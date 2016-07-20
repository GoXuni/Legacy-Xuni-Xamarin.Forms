using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Input101.Resources;
//using Xuni.Forms.Calendar;

namespace Input101
{
    public partial class ComboBoxSample
    {
        public ComboBoxSample()
        {
            InitializeComponent();
            Title = AppResources.ComboBoxTitle;
            var array = Country.GetCountries();
            this.cbxEdit.ItemsSource = array;
            this.cbxNoneEdit.ItemsSource = array;

        }
       
    }
  
}
