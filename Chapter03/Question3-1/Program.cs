using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question3_1
{
    class Program
    {
        static void Main(string[] args)
        {

            // Question 3.1
            //
            // Describe how you could use a single array to implement three stacks.

            int?[,] array_stack = new int?[3, 10];
            Random rand = new Random();

            for (int x = 0; x < 7; x++)
            {
                array_stack[0, x] = rand.Next(0, 10);
                array_stack[1, x] = rand.Next(0, 10);
                array_stack[2, x] = rand.Next(0, 10);
            }

            // print
            Console.WriteLine("array_stack: ");
            print_stack(array_stack);

            // peek
            Console.WriteLine("Peek 1st stack: " + array_stack[0, 0]);

            // pop 1st stack item
            Console.WriteLine("Pop 1st stack item: " + pop_item(ref array_stack, 0));

            // push an item to 1st stack
            push_item(ref array_stack, 0, 1000);

            Console.WriteLine("array_stack: ");
            print_stack(array_stack);

            Console.ReadLine();

        }

        public static void print_stack(int?[,] stack)
        {

            for(int y = 0; y<= 2; y++) {
                for (int x = 0; x < stack.GetLength(1); x++)
                {
                    Console.WriteLine("stack[" + y + "," + x + "]: " + stack[y, x]);
                }
            }

        }

        public static void push_item(ref int?[,] stack, int stack_number, int item)
        {
            List<int?> items = new List<int?>();
            for (int x = 0; x < stack.GetLength(1); x++)
            {
                items.Add(stack[stack_number, x]);
            }
            for (int x = 0; x < items.Count - 1; x++) {
                stack[stack_number, x+1] = items[x];
            }
            stack[stack_number, 0] = item;
        }

        public static int? pop_item(ref int?[,] stack, int stack_number)
        {
            int? item;
            List<int?> remaining_items = new List<int?>();
            for (int x = 1; x < stack.GetLength(1); x++)
            {
                remaining_items.Add(stack[stack_number, x]);
                stack[stack_number, x] = null;
            }

            item = stack[stack_number, 0];
            for (int x = 0; x < remaining_items.Count; x++)
            {
                stack[stack_number, x] = remaining_items[x];
            }

            return item;
        }

    }

}
