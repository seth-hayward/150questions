using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question3_2
{
    class Program
    {
        static void Main(string[] args)
        {

            // Question 3.2
            //
            // How could you design a stack which, in addition to push and pop,
            // also has a function min which returns the minimum element? Push,
            // pop, and min should all operate in O(1) time. 

            Stack stack = new Stack();

            Random rand = new Random();
            for (int x = 0; x < 3; x++)
            {
                stack.push(rand.Next(0,10));
            }

            Console.WriteLine("peek: ");
            Console.WriteLine(stack.peek());
            Console.WriteLine("pop: " + stack.pop());
            Console.WriteLine("push:");
            stack.push(rand.Next(0, 3));
            Console.WriteLine("min: " + stack.min());

            Console.ReadLine();

        }
    }

    public class Stack
    {
        public Node top;
        List<int> values = new List<int>();

        public void push(int d)
        {
            Node item = new Node(d);
            if (top != null)
            {
                item.next = top;
                top = item;
            }
            top = item;

            values.Add(d);
            values.Sort();

            Console.WriteLine("values: ");
            foreach(int x in values) {
                Console.WriteLine("- " + x);
            }

        }

        public int? pop()
        {
            if (top != null)
            {
                int item = top.data;

                if (top.data == values.First())
                {
                    // find a new minimum... but how to do this in O(1) time?
                    values.RemoveAt(0);
                }

                top = top.next;
                return item;
            }
            return null;
        }

        public int peek()
        {
            return top.data;
        }

        public int min()
        {
            return values.First();
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
