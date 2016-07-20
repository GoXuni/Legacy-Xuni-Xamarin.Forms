using FlexGrid101.Resources;
using System;
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
                entryFirstName.Text = cust.FirstName;
                entryLastName.Text = cust.LastName;
                datePickerLastOrder.Date = cust.LastOrderDate;
                entryOrderTotal.Text = cust.OrderTotal.ToString("n4");
            }

            Title = AppResources.EditCustomer;
            btnApply.Text = AppResources.Apply;
            btnApply.Clicked += btnApply_Clicked;
            btnCancel.Text = AppResources.Cancel;
            btnCancel.Clicked += btnCancel_Clicked;
        }

        async void btnApply_Clicked(object sender, EventArgs e)
        {
            // save new values to the customer object
            this.editingCustomer.FirstName = entryFirstName.Text;
            this.editingCustomer.LastName = entryLastName.Text;
            this.editingCustomer.LastOrderDate = datePickerLastOrder.Date;
            double orderTotal;
            if (double.TryParse(entryOrderTotal.Text, out orderTotal))
                this.editingCustomer.OrderTotal = orderTotal;

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
