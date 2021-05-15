using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Notino_Homework_Stryncl.Models;

namespace Notino_Homework_Stryncl.Services
{
    /// <summary>
    /// Z xml parse na třídu <see cref="Document"/>
    /// </summary>
    public class DeserializerFromXml : IDeserializerFromXml
    {
        public Document DeserializeFromXml(string xmlContent)
        {
            /*
             * když bude xml odpovídat třídě použijeme
             * XmlSerializer serializer = new XmlSerializer(typeof(Document));
             * */

            if (string.IsNullOrEmpty(xmlContent))
            {
                return null;
            }

            var xdoc = XDocument.Parse(xmlContent);
            var doc = new Document
            {
                Title = xdoc.Root.Element("title").Value,
                Text = xdoc.Root.Element("text").Value
            };

            return doc;
        }
    }
}
