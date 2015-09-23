using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xuni.Forms.FlexPie;
using FlexPieDemo.Data.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xuni.Forms.ChartCore;
using FlexPieDemo.Data.Resources;

namespace FlexPieDemo.Data.Views.Samples
{
    public partial class AnimationSample : ContentPage
    {
        ObservableCollection<MyData> data;
        const string TITLE = "Mobile/Tablet Browser Market Share";

        double[] safari = new double[] { 41.54, 48.35, 57.48, 61.67};
        double[] chrome = new double[] { 28.51, 17.12, 4.79, 0.76};
        double[] android_browser = new double[] { 15.8, 21.54, 26.54, 20.61};
        double[] opera_mini = new double[] { 7.62, 6.65, 8.7, 11.91};
        double[] internet_explorer = new double[] { 2.36, 5.2, 1.74, 0.81};
        double[] other = new double[] { 1.68, 2.1, 2.45, 1.83};
        public AnimationSample()
        {
            InitializeComponent();
            Title = AppResources.AnimationTitle;

            // populate data source
            data = new ObservableCollection<MyData>();
            data.Add(new MyData { Label = "Safari", Value = safari[0] });
            data.Add(new MyData { Label = "Chrome", Value = chrome[0] });
            data.Add(new MyData { Label = "Android", Value = android_browser[0] });
            data.Add(new MyData { Label = "Opera", Value = opera_mini[0] });
            data.Add(new MyData { Label = "IE", Value = internet_explorer[0] });
            data.Add(new MyData { Label = "Other", Value = other[0] });

            // set flexPie properties
            this.flexPie.ItemsSource = data;
            this.flexPie.StartAngle = 90;
            this.flexPie.LoadAnimation.Duration = 1500;
            //this.flexPie.LoadAnimation.Easing = Easing.SpringIn;
            this.flexPie.HeaderText = TITLE + " 2015";
            this.flexPie.Palette = ChartPalettes.Cyborg;
            this.flexPie.SliceBorderWidth = 1;

			this.flexPie.UpdateAnimation.Duration = 1000;

            // configure pickers
            this.pickerMode.Items.Add(ChartAnimationMode.All.ToString());
            this.pickerMode.Items.Add(ChartAnimationMode.Point.ToString());
            this.pickerMode.SelectedIndex = 1;
            this.pickerMode.SelectedIndexChanged += pickerMode_SelectedIndexChanged;
        }

        // Updates each data value in the pie chart based on the index
        void UpdateData(int index)
        {
            //this.flexPie.Tooltip.Hide();
            foreach (MyData item in data)
            {
                switch(item.Label)
                {
                    case "Safari":
                        item.Value = safari[index];
                        break;
                    case "Chrome":
                        item.Value = chrome[index];
                        break;
                    case "Android":
                        item.Value = android_browser[index];
                        break;
                    case "Opera":
                        item.Value = opera_mini[index];
                        break;
                    case "IE":
                        item.Value = internet_explorer[index];
                        break;
                    case "Other":
                        item.Value = other[index];
                        break;
                }

            }
        }

        void btnUpdate2015_Clicked(object sender, EventArgs e)
        {
            this.flexPie.HeaderText = TITLE + " 2015";
            this.flexPie.Tooltip.Hide();
            UpdateData(0);
        }
        void btnUpdate2014_Clicked(object sender, EventArgs e)
        {
            this.flexPie.HeaderText = TITLE + " 2014";
            this.flexPie.Tooltip.Hide();
            UpdateData(1);
        }
        void btnUpdate2013_Clicked(object sender, EventArgs e)
        {
            this.flexPie.HeaderText = TITLE + " 2013";
            this.flexPie.Tooltip.Hide();
            UpdateData(2);
        }
        void btnUpdate2012_Clicked(object sender, EventArgs e)
        {
            this.flexPie.HeaderText = TITLE + " 2012";
            this.flexPie.Tooltip.Hide();
            UpdateData(3);
        }

        void pickerMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mode = this.pickerMode.Items[this.pickerMode.SelectedIndex];
            this.flexPie.LoadAnimation.AnimationMode = (ChartAnimationMode)(Enum.Parse(typeof(ChartAnimationMode), mode));
        }
    }

    //IMPORTANT: this model implements INotifyPropertyChanged, without this the chart shows no updates to these values.
    class MyData : INotifyPropertyChanged
    {
        private string _label;
        public string Label
        {
            get
            {
                return _label;
            }
            set
            {
                _label = value;
                OnPropertyChanged("Label");
            }
        }
        private double _value;
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
