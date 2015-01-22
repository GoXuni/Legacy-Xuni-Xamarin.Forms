using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xuni.Xamarin.Gauge;

namespace GaugeDemo
{
    public partial class GettingStarted
    {
        public GettingStarted()
        {
            InitializeComponent();

            BindingContext = new SampleViewModel() { Value = 25, ShowText = GaugeShowText.None };

            ValueLabel.Text = ValueStepper.Value.ToString("N0");
            ValueStepper.ValueChanged += ValueStepper_ValueChanged;
        }

        void ValueStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            ValueLabel.Text = e.NewValue.ToString("N0");
        }
    }
}
