using Notino_Homework_Stryncl.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject
{
    public class SerrializeDeserializeTests
    {
        [Fact]
        public void Deserializer_Test()
        {
            string expectedTitle = "nadpis";
            string expectedText = "baf";

            DeserializerFromXml fromXml = new DeserializerFromXml();

            string xml = @$"
                        <root>
            <title>{expectedTitle}</title>
            <text>{expectedText}</text>
                        </root>";

          
            var doc = fromXml.DeserializeFromXml(xml);

            Assert.NotNull(doc);
            Assert.Equal(expectedText, doc.Text);
            Assert.Equal(expectedTitle, doc.Title);

        }
    }
}
