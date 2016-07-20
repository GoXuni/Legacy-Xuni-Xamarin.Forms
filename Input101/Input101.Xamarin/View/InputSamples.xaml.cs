using Input101.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Input101
{
    public partial class InputSamples : ContentPage
    {
        public InputSamples()
        {
            InitializeComponent();

            Title = "Input101";

            BindingContext = GetSamples();
        }

        private List<Sample> GetSamples()
        {
            return new List<Sample>
            {
                new Sample() { Name = AppResources.AutoCompleteTitle, Description = AppResources.AutoCompleteDescription, SampleViewType = 1 , Thumbnail = "input_autocomplete.png" },
                new Sample() { Name = AppResources.ComboBoxTitle, Description = AppResources.ComboBoxDescription, SampleViewType = 2 , Thumbnail = "input_combobox.png" },
                new Sample() { Name = AppResources.DropDownTitle, Description = AppResources.DropDownDescription, SampleViewType = 3 , Thumbnail = "input_dropdown.png" },
                new Sample() { Name = AppResources.MaskedEntryTitle, Description = AppResources.MaskedEntryDescription, SampleViewType = 4 , Thumbnail = "input_mask.png" },
            };
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var sample = e.Item as Sample;
            await this.Navigation.PushAsync(GetSample(sample.SampleViewType));
        }

        private Page GetSample(int sampleViewType)
        {
            switch (sampleViewType)
            {
                case 1: return new AutoCompleteSample();
                case 2: return new ComboBoxSample();
                case 3: return new DropDownSample();
                case 4: return new MaskedEntrySample();
            }
            return null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (listView != null)
            {
                listView.SelectedItem = null;
            }
        }
    }
}
