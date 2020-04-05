using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TutorialsPoint.Encoding;
using TutorialsPoint.DataStructures;

namespace UnitTestTutorial
{
    [TestClass]
    public class TreeTest
    {
        [TestMethod]
        public void TreeTest_MaxHeight_1()
        {
            var tree = CreateSampleUnbalancedTree();
            var maxHeight = tree.MaxHeight();
            Assert.AreEqual(maxHeight, 4);
        }

        [TestMethod]
        public void TreeTest_MinHeight_1()
        {
            var tree = CreateSampleUnbalancedTree();
            var minHeight = tree.MinHeight();
            Assert.AreEqual(minHeight, 2);
        }

        private Tree CreateSampleUnbalancedTree()
        {
            var tree = new Tree();
            tree.Root = new Node(
                new Node[]{
                    new Node(
                        new Node[]
                        {
                            new Node(
                                new Node[]{
                                    new Node()
                                }
                            ),
                            new Node()
                        }
                    ),
                    new Node(
                        new Node[]{
                            new Node()
                        }
                    ),
                    new Node(
                    ),
                }
            );
            return tree;
        }
    }
}
