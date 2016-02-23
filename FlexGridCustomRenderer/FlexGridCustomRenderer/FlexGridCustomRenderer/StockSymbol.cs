using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace FlexGridCustomRenderer
{
    /// <summary>
    /// Simple data class generator.
    /// </summary>
    /// <remarks>
    public class StockSymbol :
        INotifyPropertyChanged,
        IEditableObject
    {
        #region ** fields

        string _symbol;
        double _open, _close;

        static Random _rnd = new Random();
        static string[] _symbolCharacters = "A|B|C|D|E|F|G|H|I|K|L|M|N|O|P|R|S|T|V|W|X".Split('|');

        #endregion

        #region ** initialization

        public StockSymbol()
        {
            Symbol = _symbolCharacters[_rnd.Next(_symbolCharacters.Count())] + 
                _symbolCharacters[_rnd.Next(_symbolCharacters.Count())] + 
                _symbolCharacters[_rnd.Next(_symbolCharacters.Count())] + 
                _symbolCharacters[_rnd.Next(_symbolCharacters.Count())];
            Open = _rnd.Next(0, 100) + _rnd.NextDouble();
			Close = _rnd.Next(0, 120) + _rnd.NextDouble();
        }

        #endregion

        #region ** object model


        public string Symbol
        {
            get { return _symbol; }
            set
            {
                if (value != _symbol)
                {
                    _symbol = value;
                    OnPropertyChanged("Symbol");
                }
            }
        }

        public double Open
        {
            get { return _open; }
            set
            {
                if (value != _open)
                {
                    _open = value;
                    OnPropertyChanged("Open");
                }
            }
        }

        public double Close
        {
            get { return _close; }
            set
            {
                if (value != _close)
                {
                    _close = value;
                    OnPropertyChanged("Close");
                }
            }
        }

        public double Change
        {
            get { return this.Close - this.Open; }
        }

        public ImageSource ChangeImageSource
        {
            get
            {
                if(this.Change < 0)
                {
                    return ImageSource.FromResource("FlexGridCustomRenderer.Images.Arrow-Down-64.png");
                }
                else if(this.Change > 0)
                {
                    return ImageSource.FromResource("FlexGridCustomRenderer.Images.Arrow-Up-64.png");
                }
                return null;
            }
        }

		public string Blank
		{
			get { return ""; }
		}

        #endregion

        #region ** implementation

        // ** static list provider
        public static ObservableCollection<StockSymbol> GetStockSymbolList(int count)
        {
            var list = new ObservableCollection<StockSymbol>();
            for (int i = 0; i < count; i++)
            {
                list.Add(new StockSymbol());
            }
            return list;
        }


        #endregion

        #region ** INotifyPropertyChanged Members

        // this interface allows bounds controls to react to changes in the data objects.
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        #endregion

        #region IEditableObject Members

        // this interface allows transacted edits (user can press escape to restore previous values).

        StockSymbol _clone;
        public void BeginEdit()
        {
            _clone = (StockSymbol)this.MemberwiseClone();
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