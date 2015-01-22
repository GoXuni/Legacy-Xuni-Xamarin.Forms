using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlexPieDemo.Data.Chart;
using FlexPieDemo.Data.Chart.Entities;

using Xuni.Xamarin.FlexPie;

namespace FlexPieDemo.Data.Chart
{
    public static class PieChartSampleFactory
    {
        public static FlexPie GetFlexChartSample(PieChartSample chartSample)
        {
            switch (chartSample.PieChartSampleDataType)
            {
                case (int)PieChartSampleDataType.SALES_EXPENSES_DOWNLOADS:
                    return SalesExpensesDownloads();
            }

            return null;
        }

        private static FlexPie SalesExpensesDownloads()
        {
            FlexPie chart = new FlexPie();

            chart.BindingName = "Name";
            chart.Binding = "Value";

            List<FruitEntity> entityList = new List<FruitEntity>();

            string[] fruits = new string[] { "Oranges", "Apples", "Pears", "Bananas", "Pineapples" };

            Random random = new Random();

            for (int i = 0; i < fruits.Length; i++)
            {
                decimal value = (decimal)random.NextDouble() * 100;

                entityList.Add(new FruitEntity(fruits[i], value));
            }

            chart.ItemsSource = entityList;

            return chart;
        }
    }
}
