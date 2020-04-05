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
            var threadPoolTreeTraversal = new ThreadPoolTreeTraversal();
            ThreadPool.QueueUserWorkItem(obj => threadPoolTreeTraversal.RunHost());
            Thread.Sleep(3000);
            threadPoolTreeTraversal.Stop();

            var tree = threadPoolTreeTraversal.Tree;
            var maxHeight = tree.MaxHeight();
            var minHeight = tree.MinHeight();
        }
    }
}
