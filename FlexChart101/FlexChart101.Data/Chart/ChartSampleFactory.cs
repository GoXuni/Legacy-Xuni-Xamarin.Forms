using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xuni.Xamarin.FlexChart;

using FlexChartDemo.Data.Chart.Entities;

using FlexChartDemo.Data.Views;

namespace FlexChartDemo.Data.Chart
{
    public static class ChartSampleFactory
    {
        public static FlexChart GetFlexChartSample(ChartSample chartSample)
        {
            switch (chartSample.SampleDataType)
            {
                case (int)ChartSampleDataType.SALES_EXPENSES_DOWNLOADS:
                    return SalesExpensesDownloads();
                case (int)ChartSampleDataType.BUBBLE:
                    return Bubble();
                //case (int)ChartSampleDataType.FINANCIAL:
                //    return FinancialChart();
            }
            return null;
        }

        public static IEnumerable<SalesExpensesDownloadsEntity> CreateEntityList()
        {
            List<SalesExpensesDownloadsEntity> entityList = new List<SalesExpensesDownloadsEntity>();

            //TODO: add culture
            string[] countries = new string[] { "US", "Germany", "UK", "Japan", "Italy", "Greece" };

            Random random = new Random();

            for (int i = 0; i < countries.Length; i++)
            {
                double sales = random.NextDouble() * 10000;
                double expenses = random.NextDouble() * 5000;
                double downloads = Math.Round(random.NextDouble() * 20000);

                entityList.Add(new SalesExpensesDownloadsEntity(countries[i], sales, expenses, downloads));
            }
            return entityList;
        }
        private static FlexChart SalesExpensesDownloads()
        {
            FlexChart chart = new ResponsiveFlexChart();

            chart.BindingX = "Name";

            //TODO: add culture
			chart.Series.Add(new ChartSeries(chart, "Sales", "Sales"));
			chart.Series.Add(new ChartSeries(chart, "Expenses", "Expenses"));
			chart.Series.Add(new ChartSeries(chart, "Downloads", "Downloads"));

            chart.ItemsSource = CreateEntityList();

            return chart;
        }
        private static FlexChart Bubble()
        {
            FlexChart chart = new ResponsiveFlexChart() { ChartType = ChartType.Bubble };

            chart.BindingX = "Name";

			chart.Series.Add(new ChartSeries(chart, "Sales", "Sales,Downloads"));
			chart.Series.Add(new ChartSeries(chart, "Expenses", "Expenses,Downloads"));

            chart.ItemsSource = CreateEntityList();

            return chart;
        }
        public static List<FinancialData> FinancialData()
        {
            Random rnd = new Random();

            List<FinancialData> listdata = new List<FinancialData>();
            for (int i = 0; i < 15; i++)
            {
                FinancialData data = new FinancialData();
                data.Date = DateTime.Today.AddDays(i);

                if (i > 0)
                    data.Open = listdata[i - 1].Close;
                else
                    data.Open = 1000;

                data.High = data.Open + rnd.Next(20);
                data.Low = data.Open - rnd.Next(20);
                data.Close = rnd.Next((int)data.Low, (int)data.High);

                listdata.Add(data);
            }
            return listdata;
        }
    }
}
