using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question1._3
{
    class Program
    {
        static void Main(string[] args)
        {

            //
            // Question 1.3
            //
            // Given two strings, write a method to decide if one is a permutation of the other.
            //
            //

            // A permutation is...
            // "an ordered arrangement of a set of objects"

            if (args.Length != 2)
            {
                Console.WriteLine("Please pass two strings as parameters.");
                return;
            }

            string a = args[0];
            string b = args[1];

            // Get the letters in string a, then order them alphabetically
            List<char> letters_a = a.ToCharArray().ToList();
            List<char> letters_b = b.ToCharArray().ToList();

            // Now sort the letters alphabetically...
            letters_a.Sort();
            letters_b.Sort();

            // "Determine whether two sequences are equal by comparing their elements"
            if (letters_a.SequenceEqual(letters_b))
            {
                Console.WriteLine("The sets match, these strings are permutations of each other.");
            }
            else
            {
                Console.WriteLine("These sets do not match, these strings are not permutations of each other.");
            } 

        }

    }
}
