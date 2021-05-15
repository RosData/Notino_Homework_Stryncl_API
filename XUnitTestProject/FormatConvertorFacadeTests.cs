using Moq;
using Notino_Homework_Stryncl.Factories;
using Notino_Homework_Stryncl.Models;
using Notino_Homework_Stryncl.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject
{
    public class FormatConvertorFacadeTests
    {
        private Mock<IConvertorFactory> convertorFactoryMock;
        private Mock<IDeserializerFromXml> deserializerFromXmlMock;
        Mock<IObjectConvertor> jsonConvertorMock;

        private Dictionary<TargetFormatType, IObjectConvertor> expectedConvertors = new Dictionary<TargetFormatType, IObjectConvertor>();

        private static Notino_Homework_Stryncl.Models.Document expectedDocument =
            new Notino_Homework_Stryncl.Models.Document { Text = "Ahoj", Title = "Baf" };

        private const string ExpectedJsonContent = "{json}";

        public FormatConvertorFacadeTests()
        {
            // mock deserializer 
            deserializerFromXmlMock = new Mock<IDeserializerFromXml>();

            deserializerFromXmlMock.Setup(x => x.DeserializeFromXml(It.IsAny<string>()))
                .Returns(expectedDocument);

            // mock dva implementovane konvertory
            this.jsonConvertorMock = new Mock<IObjectConvertor>();
            jsonConvertorMock.Setup(x => x.SerializeObject(It.IsAny<object>()))
                .Returns(ExpectedJsonContent);

            var protobufConvertorMock = new Mock<IObjectConvertor>();
            protobufConvertorMock.Setup(x => x.SerializeObject(It.IsAny<object>()))
                .Returns("protobuf");

            // přidat do dictionary
            expectedConvertors.Add(TargetFormatType.Json, jsonConvertorMock.Object);
            expectedConvertors.Add(TargetFormatType.Protobuf, protobufConvertorMock.Object);

            // mock IConvertorFactory => a metoda CreateObjectConvertor
            convertorFactoryMock = new Mock<IConvertorFactory>();
            convertorFactoryMock.Setup(x => x.CreateObjectConvertor(It.IsAny<TargetFormatType>()))
                .Returns<TargetFormatType>((t) =>
                {
                    return expectedConvertors[t];
                }
            );            
        }

        [Fact]
        public void FormatConvertorFacade_Call_All_Required_Methods_Test()
        {
            string expectedInputXmlContent = "cokoli";

            FormatConvertorFacade formatConvertorFacade = new FormatConvertorFacade(deserializerFromXmlMock.Object, convertorFactoryMock.Object);

            // objekt ke konverzi
            DocToConvert docToConvert = new DocToConvert
            {
                TargetFormat = TargetFormatType.Json,
                XmlContent = expectedInputXmlContent,
            };

            ConvertedResult convertedResult = formatConvertorFacade.GetConvertedResult(docToConvert);

            // ASSERT
            // že voláme metodu DeserializeFromXml s xml content z dodaného DocToConvert objektu
            deserializerFromXmlMock.Verify(x => x.DeserializeFromXml(It.Is<string>(s => s.Equals(expectedInputXmlContent))), Times.Once);
            // CreateObjectConvertor se správným TargetFormat
            convertorFactoryMock.Verify(x => x.CreateObjectConvertor(docToConvert.TargetFormat), Times.Once);

            //metoda SerializeObject zavolána s očekávaným objektem
            this.jsonConvertorMock.Verify(x => x.SerializeObject(It.Is<Notino_Homework_Stryncl.Models.Document>(d => d.Title == expectedDocument.Title && d.Text == expectedDocument.Text)), Times.Once);

            Assert.Equal(docToConvert.TargetFormat, convertedResult.TargetFormat);
            Assert.Equal(ExpectedJsonContent, convertedResult.Content);

        }
       
    }
}
