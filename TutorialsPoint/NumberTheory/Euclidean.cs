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

        public static Tuple<int, int> ExtendedEuclideanAlgorithm(int a, int b)
        {
            throw new NotImplementedException();

            if (a <= 0 || b <= 0)
            {
                throw new ArgumentException();
            }

            var a_ = a > b ? a : b;
            var b_ = a > b ? b : a;

            List<int> result = new List<int>() { a_, b_ , a_ % b_};
            List<int> coeff = new List<int>() { a_ / b_ };

            while (result.Last() != 0)
            {
                var lastResultIndex = result.Count - 1;
                var newResult = result[lastResultIndex - 1] % result[lastResultIndex];
                var newCoeff = result[lastResultIndex - 1] / result[lastResultIndex];
                coeff.Add(newCoeff);
                result.Add(newResult);
            }

            var gcd = result[result.Count - 2];

            var x = 0;

            foreach(var c in coeff)
            {
                x = x + c + 1;
            }
            x = x - coeff.Last() - 1;

            var y = -x + 1 + coeff[0];
            if(coeff.Count() > 1)
            {
                y += coeff[1];
            }

            if(a == a_)
            {
                return new Tuple<int, int>(y, x);
            }
            else
            {
                return new Tuple<int, int>(x, y);
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
