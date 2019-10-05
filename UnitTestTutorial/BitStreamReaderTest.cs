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
    public class BitStreamReaderTest
    {
        [TestMethod]
        public void BitStreamReaderTest1()
        {
            var ms = new MemoryStream();
            var bitStreamWriter = new BitStreamWriter(ms);
            var a1 = new BitSequence() { Bits = 6, Length = 6 };
            var a2 = new BitSequence() { Bits = 1, Length = 2 };
            var a3 = new BitSequence() { Bits = 7, Length = 5 };
            var expected = "000110 01 00111".Replace(" ", "").ToArray().Select(x => int.Parse(x.ToString())).ToList();
            bitStreamWriter.Write(a1);
            bitStreamWriter.Write(a2);
            bitStreamWriter.Write(a3);
            bitStreamWriter.EndWrite();

            Assert.IsFalse(bitStreamWriter.CanWrite);

            var bitStreamReader = new BitStreamReader(ms);

            BitSequence buffer;
            var result = new List<int>();
            do
            {
                buffer = bitStreamReader.ReadBit();
                result.Add(buffer.Bits);
            }
            while (buffer.Length != 0);

            Assert.IsFalse(bitStreamReader.CanRead);
        }
    }
}
