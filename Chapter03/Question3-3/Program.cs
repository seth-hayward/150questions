using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question3_3
{
    class Program
    {
        static void Main(string[] args)
        {

            // Question 3-3
            //
            // Imagine a (literal) stack of plates. If the stack gets too high, it might
            // topple. Therefore, in real life, we would likely start a new stack when the
            // previous stack exceeds some threshold. Implement a data structure SetofStacks
            // that mimics this. SetofStacks should be composed of several stacks and create
            // a new stack once the previous one exeeds capacity. SetOfStacks.push() and 
            // SetOfStacks.pop() should behave identically to a single stack (that is pop()
            // should return the same values as it would if there were just a single stack.)
            //
            // FOLLOW UP
            // Implement a function popAt(int index) which performs a pop operation on a specific
            // sub-stack.

            SetOfStacks seth = new SetOfStacks();
            Random rand = new Random();

            // add a 100 nodes
            for (int x = 0; x < 100; x++)
            {
                seth.push(rand.Next(0, 10));
            }

            Console.WriteLine("Number of plates: " + seth.plates.Count());
            Console.WriteLine("Number of Nodes: " + seth.countNodes);

            // pop off 11 nodes
            for (int x = 0; x < 11; x++)
            {
                Console.WriteLine("Popped " + seth.pop());
            }

            Console.WriteLine("Number of plates: " + seth.plates.Count());
            Console.WriteLine("Number of Nodes: " + seth.countNodes);


            Console.ReadLine();
        }
    }

    public class SetOfStacks
    {
        public List<Stack> plates = new List<Stack>();
        public int countNodes = 0;

        public void push(int d)
        {
            countNodes++;
            if (plates.Count == 0)
            {
                Stack stack = new Stack();
                stack.push(d);
                plates.Add(stack);
                return;
            }

            Stack last = plates.Last();
            if (last.countOfNodes() < 10)
            {
                last.push(d);
            }
            else
            {
                Stack stack = new Stack();
                stack.push(d);
                plates.Add(stack);
            }
        }

        public int? pop()
        {
            countNodes--;
            if (plates.Count == 0)
                return null;

            Stack last = plates.Last();
            int? item = last.pop();
            if (last.countOfNodes() == 0)
            {
                plates.RemoveAt(plates.Count - 1);
            }
            return item;
        }

        public int? popAt(int which_stack)
        {
            if (which_stack > (plates.Count - 1))
                return null;

            Stack stack = plates[which_stack];
            return stack.pop();

        }

    }

    public class Stack
    {
        Node top;

        public void push(int d)
        {
            Node item = new Node(d);
            item.next = top;
            top = item;
        }

        public int? pop()
        {
            if (top != null)
            {
                Node item = top;
                top = top.next;
                return item.data;
            }
            return null;
        }

        public int? peek()
        {
            return top.data;
        }

        public int countOfNodes()
        {
            int nodes = 0;

            if (top == null)
                return 0;
            
            Node runner = top;
            while (runner.next != null)
            {
                runner = runner.next;
                nodes++;
            }
            return nodes;
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
