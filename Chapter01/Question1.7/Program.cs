using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question1._7
{
    class Program
    {
        static void Main(string[] args)
        {

            //
            // Question 1.7
            //
            // Write an algorithm such that if an element in an MxN matrix is 0,
            // it's entire row and column are set to 0.
            //

            int[,] matrix = new int[10, 10];
            Random rand = new Random();

            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                    matrix[x, y] = rand.Next(0, 10);

            Console.WriteLine("Before: ");

            print_matrix(matrix);

            int[,] updated_matrix = new int[10, 10];

            updated_matrix = zero_column_and_row_if_value_zero(matrix);

            Console.WriteLine("After: ");

            print_matrix(matrix);

            Console.ReadLine();

        }

        static int[,] zero_column_and_row_if_value_zero(int[,] input_matrix)
        {

            int[,] results = input_matrix;

            List<int> zero_columns = new List<int>();
            List<int> zero_rows = new List<int>();

            for (int x = 0; x < input_matrix.GetLength(0); x++)
                for (int y = 0; y < input_matrix.GetLength(1); y++)
                {
                    if (input_matrix[x, y] == 0)
                    {

                        if (zero_columns.Contains(y) == false)
                        {
                            zero_columns.Add(y);
                        }
                        if (zero_rows.Contains(x) == false)
                        {
                            zero_rows.Add(x);
                        }
                    }
                }

            foreach(int x in zero_rows)
                for (int y = 0; y < input_matrix.GetLength(1); y++)
                    results[x, y] = 0;

            foreach (int y in zero_columns)
                for (int x = 0; x < input_matrix.GetLength(0); x++)
                    results[x, y] = 0;

            return results;

        }

        static void print_matrix(int[,] input_matrix)
        {

            for (int x = 0; x < input_matrix.GetLength(0); x++)
            {

                string row = null;
                for (int y = 0; y < input_matrix.GetLength(1); y++)
                {
                    row = row + " " + input_matrix[x,y].ToString();
                }

                Console.WriteLine(row);

            }

        }
    }
}
