using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DashboardDemo
{
    public partial class TabletDash : ContentPage
    {
        public TabletDash()
        {
            InitializeComponent();
            DataSource ds = new DataSource();
            this.chart.BindingContext = ds;
            this.pie.BindingContext = ds;
        }
    }
}
