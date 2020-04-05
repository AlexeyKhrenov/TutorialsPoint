using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.DataStructures
{
    // consider making this a structure
    public class Node
    {
        // consider this representing as another data structure
        public Node[] ChildNodes;

        public object Value;

        public Node()
        {
        }

        public Node(Node[] childNodes)
        {
            ChildNodes = childNodes;
        }
    }

    public class Tree
    {
        public Node Root;

        public Tree()
        {
            Root = new Node();
        }

        public Tree(Node rootNode)
        {
            Root = rootNode;
        }

        public int MaxHeight()
        {
            if (Root == null)
            {
                return 0;
            }

            return MaxHeight(Root, 0);
        }

        public int MinHeight()
        {
            if (Root == null)
            {
                return 0;
            }

            return MinHeight(Root, 0);
        }


        //TODO - make this functions more consise
        public int MaxHeight(Node node, int maxHeight)
        {
            maxHeight++;

            if (node.ChildNodes == null)
            {
                return maxHeight;
            }

            var childMaxHeight = maxHeight;

            foreach (var child in node.ChildNodes)
            {
                var mh = MaxHeight(child, maxHeight);

                if (mh > childMaxHeight)
                {
                    childMaxHeight = mh;
                }
            }

            return childMaxHeight;
        }

        // TODO - make this function more consise
        public int MinHeight(Node node, int minHeight)
        {
            minHeight++;

            if (node.ChildNodes == null)
            {
                return minHeight;
            }

            var childMinHeight = int.MaxValue;

            foreach (var child in node.ChildNodes)
            {
                var mh = MinHeight(child, minHeight);

                if (mh < childMinHeight)
                {
                    childMinHeight = mh;
                }
            }

            return childMinHeight != int.MaxValue ? childMinHeight : minHeight;
        }
    }
}
