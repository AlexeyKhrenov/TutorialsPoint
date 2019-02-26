using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TutorialsPoint.InterlockedConstructs
{
    class MultiWebRequests
    {
        private AsyncCoordinator ac = new AsyncCoordinator();

        private Dictionary<string, object> m_servers = new Dictionary<string, object>()
        {
            { "http://Wintellect.com", null },
            { "http://Microsoft.com", null },
            { "http://1.1.1.1/", null }
        };
        public MultiWebRequests(int timeout = Timeout.Infinite)
        {
            var httpClient = new HttpClient();
            foreach (var server in m_servers.Keys)
            {
                //ac.AboutToBegin(1); replaced:
                ac.AddOptionAboutToBegin();

                httpClient.GetByteArrayAsync(server).ContinueWith(task=>ComputeResult(server, task));
            }

            ac.AllBegun(AllDone, timeout);
        }
        private void ComputeResult(String server, Task<Byte[]> task)
        {
            Object result;
            if (task.Exception != null)
            {
                result = task.Exception.InnerException;
            }
            else
            {
                result = task.Result.Length;
            }

            m_servers[server] = result;
            ac.SingleOperationJustEnded(); //indicate that 1 operation has completed
        }
        public void Cancel() //never used
        {
            ac.Cancel();
        }
        /// <summary>
        /// Called after all web servers respond or cancel is called or timeout occurs
        /// </summary>
        /// <param name="status"></param>
        public void AllDone(CoordinationStatus status)
        {
            switch (status)
            {
                case CoordinationStatus.Cancel:
                    Console.WriteLine("Operation canceled");
                    break;
                case CoordinationStatus.Timeout:
                    Console.WriteLine("Operation timed-out");
                    break;
                case CoordinationStatus.AllDone:
                    foreach (var server in m_servers)
                    {
                        Console.Write("{0} ", server.Key);
                        Object result = server.Value;
                        if (result is Exception)
                        {
                            Console.WriteLine("failed due to {0}.", result.GetType().Name);
                        }
                        else
                        {
                            Console.WriteLine("returned {0:NO} bytes.", result);
                        }
                    }
                    break;
            }
        }

    }
}
