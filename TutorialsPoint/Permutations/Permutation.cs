using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.Permutations
{
    public class Permutation
    {
        private int[] _permutation;

        public int Size => _permutation.Length;

        public Permutation(int[] sourceArray)
        {
            _permutation = new int[sourceArray.Length];
            sourceArray.CopyTo(_permutation, 0);
        }

        public bool IsValid()
        {
            for (int i = 0; i < Size; i++)
            {
                if (_permutation[i] >= Size)
                {
                    return false;
                }

                for (int j = i + 1; j < Size; j++)
                {
                    if (_permutation[i] == _permutation[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int this[int i]
        {
            get { return _permutation[i]; }
        }

        public static bool operator == (Permutation a, Permutation b)
        {
            for (int i = 0; i < a.Size; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator != (Permutation a, Permutation b)
        {
            for (int i = 0; i < a.Size; i++)
            {
                if (a[i] != b[i])
                {
                    return true;
                }
            }
            return false;
        }

        public static Permutation operator + (Permutation a, Permutation b)
        {
            if (a.Size != b.Size)
            {
                throw new InvalidOperationException("Operation cannot be executed on permutations of different size");
            }

            var targetPermutation = new int[a.Size];

            for (int i = 0; i < a.Size; i++)
            {
                targetPermutation[i] = a[b[i]];
            }

            return new Permutation(targetPermutation);
        }
    }
}
