using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexChartDemo.Data.Model;
using Xamarin.Forms;
using Xuni.Forms.FlexChart;
using Xuni.Forms.Core;

namespace FlexChartDemo.Data.Views.Samples
{
    public partial class Snapshot
    {

        public Snapshot()
        {
            InitializeComponent();
            this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
            snapshotFrame.IsVisible = false;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                snapshotFrame.IsVisible = false;
            };
            snapshotFrame.GestureRecognizers.Add(tapGestureRecognizer);
        }
        async void OnSnapshotClicked(object sender, EventArgs e)
        {
            // this commented out code will load the image into an Image control.
            //var imageData = this.flexChart.GetImage();
            //snapshot.Source = ImageSource.FromStream(()=>new MemoryStream(imageData));
            //snapshotFrame.IsVisible = true;

            //uses the IPicture interface to use the appropriate saving mechanism from the picture class in each individual project
            var originalBackground = flexChart.BackgroundColor;
            if (originalBackground == null || originalBackground.A == 0)
            {
                flexChart.BackgroundColor = ColorEx.ThemeBackgroundColor;
            }
            DependencyService.Get<IPicture>().SavePictureToDisk("ChartImage", flexChart.GetImage());
            flexChart.BackgroundColor = originalBackground;
            //generic success message
            await DisplayAlert("Image Saved",
                "The image has been saved to your device's picture album.",
                "OK");
        }

    }
}
