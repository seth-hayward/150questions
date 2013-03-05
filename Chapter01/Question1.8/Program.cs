using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question1._8
{
    class Program
    {
        static void Main(string[] args)
        {

            //
            // Question 1.8
            //
            // Assume you have a method isSubString which checks if one 
            // word is a substring of another. Given two strings, s1 and
            // s2, write code to check if s2 is a rotation of s1 using only
            // one call to isSubstring. (e.g. "waterbottle" is a rotation
            // of "erbottlewat"

            Console.WriteLine("Please enter your first string: ");

            string s1 = Console.ReadLine();

            Console.WriteLine("Please enter your second string: ");

            string s2 = Console.ReadLine();

            Console.WriteLine("s2 is a rotation of s1: " + is_rotation(s1, s2).ToString());

            Console.ReadLine();

        }

        static bool is_rotation(string s1, string s2)
        {

            bool results;

            string test_string = s2 + s2;

            if (test_string.Contains(s1) == true)
                results = true;
            else
                results = false;

            return results;

        }
    }
}
