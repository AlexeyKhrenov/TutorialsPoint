using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TutorialsPoint.Groups.Permutations;
using TutorialsPoint.LinearAlgebra;

namespace TutorialsPoint
{
    class Program
    {
        public static void Main(string[] args)
        {
            var f1 = new Vector(new double[] { 1, 2, 7 });
            var e1 = new Vector(new double[] { 1, 1, -2 });
            var e2 = new Vector(new double[] { 1, -1, 4 });

            e2 = e2.FindPerpendicular(e1);

            var perpendicular1 = f1.FindPerpendicular(e1);

            var _f1 = f1 - perpendicular1;

            var perpendicular2 = f1.FindPerpendicular(e2);

            _f1 = _f1 - perpendicular2;

            var result = f1 - _f1;

            var check1 = _f1 * e1;
            var check2 = _f1 * e2;

            var resultLength = result * result;

            resultLength = 0;
        }
    }
}
