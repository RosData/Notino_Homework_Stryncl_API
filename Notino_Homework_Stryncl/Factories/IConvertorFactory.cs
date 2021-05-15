using Notino_Homework_Stryncl.Models;
using Notino_Homework_Stryncl.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notino_Homework_Stryncl.Factories
{
    public interface IConvertorFactory
    {
        IObjectConvertor CreateObjectConvertor(TargetFormatType targetFormat);
    }
}
