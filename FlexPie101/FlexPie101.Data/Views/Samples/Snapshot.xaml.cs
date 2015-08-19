using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexPieDemo.Data.Model;
using Xamarin.Forms;
using Xuni.Forms.FlexPie;

namespace FlexPieDemo.Data.Views.Samples
{
    public partial class Snapshot
    {
        public Snapshot()
        {
            InitializeComponent();
            this.pieChart.ItemsSource = PieChartSampleFactory.CreateEntiyList();
            snapshotFrame.IsVisible = false;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                snapshotFrame.IsVisible = false;
            };
            snapshotFrame.GestureRecognizers.Add(tapGestureRecognizer);
        }
        void OnSnapshotClicked(object sender, EventArgs e)
        {
            var imageData = this.pieChart.GetImage();
            snapshot.Source = ImageSource.FromStream(() => new MemoryStream(imageData));
            snapshotFrame.IsVisible = true;
        }
    }
}
