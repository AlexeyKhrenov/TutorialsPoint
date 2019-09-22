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
            var list = new List<Dict>()
            {
                new Dict()
                {
                    Id = 1,
                    Text = "Text1"
                },
                new Dict()
                {
                    Id = 2,
                    Text = "Text2"
                }
            };

            var list2 = new List<Dict>()
            {
                 new Dict()
                {
                    Id = 1,
                    Text = "Text3"
                },
                new Dict()
                {
                    Id = 2,
                    Text = "Text4"
                }
            };

            var result = list.Union(list2).Select(x => x.Text).ToList();
        }

        private class Dict
        {
            public int Id;
            public string Text;
        }
    }
}
