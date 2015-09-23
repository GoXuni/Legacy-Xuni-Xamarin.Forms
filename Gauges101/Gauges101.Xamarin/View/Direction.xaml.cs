using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xuni.Forms.Gauge;
using Xamarin.Forms;
using Gauges101.Resources;

namespace Gauges101
{
    public partial class Direction
    {
        public Direction()
        {
            InitializeComponent();
            Title = AppResources.DirectionTitle;

            BindingContext = new SampleViewModel() { Value = 80 };

            directionPicker.SelectedIndexChanged += directionPicker_SelectedIndexChanged;
        }

        void directionPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = directionPicker.Items [directionPicker.SelectedIndex];
            
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            //Populates show text picker, beause the property Items is not bindable.
            var viewModel = BindingContext as SampleViewModel;
            directionPicker.Items.Clear();
            foreach (var directionType in viewModel.DirectionItems)
            {
                directionPicker.Items.Add(directionType);
            }
            directionPicker.SelectedIndex = viewModel.DirectionSelectedIndex;
            viewModel.ShowTextSelectedIndex = 0;
        }
    }
}
