using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question3_6
{
    class Program
    {
        static void Main(string[] args)
        {

            // Question 3-6
            //
            // Write a program to sort a stack in ascending order (with biggest items on top).
            // You  may  use additional stacks to hold items, but you may not copy the elements
            // into any other data structure (such as an array.) The stack supports the following
            // operations: push, pop, peek, and isEmpty.

            SortedStack seth = new SortedStack();

            Console.WriteLine("pushing 2:");

            seth.push(2);
            printStack(seth.container);

            Console.WriteLine("pushing 3:");

            seth.push(3);
            printStack(seth.container);

            Console.WriteLine("pushing 1:");

            seth.push(1);
            printStack(seth.container);

            Console.WriteLine("pushing 4:");

            seth.push(4);
            printStack(seth.container);

            Console.WriteLine("pushing 5:");

            seth.push(5);
            printStack(seth.container);


            Console.ReadLine();

        }

        public static void printStack(Stack t)
        {
            Stack copy = (Stack)t.Clone();

            int levels = 0;
            int? item = copy.pop();

            Console.WriteLine("---");

            while (item != null)
            {
                levels++;
                Console.WriteLine("Stack level " + levels + ": " + item);
                item = copy.pop();
            }

            Console.WriteLine("---");


            Console.WriteLine("\n");

        }

    }

    public class SortedStack
    {
        public Stack container;

        public void push(int d)
        {
            Stack below = new Stack();
            Stack above = new Stack();

            if (container == null)
            {
                container = new Stack();
                container.push(d);
                return;            
            }

            Stack reversed = new Stack();
            Stack temp = new Stack();

            reversed = reverse(container);

            int? runner = reversed.pop();
            while (runner != null)
            {
                if (runner >= d)
                {
                    above.push((int)runner);
                }
                else
                {
                    below.push((int)runner);
                }
                runner = reversed.pop();
            }

            below.push(d);

            //Console.WriteLine("below: ");
            //Program.printStack(below);

            //below = reverse(below);

            int? first;
            int? last;

            runner = below.pop();
            last = runner;
            while (runner != null)
            {
                temp.push((int)runner);
                runner = below.pop();
            }

            //Console.WriteLine("above: ");
            //Program.printStack(above);

            runner = above.pop();
            first = runner;
            while (runner != null)
            {
                temp.push((int)runner);
                runner = above.pop();
            }

            first = temp.peek();

            Console.WriteLine("First: " + first + " - Last: " + last);
            //if (first < last)
            //{
            //    Console.WriteLine("Reversed: " + first + " - " + last);
            //    temp = reverse(temp);
            //}

            container = temp;

        }

        public int? pop()
        {
            return container.pop();
        }

        public static Stack reverse_if_backwards(Stack input)
        {
            Stack copy = (Stack)input.Clone();
            int? first;
            int? last;
            int? runner;

            Stack temp = new Stack();
            
            runner = input.pop();
            last = runner;
            while (runner != null)
            {
                runner = input.pop();
                if (runner != null) { temp.push((int)runner); }
            }

            first = temp.peek();

            Console.WriteLine("First: " + first + " - Last: " + last);
            if (first < last)
            {
                // smallest on top
                return temp;
            }
            else
            {
                // largest on top
                return copy;
            }

        }

        public static Stack reverse(Stack input)
        {
            Stack reversed = new Stack();
            int? runner = input.pop();

            while (runner != null)
            {
                reversed.push((int)runner);
                runner = input.pop();
            }

            return reversed;
        }

    }

    public class Stack : ICloneable {
        public Node top;

        public void push(int d)
        {
            Node t = new Node(d);
            t.next = top;
            top = t;
        }

        public int? peek()
        {
            return top.data;
        }

        public int? pop()
        {
            if (top != null)
            {
                int item = top.data;
                top = top.next;
                return item;
            }
            return null;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }

    public class Node {
        public int data;
        public Node next;

        public Node(int d) 
        {
            data = d;
        }
    }

    //public class Stack<T> where T : struct, IComparable, ICloneable
    //{
    //    public Node<T> top;

    //    public void push(T d)
    //    {
    //        Node<T> new_node = new Node<T>(d);
    //        new_node.next = top;
    //        top = new_node;
    //    }

    //    public Nullable<T> pop()
    //    {
    //        if (top != null)
    //        {
    //            T item = top.data;
    //            top = top.next;
    //            return item;
    //        }
    //        return null;
    //    }

    //    public T peek()
    //    {
    //        return top.data;
    //    }

    //    public object Clone()
    //    {
    //        return this.MemberwiseClone();
    //    }

    //}

    //public class Node<T>
    //{
    //    public T data;
    //    public Node<T> next;

    //    public Node(T d)
    //    {
    //        data = d;
    //    }

    //}
}
