using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xuni.Forms.FlexGrid;

namespace FlexGrid101
{
    public class GridDateTimeColumn : GridColumn
    {
        public static readonly BindableProperty ModeProperty = BindableProperty.Create<GridDateTimeColumn, GridDateTimeColumnMode>(p => p.Mode, GridDateTimeColumnMode.Date);

        public GridDateTimeColumn() : base() { }
        public GridDateTimeColumn(PropertyInfo property) : base(property) { }

        public GridDateTimeColumnMode Mode
        {
            get
            {
                return (GridDateTimeColumnMode)GetValue(ModeProperty);
            }
            set
            {
                SetValue(ModeProperty, value);
            }
        }

        protected override View CreateCellEditor(GridRow row)
        {
            if (DataType == typeof(DateTime))
            {
                var original = (DateTime)GetCellValue(GridCellType.Cell, row);
                if (Mode == GridDateTimeColumnMode.Date)
                {
                    var datePicker = new DatePicker();
                    datePicker.Date = original;
                    datePicker.PropertyChanged += (sender, e) =>
                    {
                        if (e.PropertyName == DatePicker.DateProperty.PropertyName && sender == datePicker)
                        {
                            Grid.FinishEditing();
                        }
                    };
                    return datePicker;
                }
                else
                {
                    var timePicker = new TimePicker();
                    timePicker.Time = original.TimeOfDay;
                    timePicker.PropertyChanged += (sender, e) =>
                    {
                        if (e.PropertyName == TimePicker.TimeProperty.PropertyName && sender == timePicker)
                        {
                            Grid.FinishEditing();
                        }
                    };
                    return timePicker;
                }
            }
            else
            {
                return base.CreateCellEditor(row);
            }
        }

        protected override object GetEditorValue(GridRow row, View editor)
        {
            var original = (DateTime)GetCellValue(GridCellType.Cell, row);
            if (editor is DatePicker)
            {
                var datePicker = editor as DatePicker;
                return new DateTime(datePicker.Date.Year, datePicker.Date.Month, datePicker.Date.Day, original.Hour, original.Minute, original.Second);
            }
            else if (editor is TimePicker)
            {
                var timePicker = editor as TimePicker;
                return new DateTime(original.Year, original.Month, original.Day, timePicker.Time.Hours, timePicker.Time.Minutes, timePicker.Time.Seconds);
            }
            return null;
        }
    }

    public enum GridDateTimeColumnMode
    {
        Date,
        Time
    }
}
