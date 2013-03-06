using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question2_3
{
    class Program
    {
        static void Main(string[] args)
        {

            Random rand = new Random();
            Node seth = new Node(500);
            for (int x = 0; x <= 10; x++)
            {
                seth.appendToTail(rand.Next(0, 10));
            }

            Console.WriteLine("LinkedList: ");
            print_node(seth);

            // remove the 3rd node
            Node to_be_deleted = seth.next.next;

            remove_node(ref to_be_deleted);

            Console.WriteLine("After removing 3rd node: ");
            print_node(seth);

            Console.ReadLine();

        }

        static public void print_node(Node head)
        {
            Console.WriteLine("node level 1: " + head.data);
            int level = 2;
            Node runner = head;
            while (runner.next != null)
            {
                runner = runner.next;
                Console.WriteLine("node level " + level + ": " + runner.data);
                level++;
            }
        }

        static public void remove_node(ref Node to_delete)
        {
            Node replace;
            if (to_delete.next == null)
            {
                to_delete = null;
                return;
            }

            replace = to_delete.next;
            to_delete.data = replace.data;
            to_delete.next = replace.next;
        }
    }

    public class Node
    {
        public Node next = null;
        public int data;

        public Node(int d)
        {
            data = d;
        }

        public void appendToTail(int d)
        {
            Node end = new Node(d);
            Node n = this;
            while (n.next != null)
            {
                n = n.next;
            }

            n.next = end;
        }

    }
}
