using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TutorialsPoint.Encoding;

namespace UnitTestTutorial
{
    [TestClass]
    public class BitStreamTest
    {
        [TestMethod]
        public void IntegetToStringTest() //0000 0000 0111 0010 1110 0100 0100 1100
        {
            var dict = new Dictionary<int, string>()
            {
                {       2, "0000 0000 0000 0000 0000 0000 0000 0010".Replace(" ", "") },
                {       0, "0000 0000 0000 0000 0000 0000 0000 0000".Replace(" ", "") },
                { 7529548, "0000 0000 0111 0010 1110 0100 0100 1100".Replace(" ", "") }
            };

            var builder = new StringBuilder();

            foreach(var pair in dict)
            {
                BitStream.ToBitsString(pair.Key, builder);
                var result = builder.ToString();
                Assert.AreEqual(pair.Value, result);
                builder.Clear();
            }
        }

        [TestMethod]
        public void BitSequenceToStringTest()
        {
            var dict = new Dictionary<BitSequence, string>()
            {
                { new BitSequence(){ Bits = 0, Length = 0 }, "" },
                { new BitSequence() { Bits = 3, Length = 4 }, "0011"},
                { new BitSequence() { Bits = 7529548, Length = 24 }, "0111 0010 1110 0100 0100 1100".Replace(" ", "") }
            };

            var builder = new StringBuilder();

            foreach(var pair in dict)
            {
                BitStream.ToBitsString(pair.Key, builder);
                var result = builder.ToString();
                Assert.AreEqual(pair.Value, result);
                builder.Clear();
            }
        }
    }
}
