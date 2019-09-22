using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;

namespace TutorialsPoint.DataStructures
{
    public class CircularByteBuffer
    {
        private byte[] buffer;

        // write position
        private int wp = 0;
        // read position
        private int rp = 0;
        // increase factor specifies how fast buffer will grow in case of overflow
        private int increaseFactor = 1;

        public readonly int Size;

        public CircularByteBuffer(int size, int increaseFactor = 2)
        {
            Size = size;
            buffer = new byte[Size];
        }

        public void Write(byte input)
        {
            if(wp == buffer.Length)
            {
                IncreaseBuffer();
            }

            buffer[wp] = input;
            wp++;
        }

        public byte[] Flush(byte input)
        {
            if(rp == wp)
            {
                return new byte[0];
            }

            if(rp < wp)
            {
                var result = new byte[wp - rp];
                for (; rp < wp; rp++)
                {
                    result[result.Length - wp + rp] = buffer[rp];
                }
                rp++;
                return result;
            }
            else
            {
                var result = new byte[buffer.Length - rp + wp];
                for(; rp < buffer.Length; rp++)
                {
                    result[result.Length - wp + rp - buffer.Length] = buffer[rp];
                }
                rp = 0;

                for (; rp < wp; rp++)
                {
                    result[result.Length - wp + rp] = buffer[rp];
                }
                rp++;
                return result;
            }
        }

        private void IncreaseBuffer()
        {
            var newBuffer = new byte[buffer.Length * increaseFactor];
            for(var i = 0; i < buffer.Length; i++)
            {
                newBuffer[i] = buffer[i];
            }
            buffer = newBuffer;
        }
    }
}