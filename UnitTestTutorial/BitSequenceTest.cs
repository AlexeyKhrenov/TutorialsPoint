using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TutorialsPoint.Encoding;

namespace UnitTestTutorial
{
    [TestClass]
    public class BitSequenceTest
    {
        [TestMethod]
        public void IntegetToStringTest() //0000 0000 0111 0010 1110 0100 0100 1100
        {
            var dict = new Dictionary<byte, string>()
            {
                {       2, "0000 0010".Replace(" ", "") },
                {       0, "0000 0000".Replace(" ", "") },
            };

            var builder = new StringBuilder();

            foreach (var pair in dict)
            {
                BitSequence.ToBitsString(pair.Key, builder);
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
            };

            var builder = new StringBuilder();

            foreach (var pair in dict)
            {
                BitSequence.ToBitsString(pair.Key, builder);
                var result = builder.ToString();
                Assert.AreEqual(pair.Value, result);
                builder.Clear();
            }
        }

        [TestMethod]
        public void JoinBitSequenceTest1()
        {
            var a1 = new BitSequence() { Bits = 0, Length = 4 };
            var a2 = new BitSequence() { Bits = 4, Length = 4 };
            var expected = "0000 0100".Replace(" ", "");
            JoinBitSequenceTestBase(a1, a2, expected, "");
        }

        [TestMethod]
        public void JoinBitSequenceTest2()
        {
            var a1 = new BitSequence() { Bits = 2, Length = 6 };
            var a2 = new BitSequence() { Bits = 4, Length = 7 };
            var expected = "000010 00".Replace(" ", "");
            JoinBitSequenceTestBase(a1, a2, expected, "00100");
        }

        [TestMethod]
        public void JoinBitSequenceTest3()
        {
            var a1 = new BitSequence() { Bits = 2, Length = 2 };
            var a2 = new BitSequence() { Bits = 8, Length = 6 };
            var expected = "1000 1000".Replace(" ", "");
            JoinBitSequenceTestBase(a1, a2, expected, "");
        }

        private void JoinBitSequenceTestBase(BitSequence a1, BitSequence a2, string expected, string expectedRemainder)
        {
            var builder = new StringBuilder();
            var result = BitSequence.JoinBitSequence(a1, a2, out var remainder);
            BitSequence.ToBitsString(result, builder);
            Assert.AreEqual(builder.ToString(), expected);
            builder.Clear();
            BitSequence.ToBitsString(remainder, builder);
            Assert.AreEqual(builder.ToString(), expectedRemainder);
        }
    }
}
