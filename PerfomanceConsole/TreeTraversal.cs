using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TutorialsPoint.DataStructures;
using TutorialsPoint.MultiThreaded;

namespace PerfomanceConsole
{
    class TreeTraversal
    {
        public static void RunThreadPool()
        {
            var threadPoolTreeTraversal = new ThreadPoolTreeTraversal();
            ThreadPool.QueueUserWorkItem(obj => threadPoolTreeTraversal.RunHost());
            Thread.Sleep(3000);
            threadPoolTreeTraversal.Stop();

            AnalyzeTree(threadPoolTreeTraversal.Tree);
        }

        public static void RunTasks()
        {
            var taskTreeTraversal = new TaskTreeTraversal();
            Task.Run(() => taskTreeTraversal.RunHost());
            Thread.Sleep(3000);
            taskTreeTraversal.Stop();

            AnalyzeTree(taskTreeTraversal.Tree);
        }

        private static void AnalyzeTree(Tree tree)
        {
            var maxHeight = tree.MaxHeight();
            var minHeight = tree.MinHeight();
            var count = tree.CountNodes();
        }
    }
}
