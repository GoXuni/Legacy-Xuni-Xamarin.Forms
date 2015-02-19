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
            Stream stream = assembly.GetManifestResourceStream("Gauges101.GaugeDemoData_en.xml");

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
