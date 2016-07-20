using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Input101
{
    public class Country
    {
        public static readonly string[] Countries= { "Germany",  "Japan", "Australia","Bangladesh", "Brazil","Canada","China","France","India","Nepal","Pakistan","Srilanka"};
        public string Name { get; set; }
        public static List<Country> GetCountries()
        {
            List<Country> listContries = new List<Country>();
            
            foreach (var item in Countries)
            {
                listContries.Add(new Country() { Name = item });
            }
            return listContries;
        }
    }
    public class FlagConverter : IValueConverter
    {

        Dictionary<string, ImageSource> flags = new Dictionary<string, ImageSource>();
        public FlagConverter()
        {
            for (int i = 0; i < Country.Countries.Length; i++)
            {
                string strFlag = Country.Countries[i];
				flags.Add(strFlag, ImageSource.FromResource(string.Format("Input101.Images.{0}.png", strFlag.ToLower())));
            }
        }
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return flags[value.ToString()];
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            return null;
        }
    }

}
