using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TutorialsPoint
{
    class SimpleComputeBoundOperationcs
    {
        public static void Run()
        {
            Console.WriteLine("Run method is called");
            ThreadPool.QueueUserWorkItem(ComputeBoundOperation, 5);
            ThreadPool.QueueUserWorkItem(ComputeBoundOperation, 5);

            Console.WriteLine("Main thread: doing some other work here");

            Thread.Sleep(4000);
            Console.WriteLine("Hit <Enter> to end this program");
            Console.ReadKey();
        }

        static void ComputeBoundOperation(Object state)
        {
            Console.WriteLine("In ComputeBoundOperation: "+state);
            Thread.Sleep(1000);
        }

    }
}
