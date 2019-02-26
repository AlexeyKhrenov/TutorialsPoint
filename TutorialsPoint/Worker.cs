using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TutorialsPoint
{
    class Worker
    {
        private string name;
        private int loop;

        public Worker(string name, int loop)
        {
            this.name = name;
            this.loop = loop;
        }

        public void DoWork(object value)
        {
            for (int i = 0; i < loop; i++)
            {
                Console.WriteLine(name + " working " + value);
                Thread.Sleep(50);
            }
        }
    }
}
