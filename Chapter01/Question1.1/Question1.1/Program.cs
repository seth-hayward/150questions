using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question1._1
{
    class Program
    {
        static void Main(string[] args)
        {

            //
            // Question 1.1:
            //
            // Implement an algorithm to determine if a string
            // has all unique characters. What if you cannot
            // use additional data structures?
            //

            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a string to test.");
                return;
            }

            String word_to_check = args[0];
            List<char> letters = new List<char>();
            foreach (char s in word_to_check.ToCharArray())
            {
                if (letters.Contains(s) == false)
                {
                    letters.Add(s);
                }
            }

            foreach (char letter in letters)
            {
                Console.WriteLine("Letter: " + letter);
            }

            //
            // What if you cannot use additional data structures?
            //

            // I am not sure what this part of the questions means.
            // The data structures that I have used to answer this 
            // question include: 
            // - String (word_to_check)
            // - Array of Strings (string[] args)
            // - Array of chars (word_to_check.ToCharArray())
            // - Collections object (List, typed for char) (List<char> letters)

            // If I cannot use additional data structures? I would have to
            // rewrite the functionalities of the above data structures -
            // I would have to implement my own "Contains" method for looking
            // at all the items in a list, and a "ToCharArray" for converting
            // a string into an array that contains each character in the string.

        }
    }
}
