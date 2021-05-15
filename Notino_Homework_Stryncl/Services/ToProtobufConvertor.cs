using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notino_Homework_Stryncl.Services
{
    public class ToProtobufConvertor : IObjectConvertor
    {
        public string SerializeObject(object o)
        {
            if (o == null) throw new ArgumentNullException("o je null");

            // TODO nejaky system konvezre
            /*
             * Google.Protobuf
             * */
            // konvertovany objekt nejaky Google.Protobuf konvertorem
            byte[] data = new byte[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // do stringu jako Base64 (posilame jako Http vysledek tak i xml nebo json bz udělal base64)
            string convertedResult = Convert.ToBase64String(data, Base64FormattingOptions.None);

            return convertedResult;
        }

    }
}
