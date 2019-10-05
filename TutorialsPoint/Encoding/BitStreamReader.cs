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

        //method returns BitSequence with 0 length if the stream is empty
        public BitSequence ReadBit()
        {
            // check for the last byte
            if(lastBitSequence)
            {
                if(byteForRead.Length == 0)
                {
                    CanRead = false;
                    return byteForRead;
                }
            }

            if (byteForRead.Length == 0)
            {
                RetrieveNextByte();
            }

            var result = new BitSequence()
            {
                Bits = (byte)(byteForRead.Bits >> (byteForRead.Length - 1)),
                Length = 1
            };

            var dx = BitSequence.ByteLength - byteForRead.Length + 1;
            byteForRead.Bits = (byte)(byteForRead.Bits << dx);
            byteForRead.Bits = (byte)(byteForRead.Bits >> dx);
            byteForRead.Length -= 1;

            return result;
        }

        private void RetrieveNextByte()
        {
            int bits;
            int length;

            if (stream.Position == stream.Length - 2)
            {
                bits = stream.ReadByte();
                length = stream.ReadByte();
                lastBitSequence = true;
            }
            else
            {
                bits = stream.ReadByte();
                length = BitSequence.ByteLength;
            }

            byteForRead = new BitSequence() { Bits = (byte)bits, Length = (byte)length };
        }
    }
}
