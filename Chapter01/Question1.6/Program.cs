using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question1._6
{
    class Program
    {
        static void Main(string[] args)
        {

            // Question 1.6
            //
            // Given an image reprsented by an NxN matrix, where each pixel in the image
            // is 4 bytes, write a method to rotate the image by 90 degrees. Can you
            // do this in place?


            String[,] matrix = new String[2,2];

            matrix[0, 0] = "a";
            matrix[0, 1] = "b";
            matrix[1, 0] = "c";
            matrix[1, 1] = "d";

            Console.WriteLine("Before transformation: ");

            print_matrix(matrix);

            Console.WriteLine("After transformation: ");

            String[,] rotated_matrix = new String[2, 2];

            rotated_matrix = rotate_matrix(matrix);

            print_matrix(rotated_matrix);

        }


        static void print_matrix(String[,] matrix) {

            string row = null;
            for (int x = 0; x <= 1; x++)
            {

                for (int y = 0; y <= 1; y++)
                {
                    row = row + matrix[x, y];
                }

                Console.WriteLine(row);
                row = null;
            }

        }

        static String[,] rotate_matrix(String[,] input_matrix)
        {

            String[,] results = new String[2,2];

            // am i looping thorugh the input matrix or the output matrix?
            // looping the input matrix seems most reasonable
            for (int x = 0; x <= 1; x++)
            {

                for (int y = 0; y <= 1; y++)
                {

                    // okay, so we are at point x,y in the INPUT matrix

                    int old_x = x;
                    int old_y = y;

                    int new_x;
                    int new_y;

                    if(x == 0 && y == 0) {
                        // first row, first col - so go to first row, sec col
                        new_x = 0;
                        new_y = 1;
                        results[0,y+1] = input_matrix[x, y];
                    }

                    if (x == 0 && y == 1) 
                    {
                        // first row, second col, so go to second row, sec col
                        results[x+1,1] = input_matrix[x, y];
                    }

                    if (x == 1 && y == 0)
                    {
                        // second row, first col - so go to first row, first col
                        results[x-1, 0] = input_matrix[x, y];
                    }

                    if (x == 1 && y == 1)
                    {
                        // second row, second col, so go to second row, first col
                        results[1, y-1] = input_matrix[x, y];
                    }


                }

            }


            return results;
        }

    }
}
