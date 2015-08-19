using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;

namespace FlexGrid101
{
    /// <summary>
    /// Simple data class generator.
    /// </summary>
    /// <remarks>
    public class Customer :
        INotifyPropertyChanged,
        IEditableObject
    {
        #region ** fields

        int _id, _countryID;
        string _first, _last;
        string _father, _brother, _cousin;
        bool _active;
        DateTime _hired;
        double _weight;

        static Random _rnd = new Random();
        static string[] _firstNames = "Andy|Ben|Charlie|Dan|Ed|Fred|Gil|Herb|Jack|Karl|Larry|Mark|Noah|Oprah|Paul|Quince|Rich|Steve|Ted|Ulrich|Vic|Xavier|Zeb".Split('|');
        static string[] _lastNames = "Ambers|Bishop|Cole|Danson|Evers|Frommer|Griswold|Heath|Jammers|Krause|Lehman|Myers|Neiman|Orsted|Paulson|Quaid|Richards|Stevens|Trask|Ulam".Split('|');
        static string[] _countries = "China|India|United States|Indonesia|Brazil|Pakistan|Bangladesh|Nigeria|Russia|Japan|Mexico|Philippines|Vietnam|Germany|Ethiopia|Egypt|Iran|Turkey|Congo|France|Thailand|United Kingdom|Italy|Myanmar".Split('|');

        #endregion

        #region ** initialization

        public Customer()
            : this(_rnd.Next(10000))
        {
        }
        public Customer(int id)
        {
            ID = id;

            First = GetString(_firstNames);
            Last = GetString(_lastNames);
            CountryID = _rnd.Next() % _countries.Length;
            Active = _rnd.NextDouble() >= .5;
            Hired = DateTime.Today.AddDays(-_rnd.Next(1, 365));
            Weight = 50 + _rnd.NextDouble() * 50;
            _father = string.Format("{0} {1}", GetString(_firstNames), Last);
            _brother = string.Format("{0} {1}", GetString(_firstNames), Last);
            _cousin = GetName();
        }

        #endregion

        #region ** object model

        public int ID
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    RaisePropertyChanged("ID");
                }
            }
        }
        
        public string Name
        {
            get { return string.Format("{0} {1}", First, Last); }
        }
        
        public string Country
        {
            get { return _countries[_countryID]; }
        }

        public int CountryID
        {
            get { return _countryID; }
            set
            {
                if (value != _countryID && value > -1 && value < _countries.Length)
                {
                    _countryID = value;
                    RaisePropertyChanged("CountryID");
                    RaisePropertyChanged("Country");
                }
            }
        }

        public bool Active
        {
            get { return _active; }
            set
            {
                if (value != _active)
                {
                    _active = value;
                    RaisePropertyChanged("Active");
                }
            }
        }

        public string First
        {
            get { return _first; }
            set
            {
                if (value != _first)
                {
                    _first = value;
                    RaisePropertyChanged("First");
                    RaisePropertyChanged("Name");
                }
            }
        }
        
        public string Last
        {
            get { return _last; }
            set
            {
                if (value != _last)
                {
                    _last = value;
                    RaisePropertyChanged("Last");
                    RaisePropertyChanged("Name");
                }
            }
        }
        
        public DateTime Hired
        {
            get { return _hired; }
            set
            {
                if (value != _hired)
                {
                    _hired = value;
                    RaisePropertyChanged("Hired");
                }
            }
        }
        
        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value != _weight)
                {
                    _weight = value;
                    RaisePropertyChanged("Weight");
                }
            }
        }

        // some read-only stuff
        public string Father
        {
            get { return _father; }
        }

        public string Brother
        {
            get { return _brother; }
        }
        
        public string Cousin 
        {
            get { return _cousin; }
        }
        
        #endregion

        #region ** implementation

        // ** utilities
        static string GetString(string[] arr)
        {
            return arr[_rnd.Next(arr.Length)];
        }
        static string GetName()
        {
            return string.Format("{0} {1}", GetString(_firstNames), GetString(_lastNames));
        }

        // ** static list provider
        public static ObservableCollection<Customer> GetCustomerList(int count)
        {
            var list = new ObservableCollection<Customer>();
            for (int i = 0; i < count; i++)
            {
                list.Add(new Customer(i));
            }
            return list;
        }


        // ** static value providers
        public static string[] GetCountries() { return _countries; }
        public static string[] GetFirstNames() { return _firstNames; }
        public static string[] GetLastNames() { return _lastNames; }
        
        #endregion

        #region ** INotifyPropertyChanged Members

        // this interface allows bounds controls to react to changes in the data objects.

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

        #endregion

        #region IEditableObject Members

        // this interface allows transacted edits (user can press escape to restore previous values).

        Customer _clone;
        public void BeginEdit()
        {
            _clone = (Customer)this.MemberwiseClone();
        }
        public void EndEdit()
        {
            _clone = null;
        }
        public void CancelEdit()
        {
            if (_clone != null)
            {
                foreach (var p in this.GetType().GetRuntimeProperties())
                {
                    if (p.CanRead && p.CanWrite)
                    {
                        p.SetValue(this, p.GetValue(_clone, null), null);
                    }
                }
            }
        }


        #endregion
    }
}