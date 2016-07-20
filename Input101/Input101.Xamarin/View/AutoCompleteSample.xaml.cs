using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Input101.Resources;
using Xuni.CollectionView;
//using Xuni.Forms.Calendar;
using System.Linq.Expressions;
using System.Collections;

namespace Input101
{
    public partial class AutoCompleteSample
    {
		List<Country> countries;
        public AutoCompleteSample()
        {
            countries = Country.GetCountries();
            InitializeComponent();
            Title = AppResources.AutoCompleteTitle;
            this.auto2.Filtering += Auto2_Filtering;
        }

        private async void Auto2_Filtering(object sender, Xuni.Forms.Input.FilteringEventArgs e)
        {
            e.Handled = true;
            var filter = new FilterUnaryExpression("Name", FilterOperation.StartsWith, "b");
			XuniCollectionView<Country> cv = new XuniCollectionView<Country>(countries);
			await (cv).FilterAsync(filter);
           
			this.auto2.ItemsSource = cv;
			this.auto2.IsDropDownOpen = true;
        }
        public IEnumerable ItemsSource
        {
            get
            {
                return this.countries;
            }
        }
    }
}
