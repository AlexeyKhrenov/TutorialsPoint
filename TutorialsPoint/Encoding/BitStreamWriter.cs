using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.Encoding
{
    public class BitStreamWriter
    {
        public bool CanWrite { get; private set; }

        private Stream stream;
        private BitSequence IncompleteLastInteger;

        public BitStreamWriter(Stream stream)
        {
            if (stream.Length != 0)
            {
                throw new ArgumentException("Bit stream is not empty");
            }

            CanWrite = true;
            this.stream = stream;
            IncompleteLastInteger = new BitSequence();
        }

        public void Write(byte input)
        {
            var bitSequence = new BitSequence() { Bits = input, Length = BitSequence.ByteLength };
            Write(bitSequence);
        }

        public void Write(BitSequence input)
        {
            IncompleteLastInteger = BitSequence.JoinBitSequence(IncompleteLastInteger, input, out var remainder);
            if (remainder.Length != 0)
            {
                stream.WriteByte(IncompleteLastInteger.Bits);
                IncompleteLastInteger = remainder;
            }
        }

        public void EndWrite()
        {
            stream.WriteByte(IncompleteLastInteger.Bits);
            stream.WriteByte(IncompleteLastInteger.Length);
            CanWrite = false;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            var position = stream.Position;

            if (position > int.MaxValue)
            {
                throw new ArgumentException("The underlying stream is too long");
            }

            var result = new byte[position];

            stream.Position = 0;
            stream.Read(result, 0, (int) position);

            for(var i = 0; i < result.Length; i++)
            {
                BitSequence.ToBitsString(result[i], builder);
            }
            
            BitSequence.ToBitsString(IncompleteLastInteger, builder);
            return builder.ToString();
        }
    }
}
