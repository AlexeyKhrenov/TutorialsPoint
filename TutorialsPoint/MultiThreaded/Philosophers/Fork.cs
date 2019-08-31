using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.MultiThreaded.Philosophers
{
    public class Fork
    {
        public Philosopher Owner { get; set; }

        private object lockObject = new object();

        public bool Capture (Philosopher newChalleger)
        {
            lock (lockObject)
            {
                if (Owner == null)
                {
                    Owner = newChalleger;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Release()
        {
            if(Owner == null)
            {
                throw new ArgumentNullException();
            }

            Owner = null;
        }
    }
}
