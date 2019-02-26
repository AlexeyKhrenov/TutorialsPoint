using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TutorialsPoint
{
    class Cancellation
    {
        public static void Run()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            ThreadPool.QueueUserWorkItem(o => Count(cts.Token, 1000));

            Console.WriteLine("Press <Enter> to cancel the operation");
            Console.ReadLine();

            cts.Cancel();
            Console.ReadKey();
        }

        private static void Count(CancellationToken token, int countTo)
        {
            for (int i = 0; i < countTo; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Count is cancelled");
                    break;
                }
                Console.WriteLine(i);
                Thread.Sleep(200);
            }
            Console.WriteLine("Count is done");
        }
    }
}
