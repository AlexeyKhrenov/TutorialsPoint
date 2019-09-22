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
    }
}
