using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexChartDemo.Data.Model;
using Xamarin.Forms;
using Xuni.Forms.FlexChart;
using Xuni.Forms.ChartCore;
using FlexChartDemo.Data.Resources;

namespace FlexChartDemo.Data.Views.Samples
{
    public partial class Annotation
    {
        public Annotation()
        {
            InitializeComponent();

            Title = AppResources.AnnotationTitle;
            this.flexChart.BindingContext = new SampleViewModel();
            
            this.flexChart.IsAnimated = false;
            this.flexChart.AxisY.AxisLineVisible = false;
            this.flexChart.AxisY.MajorTickWidth = 0;
            this.imageAnnotation.BindingContext = this.flexChart.BindingContext;
            this.lineAnnotation.BindingContext = this.flexChart.BindingContext;
            this.textAnnotation.BindingContext = this.flexChart.BindingContext;
            this.polygonAnnotation.TooltipText = "Polygon annotation\nPath=[60,30][10,80][35,130][85,130][110,80]\nAttachment=Absolute";
            this.ellipseAnnotation.TooltipText = "Ellipse annotation\nPoint=0.8,0.2\nAttachment=Relative";
            this.imageAnnotation.TooltipText = "Image annotation\nPointIndex=2\nAttachment=DataIndex";
            this.rectAnnotation.TooltipText = "Rectangle annotation\nPointIndex=6\nAttachment=DataIndex";
        }
    }
    public class SampleViewModel
    {
        List<SalesExpensesDownloadsEntity> itemsSource;
        double centerY;
        public SampleViewModel()
        {
            double[] downloads={400,600,400,1000,1300,2100,523,600,100,800};
            this.itemsSource = new List<SalesExpensesDownloadsEntity>();
            for (int i = 0; i < downloads.Length; i++)
            {
                itemsSource.Add(new SalesExpensesDownloadsEntity() { Downloads=downloads[i] ,Name="Jan "+(i+1)});
            }
            centerY = (itemsSource.Max(x => x.Downloads) + itemsSource.Min(x => x.Downloads)) * 0.5;
        }
        public List<SalesExpensesDownloadsEntity> ItemsSource
        {
            get
            {
                return this.itemsSource;
            }
        }
        public ImageSource ImageSource
        {
            get
            {
                return ImageSource.FromResource("FlexChartDemo.Data.Images.xuni_butterfly.png");
            }
        }
       public Point PointStart
        {
            get
            {
               return new Point(0, centerY);
            }
        }
       public Point PointEnd
        {
            get
            {
                return new Point(itemsSource.Count, centerY);
            }
        }
    }
}
