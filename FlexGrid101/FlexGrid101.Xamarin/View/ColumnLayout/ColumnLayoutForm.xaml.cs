using FlexGrid101.Resources;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xuni.Forms.FlexGrid;

namespace FlexGrid101
{
    public partial class ColumnLayoutForm : ContentPage
    {
        private TaskCompletionSource<bool> _completion;
        private FlexGrid _grid;

        private ColumnLayoutForm()
        {
            InitializeComponent();

            btnOK.Text = AppResources.OK;
            btnCancel.Text = AppResources.Cancel;
        }

        protected override bool OnBackButtonPressed()
        {
            if (_completion != null)
                _completion.TrySetCanceled();
            return base.OnBackButtonPressed();
        }

        private async void OKClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
            _completion.TrySetResult(true);
        }

        private async void CancelClicked(object sender, EventArgs e)
        {
            if (_completion != null)
                _completion.TrySetCanceled();
            // close pop-up without saving anything
            await Navigation.PopModalAsync();
        }

        public static async Task ShowAsync(INavigation navigation, FlexGrid grid)
        {
            var form = new ColumnLayoutForm();
            form._grid = grid;
            form._completion = new TaskCompletionSource<bool>();
            var columns = new ObservableCollection<ColumnLayoutItemViewModel>();
            foreach (var column in grid.Columns)
            {
                columns.Add(new ColumnLayoutItemViewModel(columns, column));
            }
            form.BindingContext = columns;
            await navigation.PushModalAsync(form, true);
            try
            {
                await form._completion.Task;
                for (int i = 0; i < columns.Count; i++)
                {
                    var cvm = columns[i];
                    var currentIndex = grid.Columns.IndexOf(cvm.Column);
                    if (currentIndex != i)
                    {
                        grid.Columns.Move(currentIndex, i);
                    }
                    if (cvm.IsVisible != cvm.Column.IsVisible)
                    {
                        cvm.Column.IsVisible = cvm.IsVisible;
                    }
                }
            }
            catch { }
        }
    }
    public class ColumnLayoutItemViewModel
    {
        public ColumnLayoutItemViewModel(ObservableCollection<ColumnLayoutItemViewModel> columns, GridColumn column)
        {
            Columns = columns;
            Column = column;
            Title = column.ActualHeader;
            IsVisible = column.IsVisible;
            UpCommand = new Command(MoveUp, CanMoveUp);
            DownCommand = new Command(MoveDown, CanMoveDown);
        }

        public ObservableCollection<ColumnLayoutItemViewModel> Columns { get; set; }
        public GridColumn Column { get; set; }
        public string Title { get; set; }
        public Command UpCommand { get; set; }
        public Command DownCommand { get; set; }
        public bool IsVisible { get; set; }

        private bool CanMoveUp()
        {
            return Columns.IndexOf(this) > 0;
        }

        private void MoveUp()
        {
            var currentIndex = Columns.IndexOf(this);
            Columns.Move(currentIndex, currentIndex - 1);
            //Columns.RemoveAt(currentIndex);
            //Columns.Insert(currentIndex - 1, this);
            UpdateCommands();
        }

        private bool CanMoveDown()
        {
            return Columns.IndexOf(this) < Columns.Count - 1;
        }

        private void MoveDown()
        {
            var currentIndex = Columns.IndexOf(this);
            Columns.Move(currentIndex, currentIndex + 1);
            //Columns.RemoveAt(currentIndex);
            //Columns.Insert(currentIndex + 1, this);
            UpdateCommands();
        }

        private void UpdateCommands()
        {
            foreach (var column in Columns)
            {
                column.UpCommand.ChangeCanExecute();
                column.DownCommand.ChangeCanExecute();
            }
        }
    }
}
