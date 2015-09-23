using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexPieDemo.Data.Model;
using Xamarin.Forms;
using Xuni.Forms.ChartCore;
using Xuni.Forms.FlexPie;
using System.Reflection;
using FlexPieDemo.Data.Resources;
namespace FlexPieDemo.Data.Views.Samples
{
    public partial class ThemingSample
    {
        List<Color[]> listPalettes;
        public ThemingSample()
        {
            InitializeComponent();
            Title = AppResources.ThemingTitle;
            this.listPalettes = new List<Color[]>();
            this.flexPie.ItemsSource = PieChartSampleFactory.CreateEntiyList();
            foreach (var field in typeof(ChartPalettes).GetRuntimeFields())
            {
                if (field.IsStatic && field.FieldType == typeof(Color[]))
                {
                    listPalettes.Add(field.GetValue(null) as Color[]);
                    this.pickerThemeing.Items.Add(field.Name);
                }
            }
            this.pickerThemeing.SelectedIndex = 0;
            this.pickerThemeing.SelectedIndexChanged += pickerThemeing_SelectedIndexChanged;
        }

        void pickerThemeing_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexPie.Palette = this.listPalettes[this.pickerThemeing.SelectedIndex];
        }
    }
}
