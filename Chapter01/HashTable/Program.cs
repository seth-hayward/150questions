using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {

            Hashtable hashtable = new Hashtable();

            hashtable.Add("Area", 100);
            hashtable.Add("Perimeter", 2);
            hashtable.Add("Defense", 105);

            // int and string keys can both be used in same hashtable
            hashtable.Add(1, "First Element Name");

            Console.WriteLine("ContainsKey(\"Perimeter\"): " + hashtable.ContainsKey("Perimeter"));
            Console.WriteLine("ContainsKey(\"Area\"): " + hashtable.ContainsKey("Area"));
            Console.WriteLine("ContainsKey(\"Defense\"): " + hashtable.ContainsKey("Defense"));
            Console.WriteLine("ContainsKey(1): " + hashtable.ContainsKey(1));

            if (hashtable.ContainsKey("Perimeter") == true)
            {
                Console.WriteLine("Perimeter: " + hashtable["Perimeter"]);
            }

            if (hashtable.ContainsKey(1) == true)
            {
                Console.WriteLine("1: " + hashtable[1]);
            }

            Console.ReadLine();

        }
    }
}
