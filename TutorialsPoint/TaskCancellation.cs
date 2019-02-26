using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TutorialsPoint
{
    class TaskCancellation
    {
        public static void Run()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Task<int> t = Task.Run(() => Sum(cts.Token, 100000000));
            cts.Cancel();
            try
            {
                Console.WriteLine("The sum is " + t.Result);
            }
            catch (AggregateException ae)
            {
                ae.Handle(e=>e is OperationCanceledException);
                Console.WriteLine("Sum was canceled");
            }

            Console.ReadKey();
        }

        static Int32 Sum(CancellationToken ct, int n)
        {
            int sum = 0;

            for (; n > 0; n--)
            {
                ct.ThrowIfCancellationRequested();
                checked
                {
                    sum += n;
                }
            }
            return sum;
        }
    }
}
