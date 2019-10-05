using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.Encoding
{
    public struct LongBitSequence
    {
        public byte[] Bytes;
        public BitSequence LeftOver;
        public int Length => Bytes.Length + LeftOver.Length;

        public LongBitSequence(BitSequence leftOver) : this(null, leftOver)
        {
        }

        public LongBitSequence(byte[] bytes, BitSequence? leftOver)
        {
            if (bytes != null)
            {
                Bytes = bytes;
            }
            else
            {
                Bytes = new byte[0];
            }

            if (leftOver != null)
            {
                LeftOver = leftOver.Value;
                CheckLeftOver();
            }
            else
            {
                LeftOver = new BitSequence();
            }
        }

        private void CheckLeftOver()
        {
            if (LeftOver.Length == BitSequence.ByteLength)
            {
                AddBitSequenceToBytes(LeftOver);
                LeftOver = new BitSequence();
            }
        }

        private void AddBitSequenceToBytes(BitSequence bitSequence)
        {
            // there's no need to use List only to add one element each time
            var newbytes = new byte[Bytes.Length + 1];
            for (var i = 0; i < Bytes.Length; i++)
            {
                newbytes[i] = Bytes[i];
            }
            newbytes[Bytes.Length] = bitSequence.Bits;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            for (var i = 0; i < Bytes.Length; i++)
            {
                BitSequence.ToBitsString(new BitSequence() { Bits = Bytes[i], Length = BitSequence.ByteLength }, builder);
            }
            BitSequence.ToBitsString(LeftOver, builder);
            return builder.ToString();
        }

        public void Add_1_AtEnd()
        {
            AddAtEnd(1);
        }

        public void Add_0_AtEnd()
        {
            AddAtEnd(0);
        }

        // only 1 or 0 accepted
        private void AddAtEnd(byte input)
        {
            CheckLeftOver();
            LeftOver.Bits = (byte)(LeftOver.Bits << 1);
            LeftOver.Bits += input;
            LeftOver.Length++;
        }
    }
}
