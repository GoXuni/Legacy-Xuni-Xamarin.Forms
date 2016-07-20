using FlexGrid101.Resources;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlexGrid101
{
    public partial class FilterForm : ContentPage
    {
        private TaskCompletionSource<bool> _completion;

        public FilterForm()
        {
            InitializeComponent();
            Filters = new ObservableCollection<StringFilter>();
            Filters.CollectionChanged += OnFiltersChanged;
            btnFilter.Text = AppResources.Filter;
            btnCancel.Text = AppResources.Cancel;
        }

        protected override bool OnBackButtonPressed()
        {
            if (_completion != null)
                _completion.TrySetCanceled();
            return base.OnBackButtonPressed();
        }
        
        public ObservableCollection<StringFilter> Filters { get; set; }

        private async void FilterClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
            _completion.TrySetResult(true);
        }

        private async void CancelClicked(object sender, EventArgs e)
        {
            if (_completion != null)
                _completion.TrySetCanceled();
            // close pop-up without saving anything
            await Navigation.PopModalAsync();
        }

        void OnFiltersChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    filters.Children.Add(e.NewItems[0] as View);
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Remove:
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }

        public async Task ShowAsync(INavigation navigation)
        {
            _completion = new TaskCompletionSource<bool>();
            await navigation.PushModalAsync(this, true);
            await _completion.Task;
        }
    }
}
