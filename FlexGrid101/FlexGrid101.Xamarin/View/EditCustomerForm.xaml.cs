using FlexGrid101.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlexGrid101
{
    public partial class EditCustomerForm : ContentPage
    {
        private Customer editingCustomer;
        public EditCustomerForm(Customer cust)
        {
            InitializeComponent();

            if (cust != null)
            {
                // initialize input form with values from the selected customer
                this.editingCustomer = cust;
                entryFirstName.Text = cust.First;
                entryLastName.Text = cust.Last;
                datePickerHired.Date = cust.Hired;
                entryWeight.Text = cust.Weight.ToString("n4");
            }

            lblFormTitle.Text = AppResources.EditCustomer;
            btnApply.Text = AppResources.Apply;
            btnApply.Clicked += btnApply_Clicked;
            btnCancel.Text = AppResources.Cancel;
            btnCancel.Clicked += btnCancel_Clicked;
        }

        async void btnApply_Clicked(object sender, EventArgs e)
        {
            // save new values to the customer object
            this.editingCustomer.First = entryFirstName.Text;
            this.editingCustomer.Last = entryLastName.Text;
            this.editingCustomer.Hired = datePickerHired.Date;
            double weight;
            if (double.TryParse(entryWeight.Text, out weight))
                this.editingCustomer.Weight = weight;

            // close pop-up
            await Navigation.PopModalAsync();
        }

        async void btnCancel_Clicked(object sender, EventArgs e)
        {
            // close pop-up without saving anything
            await Navigation.PopModalAsync();
        }

    }
}
