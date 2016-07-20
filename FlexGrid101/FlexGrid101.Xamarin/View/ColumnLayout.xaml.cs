using FlexGrid101.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xuni.Forms.FlexGrid;

namespace FlexGrid101
{
    public partial class ColumnLayout : ContentPage
    {
        private string FILENAME = "ColumnLayout.json";

        public ColumnLayout()
        {
            InitializeComponent();

            Title = AppResources.ColumnLayoutTitle;
            btnEditColumnLayout.Text = AppResources.EditColumnLayout;
            btnSerializeColumnLayout.Text = AppResources.SaveColumnLayout;

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;

            InitializeColumnLayout();
        }

        private async void OnEditColumnLayout(object sender, EventArgs e)
        {
            await ColumnLayoutForm.ShowAsync(Navigation, grid);
        }

        private async void OnSerializeColumnLayout(object sender, EventArgs e)
        {
            var serializedColumns = await SerializeLayout(grid);
            var fileSystem = DependencyService.Get<IFileSystem>();
            await fileSystem.SaveFileToDisk(FILENAME, serializedColumns);
        }

        async void InitializeColumnLayout()
        {
            var fileSystem = DependencyService.Get<IFileSystem>();
            var data = await fileSystem.ReadFileFromDisk(FILENAME);
            if (!string.IsNullOrWhiteSpace(data))
                await DeserializeLayout(grid, data);
        }

        private async Task<string> SerializeLayout(FlexGrid grid)
        {
            var columns = new List<ColumnInfo>();
            foreach (var col in grid.Columns)
            {
                var colInfo = new ColumnInfo { Name = col.Binding, IsVisible = col.IsVisible };
                columns.Add(colInfo);
            }
            var serializer = new DataContractJsonSerializer(typeof(ColumnInfo[]));
            var stream = new MemoryStream();
            serializer.WriteObject(stream, columns.ToArray());
            await stream.FlushAsync();
            stream.Seek(0, SeekOrigin.Begin);
            var serializedColumns = await new StreamReader(stream).ReadToEndAsync();
            return serializedColumns;
        }

        private async Task DeserializeLayout(FlexGrid grid, string layout)
        {
            var serializer = new DataContractJsonSerializer(typeof(ColumnInfo[]));
            var stream = new MemoryStream(System.Text.UTF8Encoding.UTF8.GetBytes(layout));
            var columns = serializer.ReadObject(stream) as ColumnInfo[];
            for (int i = 0; i < columns.Length; i++)
            {
                var colInfo = columns[i];
                var column = grid.Columns[colInfo.Name];
                var colIndex = grid.Columns.IndexOf(column);
                column.IsVisible = colInfo.IsVisible;
                if (colIndex != i)
                {
                    grid.Columns.Move(colIndex, i);
                }
            }
        }
    }

    [DataContract]
    public class ColumnInfo
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "isVisible")]
        public bool IsVisible { get; set; }
    }
}
