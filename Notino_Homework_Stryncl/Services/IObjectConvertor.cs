using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notino_Homework_Stryncl.Services
{
    public interface IObjectConvertor
    {
        string SerializeObject(object o);
    }
}
