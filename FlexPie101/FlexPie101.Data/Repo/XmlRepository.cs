using System;
using Xamarin.Forms;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

using FlexPieDemo.Data.Chart;

namespace FlexPieDemo.Data.Repo
{
    public class XmlRepository : Repository
    {
        private static List<PieChartSample> _chartSampleList = new List<PieChartSample>();

        public XmlRepository()
        {
            var assembly = typeof(XmlRepository).GetTypeInfo().Assembly;

            //TODO: add culture
            Stream stream = assembly.GetManifestResourceStream("FlexPieDemo.Data.FlexPieDemoData_en.xml");

            using (var reader = new System.IO.StreamReader(stream))
            {
                var serializer = new XmlSerializer(typeof(List<PieChartSample>));
                _chartSampleList = (List<PieChartSample>)serializer.Deserialize(reader);
            }
        }

        public List<PieChartSample> GetPieChartSamples()
        {
            return _chartSampleList;
        }
    }
}
