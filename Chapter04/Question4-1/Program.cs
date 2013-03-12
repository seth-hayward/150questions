using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Question4_1
{
    class Program
    {
        static void Main(string[] args)        
        {

            BinaryTree<int> btree = new BinaryTree<int>();
            btree.Root = new BinaryTreeNode<int>(1);
            btree.Root.Left = new BinaryTreeNode<int>(2);
            btree.Root.Right = new BinaryTreeNode<int>(3);

            btree.Root.Left.Left = new BinaryTreeNode<int>(4);
            btree.Root.Right.Right = new BinaryTreeNode<int>(5);

            btree.Root.Left.Left.Right = new BinaryTreeNode<int>(6);
            btree.Root.Right.Right.Right = new BinaryTreeNode<int>(7);

            btree.Root.Right.Right.Right.Right = new BinaryTreeNode<int>(8);

            int levels = 0;

            PreorderTraversal(btree.Root.Left, ref levels);
            Console.WriteLine("Nodes on left side: " + levels);

            levels = 0;

            PreorderTraversal(btree.Root.Right, ref levels);
            Console.WriteLine("Nodes on right side: " + levels);


            Console.ReadLine();

        }

        static void PreorderTraversal(BinaryTreeNode<int> current, ref int levels)
        {
            if (current != null)
            {

                levels++;

                BinaryTreeNode<int> left_node = current.Left;
                BinaryTreeNode<int> right_node = current.Right;

                string left = "";
                string right = "";
                if (left_node == null)
                    left = "null left";

                if (right_node == null)
                    right = "null right";

                //Console.WriteLine("level " + levels + ": " + current.Value + " (" + left + " " + right + ")");

                PreorderTraversal(current.Left, ref levels);
                PreorderTraversal(current.Right, ref levels);

            }
        }
    }

    public class Node<T>
    {
        // private member-variables
        private T data;
        private NodeList<T> neighbors = null;

        public Node() { }
        public Node(T data) : this(data, null) { }
        public Node(T data, NodeList<T> neighbors)
        {
            this.data = data;
            this.neighbors = neighbors;
        }

        public T Value
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        protected NodeList<T> Neighbors
        {
            get
            {
                return neighbors;
            }
            set
            {
                neighbors = value;
            }
        }
    }

    public class NodeList<T> : Collection<Node<T>>
    {
        public NodeList() : base() { }

        public NodeList(int initialSize)
        {
            // Add the specified number of items
            for (int i = 0; i < initialSize; i++)
            {
                base.Items.Add(default(Node<T>));
            }
        }

        public Node<T> FindByValue(T value)
        {
            // search the list for the value
            foreach (Node<T> node in Items) {
                if (node.Value.Equals(value))
                    return node;
            }

            // if we reached here, we didn't find a matching node
            return null;
        }

    }

    public class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode() : base() { }
        public BinaryTreeNode(T data) : base(data, null) { }
        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            base.Value = data;
            NodeList<T> children = new NodeList<T>(2);
            children[0] = left;
            children[1] = right;
        }

        public BinaryTreeNode<T> Left
        {
            get
            {
                if (base.Neighbors == null)
                {
                    return null;
                }
                else
                {
                    return (BinaryTreeNode<T>)base.Neighbors[0];
                }
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);

                base.Neighbors[0] = value;
            }
        }

        public BinaryTreeNode<T> Right
        {
            get
            {
                if (base.Neighbors == null)
                {
                    return null;
                }
                else
                {
                    return (BinaryTreeNode<T>)base.Neighbors[1];
                }
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);

                base.Neighbors[1] = value;
            }
        }

    }

    public class BinaryTree<T>
    {
        private BinaryTreeNode<T> root;
        public BinaryTree()
        {
            root = null;
        }

        public virtual void Clear()
        {
            root = null;
        }

        public BinaryTreeNode<T> Root
        {
            get
            {
                return root;
            }
            set
            {
                root = value;
            }
        }
    }


}
