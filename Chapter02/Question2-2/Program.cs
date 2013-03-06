using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question2_2
{
    class Program
    {
        static void Main(string[] args)
        {

            //
            // Question 2.1
            //
            // IMplement an algorithm to find the kth to last element of singly linked list.

            Random rand = new Random();
            Node seth = new Node(500);

            for (int x = 0; x <= 10; x++)
            {
                seth.appendToTail(rand.Next(0, 10));
            }

            Console.WriteLine("LinkedList: ");
            print_node(seth);

            int k = 5;
            Node kth = find_kth_to_last(seth,k);

            Console.WriteLine("k = " + k + ": " + kth.data);

            Console.ReadLine();
        }

        static public void print_node(Node head)
        {
            Node runner = head;
            Console.WriteLine("node level 1: " + runner.data);

            int level = 2;
            while (runner.next != null)
            {
                runner = runner.next;
                Console.WriteLine("node level " + level + ": " + runner.data);
                level++;
            }
        }

        static public Node find_kth_to_last(Node head, int k)
        {
            Node k_result = null;

            int levels = 0;
            Node runner = head;

            while (runner.next != null)
            {
                levels++;
                runner = runner.next;
            }

            runner = head;

            for (int x = 0; x <= (levels - k); x++)
            {
                runner = runner.next;
                if (x == (levels - k))
                    return runner;

            }

            return k_result;

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
