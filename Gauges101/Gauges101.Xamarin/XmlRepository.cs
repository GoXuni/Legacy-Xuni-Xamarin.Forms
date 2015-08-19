using System;
using Xamarin.Forms;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Gauges101
{
    public class XmlRepository : Repository
    {
        private static List<Sample> _sampleList = new List<Sample>();

        public XmlRepository()
        {
            var assembly = typeof(XmlRepository).GetTypeInfo().Assembly;

            //TODO: add culture
            Stream stream;
            var cultureInfo = System.Globalization.CultureInfo.CurrentCulture;
            if (cultureInfo.Name.ToLower().StartsWith("jp"))
            {
                stream = assembly.GetManifestResourceStream("Gauges101.GaugeDemoData_jp.xml");
            }
            else if (cultureInfo.Name.ToLower().StartsWith("zh"))
            {
                stream = assembly.GetManifestResourceStream("Gauges101.GaugeDemoData_zh.xml");
            }
            else if (cultureInfo.Name.ToLower().StartsWith("ko"))
            {
                stream = assembly.GetManifestResourceStream("Gauges101.GaugeDemoData_ko.xml");
            }
            else
            {
                stream = assembly.GetManifestResourceStream("Gauges101.GaugeDemoData_en.xml");
            }

            using (var reader = new System.IO.StreamReader(stream))
            {
                var serializer = new XmlSerializer(typeof(List<Sample>));
                _sampleList = (List<Sample>)serializer.Deserialize(reader);
            }
        }

        public List<Sample> GetSamples()
        {
            return _sampleList;
        }
    }
}
