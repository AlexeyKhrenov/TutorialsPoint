using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TutorialsPoint.DataStructures;

namespace TutorialsPoint.MultiThreaded
{
    public class ThreadPoolTreeTraversal
    {
        public Tree Tree;

        private Random rand;
        private CancellationTokenSource cts;

        public ThreadPoolTreeTraversal()
        {
            cts = new CancellationTokenSource();
            rand = new Random();
            Tree = new Tree();
        }

        public void RunHost()
        {
            TraverseNode(cts.Token, Tree.Root);
        }

        public void Stop()
        {
            cts.Cancel();
        }

        public void TraverseNode(CancellationToken token, Node node)
        {
            var randNumberOfNodes = rand.Next(10);
            node.ChildNodes = new Node[randNumberOfNodes];

            node.Value = 10;
            //node.Value = rand.Next(int.MaxValue);

            for (var i = 0; i < randNumberOfNodes; i++)
            {
                try
                {
                    node.ChildNodes[0] = new Node();
                    if (!token.IsCancellationRequested)
                    {
                        ThreadPool.QueueUserWorkItem(obj => TraverseNode(cts.Token, node));
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
