using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question3_4
{
    class Program
    {
        static void Main(string[] args)
        {

            Hanoi seth = new Hanoi();
            seth.Setup(3);
            int moves = 0;
            while (seth.Solve() == false)
            {
                moves++;
                Console.WriteLine("Move #" + moves);
                if (moves > 5) { break; }
            }

            seth.PrintContents();

            Console.ReadLine();

        }
    }

    public class Hanoi
    {
        public Stack[] Towers;
        public int max_layers;
        int index = 0;

        public void PrintContents()
        {

            for (int x = 0; x <= 2; x++)
            {
                Stack tower = Towers[x];

                Node layer = tower.top;

                if (layer == null)
                {
                    Console.WriteLine("Tower " + x + ": empty");
                }
                while (layer != null)
                {
                    Console.WriteLine("Tower " + x + ": " + layer.data);
                    layer = layer.next;
                }

            }

        }

        public void Setup(int n)
        {
            max_layers = n;
            Towers = new Stack[3];
            Stack tower = new Stack();
            for (int x = n; x > 0; x--)
            {
                tower.push(x);
            }
            Towers[0] = tower;
            Towers[1] = new Stack();
            Towers[2] = new Stack();
        }

        public bool Solve()
        {

            int? smallest_value = max_layers;

            Console.WriteLine("Start: ");

            PrintContents();

            while (moveSmallestToRight() == true)
            {
                // first, try to move the smallest all to the right

                index++;
                Console.WriteLine("-- index: " + index);
                if (isSolved() == true) { return true; }

                PrintContents();

            }

            Console.WriteLine("Moved smallest to right.");

            while (moveSecondSmallestToRight() == true)
            {
                index++;
                Console.WriteLine("-- index: " + index);
                if (isSolved() == true) { return true; }
                PrintContents();


            }

            Console.WriteLine("Moved second smallest to right.");


            while (moveSmallestToLeft() == true)
            {

                index++;
                Console.WriteLine("-- index: " + index);
                if (isSolved() == true) { return true; }
                
                // first, try to move the smallest all to the right
                PrintContents();

            }

            Console.WriteLine("Moved smallest to left.");

            while (moveSecondSmallestToRight() == true)
            {
                index++;
                Console.WriteLine("-- index: " + index);
                if (isSolved() == true) { return true; }
                PrintContents();


            }

            Console.WriteLine("Moved second smallest to right.");


            return isSolved();

        }

        public bool moveSecondSmallestToRight()
        {

            int? second_layer_value = max_layers;
            int second_layer_stack = 0;

            int smallest_layer_stack = findSmallestLayerStack();
            int? smallest_layer_value = Towers[smallest_layer_stack].peek();

            for (int x = 0; x <= 2; x++)
            {
                Stack stack = Towers[x];
                if (stack.peek() <= second_layer_value && stack.peek() > smallest_layer_value)
                {
                    second_layer_value = stack.peek();
                    second_layer_stack = x;
                }
            }

            bool result = moveLayer(second_layer_stack, true);

            //Console.WriteLine("moveSecondSmallestToRight(): moveLayer(" + second_layer_stack + ",true), second_layer_value: " + second_layer_value + ": " + result);

            return result;

        }

        public bool moveSmallestToRight()
        {

            int? smallest_layer_value = max_layers;
            int smallest_layer_stack = 0;

            for (int x = 0; x <= 2; x++)
            {
                Stack stack = Towers[x];
                if (stack.peek() <= smallest_layer_value)
                {
                    smallest_layer_value = stack.peek();
                    smallest_layer_stack = x;
                }
            }

//            Console.WriteLine("moveSmallestToRight: val" + smallest_layer_value + ",stack " + smallest_layer_stack);

            return moveLayer(smallest_layer_stack, true);

        }

        public int findSmallestLayerStack()
        {
            int? smallest_layer_value = max_layers;
            int smallest_layer_stack = 0;
            for (int x = 0; x <= 2; x++)
            {
                Stack stack = Towers[x];
                if (stack.peek() < smallest_layer_value)
                {
                    smallest_layer_value = stack.peek();
                    smallest_layer_stack = x;
                }
            }
            return smallest_layer_stack;
        }

        public bool moveSmallestToLeft()
        {

            int? smallest_layer_value = max_layers;
            int smallest_layer_stack = 1;

            for (int x = 1; x <= 2; x++)
            {
                Stack stack = Towers[x];
                if (stack.peek() < smallest_layer_value)
                {
                    smallest_layer_value = stack.peek();
                    smallest_layer_stack = x;
                }
            }

            //Console.WriteLine("moveSmallestToLeft: val" + smallest_layer_value + ",stack " + smallest_layer_stack);

            return moveLayer(smallest_layer_stack, false);

        }

        public bool isSolved()
        {
            Stack tower1 = Towers[0];
            Stack tower2 = Towers[1];

            if (tower1.peek() == null && tower2.peek() == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool moveLayer(int stack, bool right)
        {
            int? layer = Towers[stack].peek();
            bool result;

            if (right == true)
            {


                if (stack == 2 && right == true)
                    return false;


                if (Towers[stack + 1].peek() > layer || Towers[stack+1].peek() ==  null)
                {
                    Towers[stack].pop();
                    if (layer != null)
                        Towers[stack + 1].push((int)layer);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else
            {

                if (Towers[stack - 1].peek() > layer || Towers[stack-1].peek() == null)
                {
                    Towers[stack].pop();
                    if (layer != null)
                    {
                        Towers[stack - 1].push((int)layer);
                    }
                    result = true;
                }
                else
                {
                    result = false;
                }

            }

            //Console.WriteLine("moveLayer(" + stack + "," + right + "): " + result);

            return result;

        }

    }

    public class Stack
    {
        public Node top;

        public void push(int d)
        {
            Node t = new Node(d);
            t.next = top;
            top = t;
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
            if (top != null)
                return top.data;
            else
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
    }
}
