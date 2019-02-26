using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TutorialsPoint
{
    internal struct SpinLock
    {
        private int m_ResourseInUse; //0=false (default), 1=true

        public void Enter()
        {
            //this should be used only on not single-CPU machines
            while (true)
            {
                if (Interlocked.Exchange(ref m_ResourseInUse, 1) == 0) return;
            }
        }

        public void Leave()
        {
            Volatile.Write(ref m_ResourseInUse, 0);
        }
    }

    public sealed class SomeResource
    {
        private SpinLock s = new SpinLock();

        public void AccessResource()
        {
            s.Enter();
            // doing something here
            s.Leave();
        }
    }
}
