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
