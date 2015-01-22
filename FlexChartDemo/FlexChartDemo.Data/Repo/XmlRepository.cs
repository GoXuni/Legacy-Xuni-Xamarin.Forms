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

            //TODO: add culture
            Stream stream = assembly.GetManifestResourceStream("FlexChartDemo.Data.FlexChartDemoData_en.xml");

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
