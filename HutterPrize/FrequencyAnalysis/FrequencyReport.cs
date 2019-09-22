using System;
using System.Collections.Generic;
using System.Text;

namespace HutterPrize.FrequencyAnalysis
{
    class FrequencyReport
    {
        // byte array represents single word
        public Dictionary<byte[], int> WordDictionary => dict;

        private Dictionary<byte[], int> dict { get; set; }

        public byte[] LongestWord { get; set; }
        
        public FrequencyReport()
        {
            dict = new Dictionary<byte[], int>();
            LongestWord = new byte[0];
        }

        public void CountWord(byte[] word)
        {
            if (dict.ContainsKey(word))
            {
                dict[word]++;
            }
            else
            {
                dict.Add(word, 1);
            }
        }
    }
}
