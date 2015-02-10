using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexChartDemo.Data.Chart.Entities
{
    public class FinancialData
    {
        public DateTime Date { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public FinancialData()
        {

        }
        public FinancialData(DateTime date, double high, double low, double open, double close)
        {
            this.Date = date;
            this.High = high;
            this.Low = low;
            this.Open = open;
            this.Close = close;
        }
    }
}
