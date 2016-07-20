using Gauges101.Resources;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xuni.Forms.Core;
using Xuni.Forms.Gauge;

namespace Gauges101
{
    public partial class Snapshot : ContentPage
    {
        private Random _rand = new Random();
        private uint _stepDuration = 4000;

        public Snapshot()
        {
            InitializeComponent();
            Title = AppResources.ExportImageTitle;

            BindingContext = new SampleViewModel() { Value = 25, ShowText = GaugeShowText.All };
            snapshotFrameBorder.IsVisible = false;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                snapshotFrameBorder.IsVisible = false;
            };
            snapshotFrameBorder.GestureRecognizers.Add(tapGestureRecognizer);
            gauge.UpdateAnimation.Duration = _stepDuration;
        }

        async void OnSnapshotClicked(object sender, EventArgs e)
        {
            var image = gauge.GetImage();
            snapshot.Source = ImageSource.FromStream(() => new MemoryStream(image));
            await Task.Delay(100);
            snapshotFrameBorder.BackgroundColor = ColorEx.ThemeForegroundColor;
            snapshotFrame.BackgroundColor = ColorEx.ThemeBackgroundColor;
            snapshotFrameBorder.IsVisible = true;
        }

        async void OnSaveSnapshotClicked(object sender, EventArgs e)
        {
            //uses the IPicture interface to use the appropriate saving mechanism from the picture class in each individual project
            var originalBackground = gauge.BackgroundColor;
            gauge.BackgroundColor = ColorEx.ThemeBackgroundColor;
            DependencyService.Get<IPicture>().SavePictureToDisk("Gauge", gauge.GetImage());
            gauge.BackgroundColor = originalBackground;
            //generic success message
            await DisplayAlert(AppResources.ImageSavedTitle,
              AppResources.ImageSavedDescription,
              AppResources.OKTitle);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(TimeSpan.FromMilliseconds(gauge.LoadAnimation.Duration));
            await AnimateNextStep();
        }

        private async Task AnimateNextStep()
        {
            if (IsVisible)
            {
                var viewModel = BindingContext as SampleViewModel;
                double nextValue = _rand.Next((int)viewModel.Min, (int)viewModel.Max);
                gauge.Value = nextValue;
                await Task.Delay(TimeSpan.FromMilliseconds(_stepDuration));
                AnimateNextStep();
            }
        }
    }
}
