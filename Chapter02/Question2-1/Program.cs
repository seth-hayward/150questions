using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question2_1
{
    class Program
    {
        static void Main(string[] args)
        {


            // Question 2.1
            //
            // Write code to remove duplicates from an unsorted linked list.
            // FOLLOWUP
            // How would you solve this problem if a temporary buffer is not allowed?

            Random rand = new Random();
            Node seth = new Node(500);

            for (int x = 0; x <= 10; x++)
                seth.appendToTail(rand.Next(0, 10));

            Console.WriteLine("Before: ");

            print_node(seth);

            Node check_node = seth;

            while (check_node.next != null)
            {

                Node runner = check_node.next;
                int check_value = check_node.data;
                Node previous = check_node;

                if (runner.next == null) { break; }

                Console.WriteLine("Checking " + check_value + " for duplicates...");

                while (runner.next != null)
                {

                    if (found_duplicate(runner, check_value))
                    {
                        delete_duplicate_node(ref previous, check_value);
                        //break;
                    }

                    previous = runner;
                    runner = runner.next;
                }

                check_node = check_node.next;
            }

            Console.WriteLine("After: ");
            print_node(seth);

            Console.ReadLine();

        }

        static void print_node(Node to_print)
        {

            Console.WriteLine("Node level 1: " + to_print.data);

            int level = 2;
            Node node = to_print.next;
            while (node.next != null)
            {
                Console.WriteLine("Node level " + level + ": " + node.data);
                node = node.next;
                level++;
            }

        }

        static public bool found_duplicate(Node runner, int check_value)
        {

            Node head = runner;
            if (head.data == check_value)
            {
                Console.WriteLine("First return true");
                return true;
            }

            while (head.next != null)
            {
                head = head.next;
                if (head.data == check_value)
                {
                    return true;
                }
            }

            return false;
        }

        static void delete_duplicate_node(ref Node head, int d)
        {

            Node runner = head.next;
            Node previous = head;

            if (runner.data != d)
            {
                while (runner.next != null)
                {
                    if (runner.data == d)
                    {
                        break;
                    }
                    previous = runner;
                    runner = runner.next;
                }

            }

            Console.WriteLine("Deleting node with value " + runner.data);

            if (runner.next != null)
            {
                Node new_connect = runner.next;
                previous.next = new_connect;
            } else
            {
                previous.next = null;
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
