using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TutorialsPoint.MultiThreaded.Philosophers
{
    public class Table
    {
        private List<Philosopher> philosophers = new List<Philosopher>();

        public Table()
        {
            var forks = new Fork[5];

            for(var i = 0; i < forks.Length; i++)
            {
                forks[i] = new Fork();
            }

            var k = 0;
            philosophers.Add(new Philosopher("Socrat", forks[k], forks[++k]));
            philosophers.Add(new Philosopher("Pifagor", forks[k], forks[++k]));
            philosophers.Add(new Philosopher("Eyler", forks[k], forks[++k]));
            philosophers.Add(new Philosopher("Michael", forks[k], forks[++k]));
            philosophers.Add(new Philosopher("Shakespear", forks[k], forks[0]));
        }

        public void Run()
        {
            foreach(var philosopher in philosophers)
            {
                Thread thread = new Thread(new ThreadStart(philosopher.Run));
                thread.Start();
            }
        }
    }
}
