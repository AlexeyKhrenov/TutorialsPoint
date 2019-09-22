using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;

namespace TutorialsPoint.DataStructures
{
    public class CircularByteBufferThreaded
    {
        private byte[] buffer;

        private int readPosition = 0;
        private int writePosition = 0;

        public readonly int Size;

        public CircularByteBufferThreaded(int size)
        {
            //array size is bigger by 1. This additional cell stands for the situation when WritePosition
            //catches up with (ReadPosition - 1) index and can't write this byte because it'll meet ReadPosition
            Size = size + 1;

            buffer = new byte[Size];
        }

        public Task Write(byte[] input, int offset, int count)
        {
            return Task.Factory.StartNew(() => WriteWorker(input, offset, count));
        }

        public Task<int> Read(byte[] output, int offset, int count)
        {
            return Task<int>.Factory.StartNew(() => ReadWorker(output, offset, count));
        }

        private void WriteWorker(byte[] input, int offset, int count)
        {
            for(var i = offset; i < offset + count; i++)
            {
                while (true)
                {
                    int incremented = incrementCircularly(writePosition, Size);

                    //check for (writePosition == readPosition) is wrong - it won't start at all
                    if (incremented != readPosition)
                    {
                        buffer[writePosition] = input[i];
                        writePosition = incremented;
                        break;
                    }
                }
            }
        }

        private int ReadWorker(byte[] output, int offset, int count)
        {
            var i = offset;
            for (; i < offset + count; i++)
            {
                while (true)
                {
                    if (readPosition != writePosition)
                    {
                        output[i] = buffer[readPosition];
                        readPosition = incrementCircularly(readPosition, Size);
                        break;
                    }
                }
            }
            return i - offset;
        }

        private int incrementCircularly(int i, int circleSize)
        {
            return ++i == circleSize ?  0 : i;
        }
    }
}