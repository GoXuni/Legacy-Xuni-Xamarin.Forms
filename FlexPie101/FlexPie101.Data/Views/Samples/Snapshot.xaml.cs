using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexPieDemo.Data.Model;
using Xamarin.Forms;
using Xuni.Forms.FlexPie;
using FlexPieDemo.Data.Resources;
using Xuni.Forms.Core;

namespace FlexPieDemo.Data.Views.Samples
{
    public partial class Snapshot
    {
        public Snapshot()
        {
            InitializeComponent();
            Title = AppResources.ExportImageTitle;
            this.pieChart.ItemsSource = PieChartSampleFactory.CreateEntiyList();
            snapshotFrame.IsVisible = false;           
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                snapshotFrame.IsVisible = false;

                // Make the control mearsure and layout again. Otherwise the size of the control may incorrect.
                pieChart.IsVisible = false;
                pieChart.IsVisible = true;
            };
            snapshotFrame.GestureRecognizers.Add(tapGestureRecognizer);
        }
      async  void OnSnapshotClicked(object sender, EventArgs e)
        {
            var originalBackground = pieChart.BackgroundColor;
            if (originalBackground == null || originalBackground.A == 0)
            {
                pieChart.BackgroundColor = ColorEx.ThemeBackgroundColor;
            }
            DependencyService.Get<IPicture>().SavePictureToDisk("PieImage", pieChart.GetImage());
            pieChart.BackgroundColor = originalBackground;
            //generic success message
            await DisplayAlert("Image Saved",
                "The image has been saved to your device's picture album.",
                "OK");
        }
    }
}
