using System;
using System.IO;
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
        public void Should_ThrowFileNotFoundException_WhenFilepathIsNull()
        {
            _filepath = null;
            Assert.Throws<FileNotFoundException>(() => _sut.Parse<Mock<Record>>(_filepath));
        }

        [Fact]
        public void Should_ThrowFileNotFoundException_WhenFilepathIsEmpty()
        {
            _filepath = string.Empty;
            Assert.Throws<FileNotFoundException>(() => _sut.Parse<Mock<Record>>(_filepath));
        }

        [Fact]
        public void Should_ThrowFileNotFoundException_WhenFilepathIsInvalid()
        {
            _filepath = @"C:\Excercise\sample\a.xml";
            Assert.Throws<FileNotFoundException>(() => _sut.Parse<Mock<Record>>(_filepath));
        }

        [Fact]
        public void Should_ThrowInvalidFileException_WhenHeaderDoesntMatchPropertyName()
        {

        }
    }
}
