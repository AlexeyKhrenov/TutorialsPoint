using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.Algorithms
{
    public class BinaryEncoding
    {
        // should implement map some day
        public Dictionary<char, byte> Dictionary;
        public Dictionary<byte, char> RevertDictionary;

        public BinaryEncoding(Dictionary<char, byte> dictionary)
        {
            this.Dictionary = dictionary;
            RevertDictionary = new Dictionary<byte, char>();
            foreach(var pair in dictionary)
            {
                if (!RevertDictionary.ContainsKey(pair.Value))
                {
                    RevertDictionary.Add(pair.Value, pair.Key);
                }
                else
                {
                    throw new ArgumentException("The map is no bijective");
                }
            }
        }

        public byte[] Encode(string input)
        {
            var result = new byte[input.Length];

            for(var i = 0; i < input.Length; i++)
            {
                if(Dictionary.TryGetValue(input[i], out var b))
                {
                    result[i] = b;
                }
                else
                {
                    throw new ArgumentException($"Dictionary is not complete. Missing character:{input[i]}.");
                }
            }
            return result;
        }

        public byte[] Decode(byte[] input)
        {
            var result = new byte[input.Length];

            for(var i = 0; i < input.Length; i++)
            {

            }
        }
    }
}
