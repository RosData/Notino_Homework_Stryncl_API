using Notino_Homework_Stryncl.Factories;
using Notino_Homework_Stryncl.Models;
using Notino_Homework_Stryncl.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject
{
    /// <summary>
    /// Test, že factory vytvoří správný konvertor
    /// </summary>
    public class ConvertorFactoryTests
    {
        [Theory]
        [InlineData(TargetFormatType.Json, typeof(ToJsonConvertor))]
        [InlineData(TargetFormatType.Protobuf, typeof(ToProtobufConvertor))]
        public void ConvertorFactory_CreateConvertor_Test(TargetFormatType targetFormat, Type expectedType)
        {
            ConvertorFactory factory = new ConvertorFactory();

            var convertor = factory.CreateObjectConvertor(targetFormat);

            Assert.NotNull(convertor);
            Assert.IsAssignableFrom(expectedType, convertor);
        }
    }
}
