using System;
using System.Collections.Generic;
using System.Text;

namespace HutterPrize.FrequencyAnalysis
{
    public class Word : IEquatable<Word>
    {
        private byte[] _arr;

        public int Length => _arr.Length;

        public Word(byte[] input)
        {
            if(input == null)
            {
                throw new ArgumentNullException();
            }

            _arr = input;
        }

        public override string ToString()
        {
            return Encoding.ASCII.GetString(_arr);
        }

        private int _hash = -1;

        public override int GetHashCode()
        {
            int result = 0;
            for(var i = 0; i< _arr.Length; i++)
            {
                result = result << (i * 2);
                result += _arr[i];
                result = result >> (i * 2);
            }
            return result;
        }

        public bool Equals(Word other)
        {
            if(_arr.Length != other.Length)
            {
                return false;
            }

            for(var i = 0; i < _arr.Length; i++)
            {
                if(_arr[i] != other._arr[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
