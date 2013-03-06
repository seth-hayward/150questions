using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question2_6
{
    class Program
    {
        static void Main(string[] args)
        {

            //
            // Question 2.6
            //
            // Given a circular linked list, implement an algorithm which returns
            // the node at the beginning of the loop. 
            // DEFINITION
            // Circular linked list: A (corrupt linked list in which a node's next pointer
            // points to an earlier node, so as to make a loop in the linked list.
            // EXAMPLE
            // Input: A -> B -> C -> D -> E -> C [the same C as earlier]
            // Output: C
            //


            Random rand = new Random();
            Node valid_list = new Node(400);
            for (int x = 0; x <= 4; x++)
            {
                valid_list.appendToTail(rand.Next(0, 100));
            }
            Console.WriteLine("Valid list: ");
            print_node(valid_list);

            Node bork = find_circular_reference(valid_list);

            if (bork != null) { Console.WriteLine("Found circular reference: " + bork.data); }

            Node corrupt_list = new Node(500);
            for (int x = 0; x <= 4; x++)
            {
                corrupt_list.appendToTail(rand.Next(0, 50));
            }
            Node circular = corrupt_list.next.next;

            Node runner = corrupt_list;
            while (runner.next != null)
            {
                runner = runner.next;
            }
            runner.next = circular;

            Console.WriteLine("Corrupt list: ");
            print_node(corrupt_list);

            bork = find_circular_reference(corrupt_list);

            if (bork != null) { Console.WriteLine("Found circular reference: " + bork.data); }

            Console.ReadLine();
        }

        public static void print_node(Node node)
        {
            Console.WriteLine("node level 1: " + node.data);
            Node head = node;
            int levels = 2;
            while (head.next != null)
            {
                head = head.next;
                Console.WriteLine("node level " + levels + ": " + head.data);
                levels++;

                if (levels > 15)
                    break;
            }
        }

        public static Node find_circular_reference(Node head)
        {
            Hashtable values = new Hashtable();
            Node runner = head;
            while (runner.next != null)
            {
                runner = runner.next;
                if (values.ContainsKey(runner.data))
                {
                    return runner;
                }
                else
                    values.Add(runner.data, true);
            }

            return null;
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
