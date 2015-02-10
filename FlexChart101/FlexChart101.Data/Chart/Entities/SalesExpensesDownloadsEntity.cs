using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexChartDemo.Data.Chart.Entities
{
    public class SalesExpensesDownloadsEntity
    {
        public string Name { get; set; }

        public double Sales { get; set; }

        public double Expenses { get; set; }

        public double Downloads { get; set; }

        public SalesExpensesDownloadsEntity()
        {
            this.Name = string.Empty;
            this.Sales = 0;
            this.Expenses = 0;
            this.Downloads = 0;
        }

        public SalesExpensesDownloadsEntity(string name, double sales, double expenses, double downloads)
        {
            this.Name = name;
            this.Sales = sales;
            this.Expenses = expenses;
            this.Downloads = downloads;
        }
    }
}
