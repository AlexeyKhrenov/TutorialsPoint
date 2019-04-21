using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.Functions
{
    public class Iterative
    {
        public static ulong Factorial(int n)
        {
            if(n > 20 || n <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            ulong result = 1;

            while(n != 1)
            {
                result = result * (ulong) n;
                n--;
            }
            return result;
        }
    }
}
