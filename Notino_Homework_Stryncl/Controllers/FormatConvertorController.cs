using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Notino_Homework_Stryncl.Factories;
using Notino_Homework_Stryncl.Models;
using Notino_Homework_Stryncl.Services;

namespace Notino_Homework_Stryncl.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormatConvertorController : ControllerBase
    {
        private readonly FormatConvertorFacade convertorFacade;
        public FormatConvertorController(FormatConvertorFacade convertorFacade)
        {
            this.convertorFacade = convertorFacade;
        }
        [HttpPost]
        public ConvertedResult Post(DocToConvert docToConvert)
        {
            return this.convertorFacade.GetConvertedResult(docToConvert);          
        }

        [HttpGet]
        public string Get()
        {           
            return "AHOJ";
        }
    }
}
