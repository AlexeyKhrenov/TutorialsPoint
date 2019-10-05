using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HutterPrize.FrequencyAnalysis;
using TutorialsPoint.Encoding;

namespace HutterPrize.HuffmanEncoding
{
    public class HuffmanTree
    {
        public Node Root;

        private List<Node> NodeQuantity;

        public Dictionary<Word, LongBitSequence> Encoded;

        public HuffmanTree(Dictionary<Word, int> frequencyWords)
        {
            NodeQuantity = frequencyWords.Select(x => new Node(x.Key, x.Value)).ToList();
        }

        public void BuildTree()
        {
            while (NodeQuantity.Count != 1)
            {
                var first = FetchMinimalNode();
                var second = FetchMinimalNode();
                NodeQuantity.Add(new Node(first, second));
            }
            Root = NodeQuantity.FirstOrDefault();
        }

        public void EncodeTree()
        {
            Encoded = new Dictionary<Word, LongBitSequence>();
            Root.EncodeNode(new LongBitSequence(new BitSequence()), Encoded);
        }

        private void TraverseTree(Node node, Action<Node> action)
        {
            action(node);
            if (node.left != null) TraverseTree(node.left, action);
            if (node.right != null) TraverseTree(node.right, action);
        }

        public override string ToString()
        {
            var result = "";
            TraverseTree(Root, x => result += Environment.NewLine + x.ToString());
            return result;
        }

        private Node FetchMinimalNode()
        {
            var result = NodeQuantity.First();

            foreach (var node in NodeQuantity)
            {
                if (node.Quantity < result.Quantity)
                {
                    result = node;
                }
            }
            NodeQuantity.Remove(result);

            return result;
        }

        public class Node
        {
            public Word Value;
            public LongBitSequence Encoding;
            public int Quantity;
            public Node left;
            public Node right;

            private Node() { }

            public Node(Word word, int quantity)
            {
                Value = word;
                Quantity = quantity;
            }

            public Node (Node left, Node right)
            {
                Quantity = left.Quantity + right.Quantity;
                this.left = left;
                this.right = right;
            }

            public override string ToString()
            {
                var result = Value != null ? Value.ToString() : "";
                result += "; ";
                result += Quantity;
                result += "; ";

                if (Value != null)
                {
                    result += Encoding.ToString();
                }
                return result;
            }

            public void EncodeNode(LongBitSequence bitSequence, Dictionary<Word, LongBitSequence> output)
            {
                if (Value != null)
                {
                    Encoding = bitSequence;
                    output.Add(Value, bitSequence);
                }
                else
                {
                    var sequence1 = bitSequence;
                    var sequence2 = bitSequence;

                    sequence1.Add_0_AtEnd();
                    sequence2.Add_1_AtEnd();

                    left?.EncodeNode(sequence1, output);
                    right?.EncodeNode(sequence2, output);
                }
            }
        }
    }
}
