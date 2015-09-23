using Gauges101.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xuni.Forms.Gauge;

namespace Gauges101
{
    public partial class DisplayingValues
    {
        public DisplayingValues()
        {
            InitializeComponent();
            Title = AppResources.DisplayingValuesTitle;

            BindingContext = new SampleViewModel() { Max = 1, Value = .25, Step = .01, Format = "P0", ShowRanges = false };
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
