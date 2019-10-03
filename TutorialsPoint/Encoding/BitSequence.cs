using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.Encoding
{
    public struct BitSequence
    {
        public byte Bits;
        public byte Length;

        public static byte ByteLength = 8;

        // todo - make this method with aggressive inlining
        public static BitSequence JoinBitSequence(
            BitSequence a,
            BitSequence b,
            out BitSequence remainder)
        {
            // represents current byte free length
            int ex = ByteLength - a.Length;
            var result = new BitSequence();
            remainder = new BitSequence();

            if (ex >= b.Length)
            {
                int ab = a.Bits << b.Length;
                result.Bits = (byte)ab;
                result.Bits |= b.Bits;
                result.Length = (byte)(b.Length + a.Length);
            }
            else
            {
                int ab = a.Bits << ex;
                result.Bits = (byte)ab;
                if (ex != 0)
                {
                    result.Bits |= (byte)(b.Bits >> (ByteLength - ex));
                }
                result.Length = ByteLength;
                remainder.Bits = (byte)(b.Bits << ex >> ex);
                remainder.Length = (byte)(b.Length - ex);
            }

            return result;
        }

        public static void ToBitsString(byte a, StringBuilder builder)
        {
            ToBitsString(new BitSequence() { Bits = a, Length = ByteLength }, builder);
        }

        public static void ToBitsString(BitSequence a, StringBuilder builder)
        {
            byte[] result = new byte[a.Length];

            var bits = a.Bits;

            for (var i = 0; i < a.Length; i++)
            {
                result[i] = (byte)(bits % 2);
                bits = (byte)(bits / 2);
            }

            for (var i = result.Length - 1; i >= 0; i--)
            {
                builder.Append(result[i]);
            }
        }
    }
}
