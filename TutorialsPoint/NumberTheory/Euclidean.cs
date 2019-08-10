using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.NumberTheory
{
    public class Euclidean
    {
        public static int StraightEuclideanAlgorithm(int a, int b)
        {
            if(a <= 0 || b <= 0)
            {
                throw new ArgumentException();
            }

            while (true)
            {
                var result = CheckForDivision(a, b);
                if (result != 0){
                    return result;
                }
                else
                {
                    if(a > b)
                    {
                        a = a - b;
                    }
                    else
                    {
                        b = b - a;
                    }
                }
            }
        }

        private static int CheckForDivision(int a, int b)
        {
            if (a % b == 0)
            {
                return b;
            }

            if (b % a == 0)
            {
                return a;
            }

            return 0;
        }
    }
}
