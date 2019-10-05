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
    public class BitStreamWriterTest
    {
        [TestMethod]
        public void AppendBitsTest1()
        {
            var bitStream = new BitStreamWriter(new MemoryStream());
            var result = bitStream.ToString();
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void AppendBitsTest2()
        {
            var ms = new MemoryStream();
            var bitStream = new BitStreamWriter(ms);
            var a1 = new BitSequence() { Bits = 6, Length = 6 };
            var a2 = new BitSequence() { Bits = 1, Length = 2 };
            var a3 = new BitSequence() { Bits = 7, Length = 5 };
            var expected = "000110 01 00111".Replace(" ", "");
            bitStream.Write(a1);
            bitStream.Write(a2);
            bitStream.Write(a3);
            Assert.AreEqual(bitStream.ToString(), expected);
        }

        [TestMethod]
        public void AppendBitsTest3()
        {
            var bitStream = new BitStreamWriter(new MemoryStream());
            var dict = new Dictionary<BitSequence, string>()
            {
                { new BitSequence() { Bits = 33, Length = 8 }, "00100001" },
                { new BitSequence() { Bits = 4, Length = 3 }, "100" },
                { new BitSequence() { Bits = 7, Length = 5 }, "00111" },
                { new BitSequence() { Bits = 1, Length = 2 }, "01" },
                { new BitSequence() { Bits = 4, Length = 4 }, "0100" },
                { new BitSequence() { Bits = 33, Length = 9 }, "000100001" },
                { new BitSequence() { Bits = 7, Length = 6 }, "000111" },
            };

            string expected = "";

            foreach(var pair in dict)
            {
                expected += pair.Value;
                bitStream.Write(pair.Key);
            }

            Assert.AreEqual(bitStream.ToString(), expected.Replace(" ", ""));
        }
    }
}
