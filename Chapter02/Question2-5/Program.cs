using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question2_5
{
    class Program
    {
        static void Main(string[] args)
        {

            Random rand = new Random();
            Node first = new Node(rand.Next(1, 9));
            Node second = new Node(rand.Next(1, 9));
            for (int x = 0; x <= 2; x++)
            {
                first.appendToTail(rand.Next(1, 9));
                second.appendToTail(rand.Next(1, 9));
            }

            Console.WriteLine("first: ");
            print_node(first);

            Console.WriteLine("second: ");
            print_node(second);

            string first_number = create_string_from_list(first);
            string second_number = create_string_from_list(second);

            Console.WriteLine("first number: " + first_number);
            Console.WriteLine("second number: " + second_number);


            int output_1 = int.Parse(Reverse(first_number));
            int output_2 = int.Parse(Reverse(second_number));
            int sum = output_1 + output_2;
            Console.WriteLine(output_1.ToString() + "+" + output_2.ToString() + "=" + sum.ToString());

            Node sum_list = create_list_from_number(sum);

            Console.WriteLine("LinkedList representing sum: ");
            print_node(sum_list);

            int output_3 = int.Parse(first_number.ToString());
            int output_4 = int.Parse(second_number.ToString());
            int sum_2 = output_3 + output_4;
            Console.WriteLine("... followup: ");
            Console.WriteLine(output_3.ToString() + "+" + output_4.ToString() + "=" + sum_2.ToString());

            Node sum_list_2 = create_list_from_number(sum_2);
            Console.WriteLine("LinkedList representing sum: ");
            print_node(sum_list_2);

            Console.ReadLine();

        }

        public static string Reverse(string s)
        {
            string reversed;
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            reversed = new String(charArray);
            return reversed;
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

        public static string create_string_from_list(Node head)
        {
            StringBuilder number = new StringBuilder();
            number.Append(head.data.ToString());

            Node runner = head;
            while (runner.next != null)
            {
                runner = runner.next;
                number.Append(runner.data.ToString());
            }

            return number.ToString();
        }

        public static Node create_list_from_number(int d)
        {
            Node node = null;
            List<char> chars = d.ToString().ToCharArray().ToList();

            foreach (char digit in chars)
            {
                if (node == null)
                    node = new Node(int.Parse(digit.ToString()));
                else
                    node.appendToTail(int.Parse(digit.ToString()));
            }

            return node;

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
                n = n.next;

            n.next = end;
        }
    }
}
