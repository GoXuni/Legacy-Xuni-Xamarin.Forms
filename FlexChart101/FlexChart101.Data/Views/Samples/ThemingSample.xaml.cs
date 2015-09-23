using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using FlexChartDemo.Data.Model;
using Xamarin.Forms;
using Xuni.Forms.ChartCore;
using Xuni.Forms.FlexChart;
using FlexChartDemo.Data.Resources;

namespace FlexChartDemo.Data.Views.Samples
{
	public partial class ThemingSample
	{
		public ThemingSample()
		{
			InitializeComponent();
            Title = AppResources.ThemingTitle;

			this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
			IEnumerable<FieldInfo> fields = typeof(ChartPalettes).GetRuntimeFields();
			foreach (var item in fields)
			{
				picker.Items.Add(item.Name);
			}
			picker.SelectedIndex = 0;
		}

		void picker_SelectedIndexChanged(object sender, EventArgs e)
		{
			Picker picker= sender as Picker;
			string fieldName = picker.Items[picker.SelectedIndex];
            foreach (var field in typeof(ChartPalettes).GetRuntimeFields())
			{
				if (field.Name == fieldName)
				{
					this.flexChart.Palette = field.GetValue(null) as Color[];
				}
			}
		}
	}
}
