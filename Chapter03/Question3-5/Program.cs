using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question3_5
{
    class Program
    {
        static void Main(string[] args)
        {

            // Question 3.5
            //
            // Implement a MyQueue class which implements a queue using two stacks.

            MyQueue queue = new MyQueue();

            enq(5, ref queue);
            queue.printStack();

            enq(4, ref queue);
            queue.printStack();

            enq(10, ref queue);
            queue.printStack();

            Console.WriteLine("Popping...");

            pop(ref queue);
            queue.printStack();
            pop(ref queue);
            queue.printStack();

            Console.ReadLine();

        }

        static void enq(int d, ref MyQueue queue)
        {
            Console.WriteLine("enqueue: " + d);
            queue.enqueue(d);
        }

        static void pop(ref MyQueue queue)
        {
            int? d = queue.dequeue();
            Console.WriteLine("dequeue: " + d);
        }


    }

    public class MyQueue
    {
        public Stack lifo = new Stack();

        public void enqueue(int d)
        {
            lifo.push(d);
        }

        public int? dequeue()
        {

            // hok, instead of popping
            // the most recently added
            // we make clone, then pop
            // the first in line

            Stack temp = (Stack)lifo.Clone();
            Stack another = new Stack();

            int? item;


            // first, we get the last item...
            item = temp.pop();
            while (item != null)
            {
                another.push((int)item);
                item = temp.pop();
            }

            int? first_in_line = another.pop();

            // now we reverse another???
            temp = new Stack();
            item = another.pop();
            while (item != null)
            {
                temp.push((int)item);
                item = another.pop();
            }

            lifo = temp;

            return first_in_line;

        }

        public void printStack()
        {
            Stack copy = (Stack)lifo.Clone();

            int? item = copy.pop();
            int levels = 0;
            Console.WriteLine("\n");
            while (item != null)
            {
                levels++;
                Console.WriteLine("Stack " + levels + ": " + item);
                item = copy.pop();
            }
            Console.WriteLine("\n");
        }

    }

    public class Stack : ICloneable
    {
        public Node<int> top;

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

        public void push(int item)
        {
            Node<int> t = new Node<int>(item);
            t.next = top;
            top = t;
        }

        public int? peek()
        {
            return top.data;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        
    }

    public class Node<T>
    {
        public T data;
        public Node<T> next;

        public Node(T d)
        {
            data = d;        
        }
    }
}
