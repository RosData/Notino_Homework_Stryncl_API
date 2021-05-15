using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notino_Homework_Stryncl.Services
{
    public class ToJsonConvertor : IObjectConvertor
    {
        public string SerializeObject(object o)
        {
            if (o == null) throw new ArgumentNullException("o je null");

            return JsonConvert.SerializeObject(o);
        }
    }
}
