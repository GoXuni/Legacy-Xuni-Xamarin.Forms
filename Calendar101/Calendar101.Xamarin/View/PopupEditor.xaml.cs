using System;
using Calendar101.Resources;

namespace Calendar101
{
    public partial class PopupEditor
    {
        public PopupEditor()
        {
            InitializeComponent();
            Title = AppResources.PopupEditorTitle;
        }

        public async void OnSelectDateClicked(object sender, EventArgs e)
        {
            try
            {
                var date = await DatePicker.PickDateAsync(Navigation);
                message.Text = string.Format(AppResources.SelectedDateMessage, date);
            }
            catch (OperationCanceledException)
            {
                message.Text = "";
            }
        }


        public string PickDateLabel
        {
            get
            {
                return AppResources.PickDateLabel;
            }
        }
    }
}
