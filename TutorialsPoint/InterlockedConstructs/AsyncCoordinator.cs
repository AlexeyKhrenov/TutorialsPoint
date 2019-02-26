using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TutorialsPoint.InterlockedConstructs
{
    class AsyncCoordinator
    {
        private int m_opCount = 1;
        private int m_statusReported = 0;
        private Action<CoordinationStatus> callBackAction;
        private Timer timer;

        public void AboutToBegin(int opsToAdd = 1)
        {
            Interlocked.Add(ref m_opCount, opsToAdd);
        }

        public void AddOptionAboutToBegin()
        {
            Interlocked.Increment(ref m_opCount);
        }

        public void SingleOperationJustEnded()
        {
            if (Interlocked.Decrement(ref m_opCount) == 0)
            {
                ReportStatus(CoordinationStatus.AllDone);
            }
        }
        public void AllBegun(Action<CoordinationStatus> callBack, int timeout = Timeout.Infinite)
        {
            callBackAction = callBack;
            //if (timeout != Timeout.Infinite)
            //{
                timer = new Timer(TimeExpired, null, timeout, Timeout.Infinite);
            //}
            SingleOperationJustEnded();
        }

        private void TimeExpired(Object o)
        {
            ReportStatus(CoordinationStatus.Timeout);
        }

        public void Cancel()
        {
            ReportStatus(CoordinationStatus.Cancel);
        }

        private void ReportStatus(CoordinationStatus status)
        {
            if (Interlocked.Exchange(ref m_statusReported, 1) == 0) callBackAction(status);
        }
    }
}
