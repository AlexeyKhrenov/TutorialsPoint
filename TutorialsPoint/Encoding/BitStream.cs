using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.Encoding
{
    public struct BitSequence
    {
        public int Bits;
        public byte Length;
    }

    public struct Bit
    {
        byte Value;
    }

    public class BitStream
    {
        public static long Position;
        public List<int> Sequence;
        public BitSequence IncompleteLastInteger;
        private const int bl = 32; // represents 4-byte length

        public void AppendBits(BitSequence input)
        {
            var index = Position / bl;

            Position += input.Length;
        }

        // todo - make this method with aggressive inlining
        public static BitSequence JoinBitSequence(
            BitSequence a, 
            BitSequence b, 
            out BitSequence remainder)
        {
            // represents current byte free length
            int ex = bl - a.Length;
            var result = new BitSequence();
            remainder = new BitSequence();

            if(ex > b.Length)
            {
                int ab = b.Bits << a.Length;
                result.Bits &= a.Bits;
                result.Bits &= ab;
                result.Length = (byte)(b.Length + a.Length);
            }
            else
            {
                int ab = b.Bits << a.Length;
                result.Bits &= a.Bits;
                result.Bits &= b.Bits;
                result.Length = bl;
                remainder.Bits = b.Bits >> ex;
                remainder.Length = (byte)(b.Length - ex);
            }

            return result;
        }

        public static void ToBitsString(int a, StringBuilder builder)
        {
            ToBitsString(new BitSequence() { Bits = a, Length = bl }, builder);
        }

        public static void ToBitsString(BitSequence a, StringBuilder builder)
        {
            byte[] result = new byte[a.Length];

            var bits = a.Bits;

            for(var i = 0; i < a.Length; i++)
            {
                result[i] = (byte)(bits % 2);
                bits = bits / 2;
            }

            for(var i = result.Length - 1; i >= 0; i--)
            {
                builder.Append(result[i]);
            }
        }
    }
}
