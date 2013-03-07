using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question2_7
{
    class Program
    {
        static void Main(string[] args)
        {

            // Question 2-7
            //
            // Implement a function to check if a linked list is a palindrome.
            //

            Random rand = new Random();
            Node not_palindrome = new Node(500);
            for (int x = 0; x <= 10; x++)
            {
                not_palindrome.appendToTail(rand.Next(0, 5));
            }

            Console.WriteLine("not_palindrome: ");
            print_node(not_palindrome);
            Console.WriteLine("is palindrome?: " + check_if_palindrome(not_palindrome));

            Node palindrome = new Node(1);
            palindrome.appendToTail(0);
            palindrome.appendToTail(1);
            palindrome.appendToTail(0);
            palindrome.appendToTail(1);

            Console.WriteLine("palindrome: ");
            print_node(palindrome);
            Console.WriteLine("is palindrome?: " + check_if_palindrome(palindrome));

            Console.ReadLine();

        }

        public static bool check_if_palindrome(Node head)
        {
            List<int> values = new List<int>();
            Node runner = head;
            values.Add(head.data);

            while (runner.next != null)
            {
                runner = runner.next;
                values.Add(runner.data);
            }

            List<int> reversed = new List<int>(values);
            reversed.Reverse();

            if (values.SequenceEqual(reversed))
                return true;
            else
                return false;

        }

        static public void print_node(Node head)
        {
            Console.WriteLine("node level 1: " + head.data);
            Node runner = head;
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
