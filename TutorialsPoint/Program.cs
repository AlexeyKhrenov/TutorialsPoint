using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TutorialsPoint.Groups.Permutations;
using TutorialsPoint.LinearAlgebra;
using TutorialsPoint.NumberTheory;

namespace TutorialsPoint
{
    class Program
    {
        public static void Main(string[] args)
        {
            var a = 252;
            var b = 105;
            var result1 = Euclidean.StraightEuclideanAlgorithm(252, 105);
            var result2 = Euclidean.StraightEuclideanAlgorithm(252, 252);
            var result3 = Euclidean.ExtendedEuclideanAlgorithm(252, 252);
            result1 = 0;
        }
    }
}
