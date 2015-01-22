using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xuni.Xamarin.Gauge;

namespace GaugeDemo
{
    public partial class DisplayingValues
    {
        public DisplayingValues()
        {
            InitializeComponent();

            BindingContext = new SampleViewModel() { Value = 25, ShowRanges = false };
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            //Populates show text picker, beause the property Items is not bindable.
            var viewModel = BindingContext as SampleViewModel;
            showItemsPicker.Items.Clear();
            foreach (var showTextItem in viewModel.ShowTextItems)
            {
                showItemsPicker.Items.Add(showTextItem);
            }
            viewModel.ShowTextSelectedIndex = 0;
        }
    }
}
