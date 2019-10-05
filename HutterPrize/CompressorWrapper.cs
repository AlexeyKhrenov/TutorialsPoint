using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

using HutterPrize.HuffmanEncoding;
using HutterPrize.FrequencyAnalysis;

namespace HutterPrize
{
    public class CompressorWrapper
    {
        public void Run()
        {
            using (var file = new FileStream("../../../enwikTest", FileMode.Open, FileAccess.Read))
            {
                var report = new FrequencyAnalyser(1).Run(file);

                var delimeter = report.WordDictionary
                    .Where(x => x.Key.Length == 1)
                    .OrderByDescending(x => x.Value)
                    .Take(10);

                var huffmanEncoding = new HuffmanEncoder(file, report);
                var encoding = huffmanEncoding.Estimate();
            }
        }
    }
}
