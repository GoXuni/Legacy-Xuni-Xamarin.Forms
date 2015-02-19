using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xuni.Xamarin.Gauge;
using Xamarin.Forms;

namespace Gauges101
{
    public partial class Direction
    {
        public Direction()
        {
            InitializeComponent();

            BindingContext = new SampleViewModel() { Value = 80 };

            directionPicker.SelectedIndexChanged += directionPicker_SelectedIndexChanged;
        }

        void directionPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = directionPicker.Items [directionPicker.SelectedIndex];
            if (item == LinearGaugeDirection.Down.ToString() || item == LinearGaugeDirection.Up.ToString()) {
                bulletGraph.VerticalOptions = LayoutOptions.FillAndExpand;
            } else {
                bulletGraph.VerticalOptions = LayoutOptions.Start;
            }
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
