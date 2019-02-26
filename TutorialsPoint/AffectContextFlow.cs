using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TutorialsPoint
{
    class AffectContextFlow
    {
        public static void Run()
        {
            CallContext.LogicalSetData("Name", "Jeffrey");

            ThreadPool.QueueUserWorkItem(state => Console.WriteLine("Name={0}", CallContext.GetData("Name")));

            ExecutionContext.SuppressFlow();
            ThreadPool.QueueUserWorkItem(state => Console.WriteLine("Name={0}", CallContext.GetData("Name")));

            ExecutionContext.RestoreFlow();
            ThreadPool.QueueUserWorkItem(state => Console.WriteLine("Name={0}", CallContext.GetData("Name")));

            Console.ReadKey();
        }
    }
}
