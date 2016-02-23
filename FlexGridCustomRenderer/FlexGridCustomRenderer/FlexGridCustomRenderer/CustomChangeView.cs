using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlexGridCustomRenderer
{
    public class CustomChangeView : View
    {
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(propertyName: "Value", returnType: typeof(double), declaringType: typeof(double), defaultValue: 0.0);

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

    }
}
