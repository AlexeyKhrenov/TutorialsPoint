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

using TutorialsPoint.MultiThreaded.Philosophers;

namespace TutorialsPoint
{
    class Program
    {
        public static void Main(string[] args)
        {
            var table = new Table();
            table.Run();
            Console.ReadKey();
        }
    }
}
