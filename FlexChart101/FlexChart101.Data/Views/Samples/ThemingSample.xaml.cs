using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using FlexChartDemo.Data.Chart;
using Xamarin.Forms;
using Xuni.Xamarin.ChartCore;
using Xuni.Xamarin.FlexChart;

namespace FlexChartDemo.Data.Views.Samples
{
	public partial class ThemingSample
	{
		public ThemingSample()
		{
			InitializeComponent();
            FlexChartDemo.Data.Views.Common.Utility.CheckNavBar(this);
			this.flexChart.ItemsSource = ChartSampleFactory.CreateEntityList();
			IEnumerable<FieldInfo> fields = typeof(Palettes).GetRuntimeFields();
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
			foreach (var field in typeof(Palettes).GetRuntimeFields())
			{
				if (field.Name == fieldName)
				{
					this.flexChart.Palette = field.GetValue(null) as Color[];
				}
			}
		}
	}
}
