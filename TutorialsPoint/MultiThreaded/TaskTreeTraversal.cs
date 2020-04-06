using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TutorialsPoint.DataStructures;

namespace TutorialsPoint.MultiThreaded
{
    public class TaskTreeTraversal
    {
        public Tree Tree;

        private Random rand;
        private CancellationTokenSource cts;

        public TaskTreeTraversal()
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

        public async Task TraverseNode(CancellationToken token, Node node)
        {
            var randNumberOfNodes = rand.Next(10);
            node.ChildNodes = new Node[randNumberOfNodes];

            node.Value = 10;
            //node.Value = rand.Next(int.MaxValue);

            var tasks = new List<Task>();

            for (var i = 0; i < randNumberOfNodes; i++)
            {
                var childNode = new Node();
                node.ChildNodes[i] = childNode;
                if (!token.IsCancellationRequested)
                {
                    tasks.Add(Task.Run(() => TraverseNode(cts.Token, childNode)));
                }
            }

            await Task.WhenAll(tasks.ToArray());
        }
    }
}
