using System;
using System.Collections.Generic;
using System.Text;

namespace HutterPrize.HuffmanEncoding
{
    public class Report
    {
        public long InputBytes;

        public long OutputBytes;

        public double Compression => (double)(InputBytes) / (double)(OutputBytes);
    }
}
