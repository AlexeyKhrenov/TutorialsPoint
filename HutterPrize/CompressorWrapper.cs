using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading;

using HutterPrize.HuffmanEncoding;
using HutterPrize.FrequencyAnalysis;

namespace HutterPrize
{
    public class CompressorWrapper
    {
        private Action<double> reportProgress;
        private FrequencyReport report;
        private Timer reportProgressTimer;
        private int reportProgressDelayMs;

        public CompressorWrapper(Action<double> reportProgress, int reportProgressDelayMs)
        {
            this.reportProgress = reportProgress;
            this.reportProgressDelayMs = reportProgressDelayMs;
        }

        public void Run()
        {
            using (var file = new FileStream("../../../enwik8", FileMode.Open, FileAccess.Read))
            {
                reportProgressTimer = new Timer(ReportProgressEvent, new object(), reportProgressDelayMs, reportProgressDelayMs);

                var analyser = new FrequencyAnalyser(2);

                report = analyser.Report;

                analyser.Run(file);

                var delimeter = report.WordDictionary
                    .Where(x => x.Key.Length == 1)
                    .OrderByDescending(x => x.Value)
                    .Take(10);

                var huffmanEncoding = new HuffmanEncoder(file, report);
                var encoding = huffmanEncoding.Estimate();

                reportProgressTimer.Dispose();

                report.FindSuffexes();
            }
        }
        public void ReportProgressEvent(Object state)
        {
            if (report != null)
            {
                reportProgress(Math.Round((double)report.ProcessedBytes * 100/ (double)report.SizeBytes, 2));
            }
        }
    }
}
