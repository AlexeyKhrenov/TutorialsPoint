using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.Algorithms
{
    //this class implements simple algorithms for sorting arrays
    public class Sorting<T>
    {
        //stable
        public void BubbleSort(int[] data)
        {
            for (int i = data.Length - 1; i > 1; i--)
            {
                for(int j = 0; j < i; j++)
                {
                    if(data[j] > data[j + 1]) Exchange(ref data[j], ref data[j+1]);
                }
            }
        }

        //stable
        public void InsertionSort(int[] data)
        {
            for (int i = 1; i < data.Length; i++)
            {
                for (int j = i; i > 0 && data[i] < data[i - 1]; i--)
                {
                    Exchange(ref data[i], ref data[i - 1]);
                }
            }
        }

        //stable
        public void SelectionSort(int[] data)
        {
            for(int i = 0; i < data.Length - 1; i++)
            {
                var minIndex = MinMax.MinIndex(data, i, data.Length);

                if (data[i] > data[minIndex])
                {
                    Exchange(ref data[i], ref data[minIndex]);
                }
            }
        }

        public void ShellSort(int[] data)
        {
            var gaps = GapsForShellSort(data.Length);
            for(int gapNo = 0; gapNo < gaps.Count; gapNo++)
            {
                int gap = gaps[gapNo];

                for(var i = 0; i < data.Length - gap; i++)
                {
                    for(var j = i; j < data.Length - gap; j += gap)
                    {
                        if (data[j] > data[j + gap]) Exchange(ref data[j], ref data[j + gap]);
                    }
                }
            }
        }

        /// <summary>
        /// Original algorithms for getting gap length for shell sort, introduced
        /// in 1959 by Donald Shell
        /// </summary>
        private List<int> GapsForShellSort(int length)
        {
            List<int> result = new List<int>();
            if (length < 2)
            {
                return result;
            }

            int gap = length;
            while(gap != 1)
            {
                gap = gap / 2;
                result.Add(gap);
            }

            return result;
        }

        // no boxing when a value type is passed by reference
        // in, out, ref words are not considered part of the method signature at compile time

        private void Exchange<T>(ref T a, ref T b) where T : class
        {
            var buffer = a;
            a = b;
            b = buffer;
        }

        private void Exchange(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
    }
}
