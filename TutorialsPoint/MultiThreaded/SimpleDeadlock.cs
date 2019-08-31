using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TutorialsPoint.MultiThreaded
{
    public class SimpleDeadlock
    {
        private object lock1 = new object();
        private object lock2 = new object();


        public void Run()
        {
            new Thread(Worker1).Start();
            new Thread(Worker2).Start();
        }

        private void Worker1()
        {
            while (true)
            {
                lock (lock1)
                {
                    lock (lock2)
                    {
                        Console.WriteLine("1");
                        Thread.Sleep(10);
                    }
                }
            }
        }

        private void Worker2()
        {
            while (true)
            {
                lock (lock2)
                {
                    lock (lock1)
                    {
                        Console.WriteLine("2");
                        Thread.Sleep(10);
                    }
                }
            }
        }
    }
}
