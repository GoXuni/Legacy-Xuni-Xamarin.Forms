using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xuni.CollectionView;

namespace FlexGrid101
{
    public partial class StringFilter : StackLayout
    {
        public StringFilter()
        {
            InitializeComponent();

            operation.Items.Add(FilterOperation.Contains.ToString());
            operation.Items.Add(FilterOperation.StartsWith.ToString());
            operation.Items.Add(FilterOperation.EndsWith.ToString());
            operation.Items.Add(FilterOperation.EqualText.ToString());
            operation.SelectedIndex = 0;
        }

        public string Field
        {
            get
            {
                return field.Text;
            }
            set
            {
                field.Text = value;
            }
        }

        public FilterOperation Operation
        {
            get
            {
                return (FilterOperation)Enum.Parse(typeof(FilterOperation), operation.Items[operation.SelectedIndex]);
            }
            set
            {
                operation.SelectedIndex = operation.Items.IndexOf(value.ToString());
            }
        }

        public string Value
        {
            get
            {
                return enteredValue.Text;
            }
            set
            {
                enteredValue.Text = value;
            }
        }
    }
}
