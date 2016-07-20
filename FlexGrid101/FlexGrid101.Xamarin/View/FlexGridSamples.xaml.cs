using FlexGrid101.Resources;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FlexGrid101
{
    public partial class FlexGridSamples : ContentPage
    {
        public FlexGridSamples()
        {
            InitializeComponent();
            BindingContext = GetSamples();
            this.Title = "FlexGrid101";
        }

        private List<Sample> GetSamples()
        {
            return new List<Sample>
            {
                new Sample() { Name = AppResources.GettingStartedTitle, Description = AppResources.GettingStartedDescription, SampleViewType = 1 , Thumbnail="flexgrid.png"},
                new Sample() { Name = AppResources.ColumnDefinitionTitle, Description = AppResources.ColumnDefinitionDescription, SampleViewType = 2 , Thumbnail="flexgrid_columns.png"},
                new Sample() { Name = AppResources.SelectionModesTitle, Description = AppResources.SelectionModesDescription, SampleViewType = 3 , Thumbnail="flexgrid_selection.png"},
                new Sample() { Name = AppResources.EditConfirmationTitle, Description = AppResources.EditConfirmationDescription, SampleViewType = 4 , Thumbnail="flexgrid.png"},
                new Sample() { Name = AppResources.EditingTitle, Description = AppResources.EditingDescription, SampleViewType = 5 , Thumbnail="input_form.png"},
                new Sample() { Name = AppResources.ConditionalFormattingTitle, Description = AppResources.ConditionalFormattingDescription, SampleViewType = 6 , Thumbnail="flexgrid.png"},
                new Sample() { Name = AppResources.CustomCellsTitle, Description = AppResources.CustomCellsDescription, SampleViewType = 7 , Thumbnail="flexgrid_custom.png"},
                new Sample() { Name = AppResources.GroupingTitle, Description = AppResources.GroupingDescription, SampleViewType = 8 , Thumbnail="flexgrid_grouping.png"},
                new Sample() { Name = AppResources.RowDetailsTitle, Description = AppResources.RowDetailsDescription, SampleViewType = 9 , Thumbnail="flexgrid_rowdetails.png"},
                new Sample() { Name = AppResources.FilterTitle, Description = AppResources.FilterDescription, SampleViewType = 10 , Thumbnail="flexgrid_filter.png"},
                new Sample() { Name = AppResources.FullTextFilterTitle, Description = AppResources.FullTextFilterDescription, SampleViewType = 11 , Thumbnail="filter.png"},
                new Sample() { Name = AppResources.ColumnLayoutTitle, Description = AppResources.ColumnLayoutDescription, SampleViewType = 12 , Thumbnail="flexgrid_columns.png"},
                new Sample() { Name = AppResources.StarSizingTitle, Description = AppResources.StarSizingDescription, SampleViewType = 13 , Thumbnail="flexgrid.png"},
                new Sample() { Name = AppResources.CellFreezingTitle, Description = AppResources.CellFreezingDescription, SampleViewType = 14 , Thumbnail="flexgrid_freezing.png"},
                new Sample() { Name = AppResources.CustomMergingTitle, Description = AppResources.CustomMergingDescription, SampleViewType = 15 , Thumbnail="flexgrid_merging.png"},
                new Sample() { Name = AppResources.UnboundTitle, Description = AppResources.UnboundDescription, SampleViewType = 16 , Thumbnail="flexgrid_headers.png"},
                new Sample() { Name = AppResources.OnDemandTitle, Description = AppResources.OnDemandDescription, SampleViewType = 17 , Thumbnail="flexgrid_loading.png"},


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
                case 1: return new GettingStarted();
                case 2: return new ColumnDefinitions();
                case 3: return new SelectionModes();
                case 4: return new EditConfirmation();
                case 5: return new Editing();
                case 6: return new ConditionalFormatting();
                case 7: return new CustomCells();
                case 8: return new Grouping();
                case 9: return new RowDetails();
                case 10: return new Filter();
                case 11: return new FullTextFilter();
                case 12: return new ColumnLayout();
                case 13: return new StarSizing();
                case 14: return new CellFreezing();
                case 15: return new CustomMerging();
                case 16: return new Unbound();
                case 17: return new OnDemand();
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
