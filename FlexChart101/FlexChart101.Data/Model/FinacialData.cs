using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexChartDemo.Data.Model
{
    public class FinancialData
    {
        public DateTime Date { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
        public FinancialData()
        {

        }
        public FinancialData(DateTime date, double high, double low, double open, double close, double vol)
        {
            this.Date = date;
            this.High = high;
            this.Low = low;
            this.Open = open;
            this.Close = close;
            this.Volume = vol;
        }
    }
}
