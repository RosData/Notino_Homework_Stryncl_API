using Notino_Homework_Stryncl.Factories;
using Notino_Homework_Stryncl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notino_Homework_Stryncl.Services
{
    public class FormatConvertorFacade
    {
        private readonly IDeserializerFromXml deserializerFromXml;
        private readonly IConvertorFactory convertorFactory;

        public FormatConvertorFacade(IDeserializerFromXml deserializerFromXml, IConvertorFactory convertorFactory)
        {
            this.deserializerFromXml = deserializerFromXml;
            this.convertorFactory = convertorFactory;
        }
        public ConvertedResult GetConvertedResult(DocToConvert docToConvert)
        {
            TargetFormatType requiredFormat = docToConvert.TargetFormat;

            Document document = this.deserializerFromXml.DeserializeFromXml(docToConvert.XmlContent);

            IObjectConvertor convertor = this.convertorFactory.CreateObjectConvertor(requiredFormat);

            string convertedContent = convertor.SerializeObject(document);


            return new ConvertedResult()
            {
                TargetFormat = requiredFormat,
                Content = convertedContent
            };
        }
    }
}
