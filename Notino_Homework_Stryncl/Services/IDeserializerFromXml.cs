using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notino_Homework_Stryncl.Models;

namespace Notino_Homework_Stryncl.Services
{
    public interface IDeserializerFromXml
    {
        Document DeserializeFromXml(string xmlContent);
    }
}
