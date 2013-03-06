using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {

            Node seth = new Node(5);

            Random rand = new Random();

            for(int x = 0; x < 10; x++) {
                seth.appendToTail(rand.Next(0, 10));
            }

            Console.WriteLine("Before delete: ");
            print_node(seth);

            // deleting the 4th element
            Node deleter = seth.next.next.next;

            seth = deleter.deleteNode(seth, deleter.data);

            Console.WriteLine("After delete (data=" + deleter.data + "): ");
            print_node(seth);

            Console.ReadLine();

        }

        public static void print_node(Node to_print)
        {

            Console.WriteLine("Node level 0: " + to_print.data);
            Node runner = to_print.next;
            int level = 1;

            while (runner != null)
            {
                Console.WriteLine("Node level " + level + ": " + runner.data);
                runner = runner.next;
                level++;
            }

        }
    }

    class Node
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

        public Node deleteNode(Node head, int d)
        {
            Node n = head;

            if (n.data == d)
            {
                return head.next;
            }

            while (n.next != null)
            {
                if (n.next.data == d)
                {
                    n.next = n.next.next;
                    return head;
                }
                n = n.next;
            } 
            return head;
        }

    }
}
