using System;
using System.Linq;
using System.Collections.Generic;
using Moq;
using Xunit;
using FileEngine.Exceptions;
using FileEngine.Parsers.Concrete;
using Client.Model;
using System.IO;

namespace FileEngine.Tests.Parsers
{
    [Trait("Parser", "Csv")]
    public class CsvParserFixture 
    {
        private readonly CsvParser _sut;
        private string _filepath;

        public CsvParserFixture()
        {
            _sut = new CsvParser();
        }

        [Fact]
        public void Should_ThrowFileNotFoundException_WhenFilepathIsNull()
        {
            _filepath = null;
            Assert.Throws<FileNotFoundException>(() => _sut.Parse<Mock<Data>>(_filepath));
        }

        [Fact]
        public void Should_ThrowFileNotFoundException_WhenFilepathIsEmpty()
        {
            _filepath = string.Empty;
            Assert.Throws<FileNotFoundException>(() => _sut.Parse<Mock<Data>>(_filepath));
        }

        [Fact]
        public void Should_ThrowFileNotFoundException_WhenFilepathIsWrong()
        {
            _filepath = @"C:\Excercise\a.csv";
            Assert.Throws<FileNotFoundException>(() => _sut.Parse<Mock<Data>>(_filepath));
        }

        [Fact]
        public void Should_ThrowEmptyFileException_WhenFileIsEmpty()
        {
            _filepath = @"C:\Excercise\sample4.csv";
            Assert.Throws<EmptyFileException>(() => _sut.Parse<Mock<Data>>(_filepath));
        }

        [Fact]
        public void Should_ThrowInvalidFileException_WhenHeaderDoesntMatchPropertyName()
        {
            _filepath = @"C:\Excercise\sample3.csv";
            Assert.Throws<InvalidFileException>(() => _sut.Parse<Mock<Data>>(_filepath));
        }

        [Fact]
        public void Should_Succeed_WHenParsingAnObject()
        {
            _filepath = @"C:\Excercise\sample2.csv";
            var result = _sut.Parse<Data>(_filepath);

            Assert.NotEmpty(result);
            Assert.True(result.Count() == 2);
        }
    }
}
