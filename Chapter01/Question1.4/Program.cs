using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question1._4
{
    class Program
    {
        static void Main(string[] args)
        {

            //
            // Question 1.4
            //
            // Write a method to replace all spaces in a string with '%20'. You may
            // assume the string has sufficient space at the end of the string
            // to hold the additional characters, and that you are given the "true" length
            // of the string. (Note: if implemening in Java, please use a character
            // array so that you can perform this operation in place.)
            //

            if(args.Length != 1) {
                Console.WriteLine("Please pass one string as a parameter.");
                return;
            }

            string input = args[0].Replace(" ", "%20");
            Console.WriteLine(input);

        }
    }
}
