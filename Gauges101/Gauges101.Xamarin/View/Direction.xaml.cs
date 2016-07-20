using Gauges101.Resources;
using System;
using Xamarin.Forms;

namespace Gauges101
{
    public partial class Direction : ContentPage
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
            string item = directionPicker.Items[directionPicker.SelectedIndex];

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
