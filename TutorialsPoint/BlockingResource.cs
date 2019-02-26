using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TutorialsPoint
{
    class BlockingResource
    {
        public static void DoWork(object ch)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write(ch);
                Thread.Sleep(50);
            }
        }
    }
}
