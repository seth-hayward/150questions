using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question1._5
{
    class Program
    {
        static void Main(string[] args)
        {

            // 
            // Question 1.5
            //
            // Implement a method to perform basic string compression using the counts
            // of repeated characters. For example, the string aabcccccaaa would become
            // a2b1c5a3. If the "compressed" string would not become smaller than the
            // original string, your method should return the original string.

            if (args.Length != 1)
            {
                Console.WriteLine("Please pass one string as a parameter.");
                return;
            }

            string input_string = args[0];
            StringBuilder compressed_string = new StringBuilder();

            for (int character_index = 0; character_index < input_string.Length; character_index++)
            {
                compressed_string.Append(ReturnCompression(ref character_index, input_string));
            }

            if (input_string.Length <= compressed_string.Length)
            {
                Console.WriteLine(input_string);
            }
            else
            {
                Console.WriteLine(compressed_string);
            }

        }

        static string ReturnCompression(ref int character_index, string s)
        {

            string result = null;
            string first_character = s.Substring(character_index, 1);
            int repeated_letters = 1;

            for (int current_character_index = character_index + 1; current_character_index < s.Length; current_character_index++)
            {

                string current_character = s.Substring(current_character_index, 1);
                if (current_character != first_character)
                {
                    break;
                }
                else
                {
                    // There was a repeated letter,
                    // so we want to increment the counter.
                    repeated_letters++;
                }

                character_index = current_character_index;

            }

            result = first_character + repeated_letters.ToString();

            return result;
        }
    }
}
