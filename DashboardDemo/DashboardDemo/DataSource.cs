using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardDemo
{
    public class DataSource : INotifyPropertyChanged
    {
        private List<Quarter> appData;

        public List<Quarter> Data
        {
            get { return appData; }
        }

        private double _goal;
        public double Goal
        {
            get
            {
                return _goal;
            }
            set
            {
                _goal = value;
                RaisePropertyChanged("Goal");
            }
        }

        public DataSource()
        {
            //// appData
            appData = new List<Quarter>();
            var quarterNames = "Q1, Q2, Q3, Q4".Split(',');
            var salesData = new[] { 6833, 11100, 10833, 15350 };
            var downloadsData = new[] { 8500, 7933, 11666, 12350 };
            var expensesData = new[] { 11166, 10166, 7333, 8166 };
            for (int i = 0; i < 4; i++)
            {

                Quarter tempQuarter = new Quarter();
                tempQuarter.Name = quarterNames[i];
                tempQuarter.Sales = salesData[i];
                tempQuarter.SalesGoal = tempQuarter.Sales / 16000;
                tempQuarter.Downloads = downloadsData[i];
                tempQuarter.DownloadsGoal = tempQuarter.Downloads / 16000;
                tempQuarter.Expenses = expensesData[i];
                tempQuarter.ExpensesGoal = tempQuarter.Expenses / 16000;
                appData.Add(tempQuarter);

            }
        }

        void RaisePropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }

    public class Quarter
    {
        string _name;
        double _sales, _downloads, _expenses;
        double _salesGoal, _downloadsGoal, _expensesGoal;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Sales
        {
            get { return _sales; }
            set { _sales = value; }
        }

        public double Downloads
        {
            get { return _downloads; }
            set { _downloads = value; }
        }
        public double Expenses
        {
            get { return _expenses; }
            set { _expenses = value; }
        }

        public double SalesGoal
        {
            get { return _salesGoal; }
            set { _salesGoal = value; }
        }

        public double ExpensesGoal
        {
            get { return _expensesGoal; }
            set { _expensesGoal = value; }
        }

        public double DownloadsGoal
        {
            get { return _downloadsGoal; }
            set { _downloadsGoal = value; }
        }

    }
}