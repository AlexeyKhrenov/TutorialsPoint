using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using TutorialsPoint;

namespace HutterPrize.FrequencyAnalysis
{
    public class FrequencyReport
    {
        public long SizeBytes;
        public long ProcessedBytes;

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
            dict = dict.OrderByDescending(x => x.Value).ToDictionary();
        }

        public int FindSuffexes()
        {
            var prefixes = 0;
            var suffixes = 0;

            var minLength = dict.Min(x => x.Key.Length);
            var maxLength = dict.Min(x => x.Key.Length);

            var currentGen = WordDictionary.Where(x => x.Key.Length == minLength).ToDictionary();
            Dictionary<Word, int> nextGen;

            for (var i = minLength; i < maxLength; i++)
            {
                nextGen = WordDictionary.Where(x => x.Key.Length == i + 1).ToDictionary();

                foreach (var word in currentGen)
                {
                    foreach (var nextWord in nextGen)
                    {
                        if (word.Value == nextWord.Value)
                        {
                            if (word.Key.IsSuffixOf(nextWord.Key))
                            {
                                suffixes++;
                            }
                            if (word.Key.IsPrefixOf(nextWord.Key))
                            {
                                prefixes++;
                            }
                        }
                    }
                }

                currentGen = nextGen;
            }

            return prefixes;
        }
    }
}
