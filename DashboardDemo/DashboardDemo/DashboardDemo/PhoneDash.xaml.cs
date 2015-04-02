using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DashboardDemo
{
    public partial class PhoneDash : ContentPage
    {
        public PhoneDash()
        {
            InitializeComponent();
            DataSource ds = new DataSource();
            this.chart.BindingContext = ds;
            this.pie.BindingContext = ds;
        }
    }
}
