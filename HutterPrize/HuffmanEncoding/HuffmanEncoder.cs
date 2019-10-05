using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

using HutterPrize.FrequencyAnalysis;

namespace HutterPrize.HuffmanEncoding
{
    public class HuffmanEncoder
    {
        public Stream Stream;
        public FrequencyReport FrequencyReport;
        public HuffmanTree Tree;

        public HuffmanEncoder(Stream stream, FrequencyReport frequencyReport)
        {
            Stream = stream;
            FrequencyReport = frequencyReport;
            Tree = new HuffmanTree(frequencyReport.WordDictionary);
            Tree.BuildTree();
            Tree.EncodeTree();
        }

        public Report Estimate()
        {
            var report = new Report();

            report.InputBytes = FrequencyReport.SizeBytes;

            long outputBits = 0;
            int i = 1;

            foreach (var word in FrequencyReport.WordDictionary)
            {
                var bitsLength = Tree.Encoded[word.Key].Length;
                var quantity = word.Value;
                outputBits += bitsLength * quantity;
            }

            report.OutputBytes = outputBits / 8 + 1;

            return report;
        }
    }
}
