using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TutorialsPoint
{
    class BadOptimization
    {
        private static bool s_stopWorker = false;

        public static void Run()
        {
            Console.WriteLine("Main: letting worker run for 5 seconds");
            Thread d = new Thread(Worker);
            d.Start();
            Thread.Sleep(5000);
            s_stopWorker = true;
            Console.WriteLine("Main: waiting for worker to stop");
            d.Join();

            Console.ReadKey();
        }

        private static void Worker(Object o)
        {
            int x = 0;
            while (!s_stopWorker) x++;
            Console.WriteLine("Worker: stopped when x={0}",x);
        }
    }
}
