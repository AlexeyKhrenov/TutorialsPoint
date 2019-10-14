using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.Functions
{
    public static class Combinatorics
    {
        public static long Cnk(int n, int k)
        {
            long[] numerator = new long[n - k];

            for (var i = n; n > k; i--)
            {
                numerator[i] = i;
            }

            var denominator = new long[k];

            for (var i = 1; i <= k; i++)
            {
                denominator[i - 1] = i;
            }

            throw new NotImplementedException();
        }
    }
}
