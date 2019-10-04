using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.Encoding
{
    public class BitStreamReader
    {
        public bool CanRead { get; private set; }

        private Stream stream;
        private BitSequence byteForRead;

        private bool lastBitSequence = false;

        public BitStreamReader(Stream stream)
        {
            if (stream.Length < 2)
            {
                throw new ArgumentException("Invalid bit stream");
            }

            CanRead = true;
            this.stream = stream;

            stream.Position = 0;
            var bits = stream.ReadByte();
            var length = BitSequence.ByteLength;
            byteForRead = new BitSequence() { Bits = (byte) bits, Length = length };
        }

        public BitSequence ReadBit()
        {
            if(lastBitSequence)
            {
                if(byteForRead.Length == 0)
                {
                    CanRead = false;
                    return byteForRead;
                }

                if(byteForRead.Length == 1)
                {
                    var result = byteForRead;
                    byteForRead = new BitSequence();
                    return result;
                }

                return byteForRead;
            }

            if (lastBitSequence)
            {
                var bits = byteForRead >> byteForRead.Length - 1;
            }

            if(stream.Position == Length - 1)
            {
                lastBitSequence
            }
        }
    }
}
