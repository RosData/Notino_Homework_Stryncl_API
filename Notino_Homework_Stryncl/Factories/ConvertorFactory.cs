using Notino_Homework_Stryncl.Models;
using Notino_Homework_Stryncl.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notino_Homework_Stryncl.Factories
{
    /// <summary>
    /// Konvertor dle požadovaného formátu
    /// </summary>
    public class ConvertorFactory : IConvertorFactory
    {
        public IObjectConvertor CreateObjectConvertor(TargetFormatType targetFormat)
        {
            switch (targetFormat)
            {
                case TargetFormatType.Json:
                    return new ToJsonConvertor();
                    
                case TargetFormatType.Protobuf:
                    return new ToProtobufConvertor();

                // další formáty se jen přidají další konvertory
                //case TargetFormatType.XY:
                //    return new ToXYConvertor();

                default:
                    throw new Exception($"Neimplementovay format {targetFormat}");
                    
            }
        }
    }
}
