﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.Groups.Permutations
{
    public class SymmetricGroup : Group<Permutation>
    {
        public override List<Permutation> Set { get; set; }

        public SymmetricGroup(int size) : base()
        {
            // create identical permutation
            int[] e = new int[size];
            for (int i = 0; i < size; i++)
            {
                e[i] = i;
            }
            GenerateRecursive(size, e);
        }

        public override Permutation Operation(Permutation a, Permutation b)
        {
            return a + b;
        }

        // Heap's algorithm -  proposed by B. R. Heap in 1963
        private void GenerateRecursive(int k, int[] sourceArray)
        {
            if (k == 1)
            {
                Set.Add(new Permutation(sourceArray));
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

        private void Swap(ref int a, ref int b)
        {
            a = a - b;
            b = a + b;
            a = b - a;
        }
    }
}
