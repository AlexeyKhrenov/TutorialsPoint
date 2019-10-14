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

namespace TutorialsPoint
{
    class Program
    {
        public static void Main(string[] args)
        {
            int count = 0;

            for (var i = 1; i < 10000; i++)
            {
                if (IsGood(i))
                {
                    count++;
                }
            }

            Console.ReadKey();
        }

        public static bool IsGood(int i)
        {
            var s = i.ToString().ToArray();
            for (var j = 0; j < s.Length - 1; j++)
            {
                var k = j + 1;
                if (s[k] == s[j]) return false;
            }
            return true;
        }
    }
}
