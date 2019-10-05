using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HutterPrize.FrequencyAnalysis
{
    public class FrequencyReport
    {
        public long SizeBytes;

        // byte array represents single word
        public Dictionary<Word, int> WordDictionary => dict;

        private Dictionary<Word, int> dict { get; set; }

        public FrequencyReport()
        {
            dict = new Dictionary<Word, int>();
        }

        public void CountWord(byte[] arr)
        {
            var word = new Word(arr);

            if (dict.ContainsKey(word))
            {
                dict[word]++;
            }
            else
            {
                dict.Add(word, 1);
            }
        }

        public void Format()
        {
            dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
