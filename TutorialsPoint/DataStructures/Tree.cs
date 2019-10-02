using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.DataStructures
{
    public class TreeNode<T>
    {
        public T Value;
        public TreeNode<T> Left;
        public TreeNode<T> Right;
        public TreeNode(T value)
        {
            Value = value;
        }
    }

    public class Tree<T>
    {
        public TreeNode<T> Root;

        public Tree(T value)
        {
            Root = new TreeNode<T>(value);
        }
    }
}
