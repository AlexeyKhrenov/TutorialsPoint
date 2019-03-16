using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.Algorithms
{
    class MinMax
    {
        public static int MinIndex(int[] data, int startIndex, int stopIndex)
        {
            int min = startIndex;

            for(int i = startIndex; i < stopIndex; i++)
            {
                if (data[min] > data[i]) min = i;
            }

            return min;
        }

        public static int MaxIndex(int[] data, int startIndex, int stopIndex)
        {
            int max = startIndex;

            for (int i = startIndex; i < stopIndex; i++)
            {
                if (data[max] < data[i]) max = i;
            }

            return max;
        }
    }
}
