using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Node seth = new Node(500);

            for (int a = 0; a <= 10; a++)
            {
                seth.appendToTail(rand.Next(0, 10));
            }

            Console.WriteLine("LinkedList: ");
            print_node(seth);

            int x = 4;
            Node below_x = null;
            Node above_x = null;

            Node runner = seth;

            if (seth.data > x)
            {
                above_x = new Node(seth.data);
            }
            else
            {
                below_x = new Node(seth.data);
            }

            while (runner.next != null)
            {
                runner = runner.next;

                if (runner.data > x)
                {
                    if (above_x == null)
                        above_x = new Node(runner.data);
                    else
                        above_x.appendToTail(runner.data);                        
                }
                else
                {
                    if (below_x == null)
                        below_x = new Node(runner.data);
                    else
                        below_x.appendToTail(runner.data);
                }
            }

            Console.WriteLine("Below " + x + ": ");
            print_node(below_x);
            Console.WriteLine("Above " + x + ": ");
            print_node(above_x);

            Console.ReadLine();

        }

        public static void print_node(Node node)
        {
            Console.WriteLine("node level 1: " + node.data);

            Node runner = node;
            int levels = 2;
            while (runner.next != null)
            {
                runner = runner.next;
                Console.WriteLine("node level " + levels + ": " + runner.data);
                levels++;
            }
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
