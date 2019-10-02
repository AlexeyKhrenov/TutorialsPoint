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
            var timeZones = TimeZoneInfo.GetSystemTimeZones();
            var length = 0;

            var ids = timeZones.Select(x => x.Id).ToList();
                
            var builder = new StringBuilder();

            foreach(var zone in timeZones)
            {
                builder.Append($"('{zone.Id}'),");
            }
            var result = builder.ToString();

            Console.ReadKey();
        }
    }
}
