using System;
using FileEngine.Parsers;
using FileEngine.Parsers.Concrete;
using Moq;
using Xunit;

namespace FileEngine.Tests.Parsers
{
    [Trait("Parser", "Xml")]
    public class XmlParserFixture 
    {
        private readonly IParser _sut;
        private string _filepath;

        public XmlParserFixture()
        {
            _sut = new XmlParser();
        }

        [Fact]
        public void Should_ThrowArgumentExcepiton_WhenFilepathIsNull()
        {
            _filepath = null;
            Assert.Throws<ArgumentException>(() => _sut.Parse<Mock<Record>>(_filepath));
        }

        [Fact]
        public void Should_ThrowArgumentExcepiton_WhenFilepathIsEmpty()
        {
            _filepath = string.Empty;
            Assert.Throws<ArgumentException>(() => _sut.Parse<Mock<Record>>(_filepath));
        }

        [Fact]
        public void Should_ThrowArgumentExcepiton_WhenFilepathIsWrong()
        {
            _filepath = @"C:\Excercise\sample\a.xml";
            Assert.Throws<ArgumentException>(() => _sut.Parse<Mock<Record>>(_filepath));
        }
    }
}
