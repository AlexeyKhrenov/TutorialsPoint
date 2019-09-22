using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;

namespace HutterPrize.FrequencyAnalysis
{
    class FrequencyAnalysis
    {
        private Stream stream;
        private byte[] delimiter;
        private byte[] delimeterBuffer;

        public FrequencyAnalysis(Stream stream, byte[] delimiter)
        {
            this.stream = stream;
            this.delimiter = delimiter;

        }

        public FrequencyReport GetNumberOfWords()
        {
            var report = new FrequencyReport();

            var buffer = new List<byte>();
            buffer.Capacity = 1000;

            while (stream.ReadByte(out var ))
            {

            }
        }

        public bool CheckDelimeter()
        {

        }
    }
}
