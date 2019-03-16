using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint
{
    class Median
    {
        
    }

    internal class RandomArrayGenerator
    {
        public int[] Generate(int min, int max, int length)
        {
            var result = new int[length];

            Random rand = new Random();

            // looping for array is 2 time cheaper
            for (var i = 0; i < length; i++)
            {
                result[i] = rand.Next(min, max);
            }

            return result;
        }
    }
}
