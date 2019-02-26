using System;
using System.Collections.Generic;
using System.Collections;

namespace CircularBuffer
{
    internal class CircularByteBuffer
    {
        private byte[] buffer;

        private int readPosition = 0;
        private int writePosition = 0;

        public CircularByteBuffer(int size)
        {
            //array size is bigger by 1. This additional cell stands for the situation when WritePosition
            //catches up with (ReadPosition - 1) index and can't write this byte because it'll meet ReadPosition
            buffer = new byte[size + 1];
        }



        private void WriteWorker(byte[] input)
        {
            for(var i = 0; i < input.Length; i++)
            {
                while (true)
                {
                    //check for (writePosition == readPosition) is wrong - it won't start at all
                    if (writePosition + 1 != readPosition)
                    {
                        buffer[writePosition] = input[i];
                        writePosition++;
                        break;
                    }
                }
            }
        }

        private byte[] ReadWorker(int outputLength)
        {
            byte[] output = new byte[outputLength];

            for (var i = 0; i < output.Length; i++)
            {
                while (true)
                {
                    if (readPosition != writePosition)
                    {
                        output[i] = buffer[readPosition];
                        readPosition++;
                        break;
                    }
                }
            }
            return output;
        }
    }
}