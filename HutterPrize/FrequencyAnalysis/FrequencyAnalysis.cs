using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;

using TutorialsPoint.DataStructures;

namespace HutterPrize.FrequencyAnalysis
{
    class FrequencyAnalyser
    {
        private SlidingWindow[] windows;

        public FrequencyReport Report => report;
        private FrequencyReport report = new FrequencyReport();

        public FrequencyAnalyser(int longestSlidingWindow)
        {
            if(longestSlidingWindow < 1)
            {
                throw new ArgumentException();
            }

            windows = new SlidingWindow[longestSlidingWindow];

            for(var i = 1; i <= longestSlidingWindow; i++)
            {
                windows[i - 1] = new SlidingWindow(i);
            }
        }

        public void Run(Stream stream)
        {
            report.SizeBytes = stream.Length;

            int b = stream.ReadByte();

            while (b != -1)
            {
                report.ProcessedBytes++;

                for (var i = 0; i < windows.Length; i++)
                {
                    windows[i].Push((byte) b);
                    if(windows[i].TryConvertToArray(out var result))
                    {
                        report.CountWord(result);
                    }
                }

                b = stream.ReadByte();
            }
        }
    }
}
