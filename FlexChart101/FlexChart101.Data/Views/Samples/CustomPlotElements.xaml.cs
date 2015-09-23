using FlexChartDemo.Data.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xuni.Forms.FlexChart;

namespace FlexChartDemo.Data.Views.Samples
{
    public partial class CustomPlotElements : ContentPage
    {
     
        public CustomPlotElements()
        {
            InitializeComponent();
            Title = AppResources.CustomPlotElementsTitle;

            this.flexChart1.ItemsSource = new List<Company> 
            { 
                new Company { Name = "Apple", DevicesSold = 15.58},
                new Company { Name = "Google", DevicesSold = 20.23 },
                new Company { Name = "Microsoft", DevicesSold = 10.46 },
            };

            this.flexChart1.AxisY.AxisLineVisible = false;
            this.flexChart1.AxisY.MajorTickWidth = 0;
            this.flexChart1.AxisY.TitleText = "Devices Sold (billions)";
            this.flexChart1.AxisY.TitleFontAttributes = FontAttributes.Italic;
            this.flexChart1.AxisX.MajorTickWidth = 0;
            this.flexChart1.AxisX.MinorTickWidth = 1;
            this.flexChart1.Legend.Position = Xuni.Forms.ChartCore.ChartPositionType.None;
            this.flexChart1.IsAnimated = false;
           
        }
        void OnPlotElementLoading(object sender, ChartPlotElementLoadingEventArgs e)
        {
            Company company;
            if (e.DataItem == null)
            {
                company = ((List<Company>)flexChart1.ItemsSource).ElementAt(e.PointIndex);
            }
            else
            {
                company = e.DataItem as Company;
            }

            e.PlotElement = new PlotElementWithIcon(company);
        }
    }

    public class PlotElementWithIcon : ChartPlotElement
    {
        Company company;
        Image img;
        Layout root;
        public PlotElementWithIcon(Company company)
        {
            this.company = company;
            this.img = new Image()
            {
                Source = ImageSource.FromResource(string.Format("FlexChartDemo.Data.Images.{0}.png", this.company.Name.ToLower()))
            };
            root = new Grid() { Children = { this.img }, Padding=10,BackgroundColor=Color.Gray};
            this.Content = root;
        }      
    }

    public class Company
    {
        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public double DevicesSold { get; set; }
    }
}
