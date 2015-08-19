using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexPieDemo.Data.Model;
using Xamarin.Forms;
using Xuni.Forms.ChartCore;

namespace FlexPieDemo.Data.Views.Samples
{
    public partial class SelectionSample
    {
        public SelectionSample()
        {
            InitializeComponent();
            this.flexPie.ItemsSource = PieChartSampleFactory.CreateEntiyList();
            this.flexPie.Palette = Xuni.Forms.ChartCore.Palettes.Superhero;
            Device.OnPlatform(Android: () =>
                this.flexPie.SelectedDashes = new double[] {15, 5}
                );

            Device.OnPlatform(WinPhone: () =>
               this.flexPie.SelectedDashes = new double[] { 3, 1 }
                );

            Device.OnPlatform(iOS: () =>
                this.flexPie.SelectedDashes = new double[] { 7.5, 2.5 }
                );
            this.pickerPosition.SelectedIndexChanged += pickerPosition_SelectedIndexChanged;
            foreach (var item in Enum.GetNames(typeof(ChartPositionType)))
            {
                this.pickerPosition.Items.Add(item);
            }
            this.pickerPosition.SelectedIndex = 3;
            
            root.SizeChanged += root_SizeChanged;
        }

        void root_SizeChanged(object sender, EventArgs e)
        {
            if (root.Width > root.Height)
            {
                stackOptions.Orientation = StackOrientation.Horizontal;
            }
            else
            {
                stackOptions.Orientation = StackOrientation.Vertical;
            }
        }
        void pickerPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type=this.pickerPosition.Items[this.pickerPosition.SelectedIndex];
            this.flexPie.SelectedItemPosition=(ChartPositionType)(Enum.Parse(typeof(ChartPositionType),type));
        }
    }
}
