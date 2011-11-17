﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Weka.NET.Core.Parsers;
using System.IO;
using Weka.NET.Core;
using Moq;

namespace Weka.NET.Tests.Core.Parser
{
    [TestFixture]
    public class ArffParserTest
    {
        TesteableArffParser parser;

        Mock<IDataSetBuilder> dataSetBuilder;

        [SetUp]
        public void SetupArffParser()
        {
            dataSetBuilder = new Mock<IDataSetBuilder>(); 
            
            parser = new TesteableArffParser();
        }

        [Test]
        public void CanParseArffStream()
        {
        }

        [Test]
        public void CanParseInstance()
        {
        }

        [Test]
        public void CanParseNominalAttribute()
        {

        }

        [Test]
        public void CanParseRelationName()
        {
            ////Given
            var dataSetFileContent = GivenStringStream("@relation somerelation");

            //When
            parser.ParseRelationName(dataSetBuilder.Object, new StreamReader(dataSetFileContent) );

            //Then
            dataSetBuilder.Verify(builder => builder.WithRelationName(It.IsAny<string>()));
        }

        private static MemoryStream GivenStringStream(string str)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(str);
            return new MemoryStream(byteArray);
        }

        private class TesteableArffParser : ArffParser
        {
            public new void ParseRelationName(IDataSetBuilder builder, StreamReader reader)
            {
                base.ParseRelationName(builder, reader);
            }
        }
    }
}