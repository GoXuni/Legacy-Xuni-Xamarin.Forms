using System;
using Xamarin.Forms;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

using FlexChartDemo.Data.Chart;

namespace FlexChartDemo.Data.Repo
{
    public class XmlRepository : Repository
    {
        private static List<ChartSample> _chartSampleList = new List<ChartSample>();

        public XmlRepository()
        {
            var assembly = typeof(XmlRepository).GetTypeInfo().Assembly;

            // get culture
            Stream stream;
            var cultureInfo = System.Globalization.CultureInfo.CurrentCulture;     
            if(cultureInfo.Name.ToLower().StartsWith("jp"))
            {
                stream = assembly.GetManifestResourceStream("FlexChartDemo.Data.FlexChartDemoData_jp.xml");
            }
            else if (cultureInfo.Name.ToLower().StartsWith("zh"))
            {
                stream = assembly.GetManifestResourceStream("FlexChartDemo.Data.FlexChartDemoData_zh.xml");
            }
            else if (cultureInfo.Name.ToLower().StartsWith("ko"))
            {
                stream = assembly.GetManifestResourceStream("FlexChartDemo.Data.FlexChartDemoData_ko.xml");
            }
            else
            {
               stream = assembly.GetManifestResourceStream("FlexChartDemo.Data.FlexChartDemoData_en.xml");
            }
            
            using (var reader = new System.IO.StreamReader(stream))
            {
                var serializer = new XmlSerializer(typeof(List<ChartSample>));
                _chartSampleList = (List<ChartSample>)serializer.Deserialize(reader);
            }
        }

        public List<ChartSample> GetChartSamples()
        {
            return _chartSampleList;
        }
    }
}
