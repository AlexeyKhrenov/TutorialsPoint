using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TutorialsPoint.Groups.Permutations;
using TutorialsPoint.LinearAlgebra;
using TutorialsPoint.NumberTheory;

using TutorialsPoint.MultiThreaded;
using TutorialsPoint.MultiThreaded.Philosophers;
using System.Reflection;

namespace TutorialsPoint
{
    class Program
    {
        public static void Main()
        {
            var shortString = "prefix";
            var longString = "1234567890123456";
            var tooLongString = Guid.NewGuid().ToString();

            var result2 = longString.Substring(0, 16);
            var result3 = tooLongString.Substring(0, 16);
        }
    }

    class DiConfigurator
    {
        public Func<Type> GetDeclaringType()
        {
            return () =>
            {
                return MethodBase.GetCurrentMethod().DeclaringType;
            };
        }
    }
}
