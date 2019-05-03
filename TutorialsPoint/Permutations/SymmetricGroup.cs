using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.Permutations
{
    class SymmetricGroup
    {
        private List<int[]> permutations;

        public SymmetricGroup(int size)
        {
            permutations = new List<int[]>();
            if (size == 1)
            {
                permutations.Add(new int[] { 0 });
                return;
            }

            // create identical permutation
            int[] e = new int[size];
            for (int i = 0; i < size; i++)
            {
                e[i] = i;
            }
            permutations.Add(e);

            GenerateRecursive(size, e);
        }

        // Heap's algorithm -  proposed by B. R. Heap in 1963
        private void GenerateRecursive(int k, int[] sourceArray)
        {
            if (k == 1)
            {
                PutToPermutations(sourceArray);
                return;
            }
            else
            {
                GenerateRecursive(k - 1, sourceArray);

                for (int i = 0; i < k - 1; i++)
                {
                    if (k % 2 == 0)
                    {
                        Swap(ref sourceArray[i], ref sourceArray[k - 1]);
                    }
                    else
                    {
                        Swap(ref sourceArray[0], ref sourceArray[k - 1]);
                    }
                    GenerateRecursive(k - 1, sourceArray);
                }
                
            }
        }

        private void PutToPermutations(int[] sourceArray)
        {
            var targetArray = new int[sourceArray.Length];
            sourceArray.CopyTo(targetArray, 0);
            permutations.Add(targetArray);
        }

        private void Swap(ref int a, ref int b)
        {
            a = a - b;
            b = a + b;
            a = b - a;
        }
    }
}
