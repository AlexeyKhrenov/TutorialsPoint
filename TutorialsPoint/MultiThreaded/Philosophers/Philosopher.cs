using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TutorialsPoint.MultiThreaded.Philosophers
{
    public class Philosopher
    {
        private Fork leftFork;
        private Fork rightFork;
        private Random random = new Random();
        private string name;

        public Philosopher(string name, Fork leftFork, Fork rightFork)
        {
            this.leftFork = leftFork;
            this.rightFork = rightFork;
            this.name = name;
        }

        public void Run()
        {
            while (true)
            {
                Think();
                if (!TryEat())
                {
                    TryGetForks();
                }
            }
        }

        public bool TryGetForks()
        {
            if(leftFork.Owner != this)
            {
                if (!leftFork.Capture(this))
                {
                    return false;
                };
            }
            if(rightFork.Owner != this)
            {
                return rightFork.Capture(this);
            }

            throw new ArgumentException();
        }

        private void Think()
        {
            Thread.Sleep(random.Next(200));
        }

        private bool TryEat()
        {
            if(leftFork.Owner == this && rightFork.Owner == this)
            {
                Thread.Sleep(random.Next(200));
                Console.WriteLine($"{name}: Eating");
                leftFork.Release();
                rightFork.Release();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
