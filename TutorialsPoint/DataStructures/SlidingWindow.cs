using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.DataStructures
{
    public class SlidingWindow
    {
        private byte?[] buffer;
        private int writePosition;

        public SlidingWindow(int size)
        {
            if(size < 1)
            {
                throw new ArgumentException();
            }

            buffer = new byte?[size];
            writePosition = 0;
        }

        public void Push(byte input)
        {
            if(writePosition == buffer.Length)
            {
                writePosition = 0;
            }
            buffer[writePosition] = input;
            writePosition++;
        }

        public bool TryConvertToArray(out byte[] result)
        {
            result = new byte[buffer.Length];

            if (!IsFilled())
            {
                return false;
            }

            for(var i = 0; i < result.Length; i++)
            {
                if(writePosition == buffer.Length)
                {
                    writePosition = 0;
                }
                result[i] = buffer[writePosition].Value;

                writePosition++;
            }

            return true;
        }

        public bool IsFilled()
        {
            if(buffer[buffer.Length - 1] == null)
            {
                return false;
            }

            if(writePosition != 0 && buffer[writePosition - 1] == null)
            {
                return false;
            }

            return true;
        }

        public void Clean()
        {
            for(var i = 0; i<buffer.Length; i++)
            {
                buffer[i] = null;
            }
            writePosition = 0;
        }

        public bool EqualsArray(byte[] input)
        {
            if(input.Length != buffer.Length)
            {
                throw new ArgumentException("Different buffer and array size");
            }
            int bufferPointer = writePosition + 1;

            for(var i = 0; i < input.Length; i++)
            {
                if(bufferPointer == buffer.Length)
                {
                    bufferPointer = 0;
                }

                if(buffer[bufferPointer] != input[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(buffer[0].ToString());
            builder.Append(", ");

            for(var i = 1; i < buffer.Length; i++)
            {
                builder.Append(buffer[i]);
            }
            return builder.ToString();
        }
    }
}
