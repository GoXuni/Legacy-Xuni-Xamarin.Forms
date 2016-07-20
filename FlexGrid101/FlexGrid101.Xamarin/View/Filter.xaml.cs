using FlexGrid101.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xuni.CollectionView;

namespace FlexGrid101
{
    public partial class Filter : ContentPage
    {
        public Filter()
        {
            InitializeComponent();

            this.Title = AppResources.FilterTitle;
            toolbarItemFilter.Text = AppResources.Filter;
            toolbarItemRemove.Text = AppResources.Remove;

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
        }

        private async void OnFilterClicked(object sender, EventArgs e)
        {
            var filtering = grid.CollectionView as ISupportFiltering;
            if (filtering != null)
            {
                var filterForm = new FilterForm();
                var currentFilters = GetCurrentFilters(filtering.FilterExpression);
                foreach (var column in grid.Columns)
                {
                    if (column.DataType == typeof(string))
                    {
                        var stringFilter = new StringFilter();
                        stringFilter.Field = column.Binding;
                        stringFilter.FieldName = column.ActualHeader;
                        var existingFilter = currentFilters.FirstOrDefault(f => f.FilterPath == column.Binding);
                        if (existingFilter != null)
                        {
                            stringFilter.Operation = existingFilter.FilterOperation;
                            stringFilter.Value = existingFilter.Value.ToString();
                        }
                        filterForm.Filters.Add(stringFilter);
                    }
                }
                try
                {
                    await filterForm.ShowAsync(Navigation);
                    var filters = new List<FilterExpression>();
                    foreach (var filter in filterForm.Filters)
                    {
                        if (!string.IsNullOrWhiteSpace(filter.Value))
                        {
                            filters.Add(new FilterUnaryExpression(filter.Field, filter.Operation, filter.Value));
                        }
                    }
                    await filtering.FilterAsync(FilterExpression.Combine(FilterCombination.And, filters.ToArray()));
                }
                catch (OperationCanceledException) { }
            }
        }

        private IEnumerable<FilterUnaryExpression> GetCurrentFilters(FilterExpression filterExpression)
        {
            var uf = filterExpression as FilterUnaryExpression;
            if (uf != null)
                yield return uf;
            var bf = filterExpression as FilterBinaryExpression;
            if (bf != null)
            {
                foreach (var lf in GetCurrentFilters(bf.LeftExpression))
                {
                    yield return lf;
                }
                foreach (var rf in GetCurrentFilters(bf.RightExpression))
                {
                    yield return rf;
                }
            }
            yield break;
        }

        private async void OnRemoveFilterClicked(object sender, EventArgs e)
        {
            var filtering = grid.CollectionView as ISupportFiltering;
            if (filtering != null)
                await filtering.FilterAsync(null);
        }
    }
}
