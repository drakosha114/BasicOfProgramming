using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Array_part2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность матрицы");
            Console.WriteLine("Введите число строк (не больше 100)");

            int num_of_rows = Convert.ToInt32(Console.ReadLine());
            /*
            do {
                num_of_rows = Convert.ToInt32(Console.ReadLine());

            } while (num_of_rows > 0 && num_of_rows <= 100);
            */
            Console.WriteLine("Введите число столбцов (не больше 100)");

            int num_of_colls = Convert.ToInt32(Console.ReadLine());
            /*
            do {
                num_of_colls = Convert.ToInt32(Console.ReadLine());

            } while (num_of_colls > 0 && num_of_colls <= 100);
            */

            int[,] arr = new int[num_of_rows, num_of_colls];

            Random rnd = new Random();

            for (int i = 0; i < num_of_rows; i += 1) {
                for (int j = 0; j < num_of_colls; j += 1) {
                    arr.SetValue(rnd.Next(), i, j);
                }
            }

            for (int i = 0; i < num_of_rows; i += 1)
            {
                for (int j = 0; j < num_of_colls; j += 1)
                {
                    Console.Write(arr[i, j].ToString() + "; ");
                }

                Console.WriteLine("\b");
            }

            int[] minimal_Elements = new int[num_of_rows];

            for (int i = 0; i < num_of_rows; i += 1)
            {
                int minimal_element_in_row = arr[i, 0];

                for (int j = 1; j < num_of_colls; j += 1)
                {
                    minimal_element_in_row = arr[i, j] < minimal_element_in_row ? arr[i, j] : minimal_element_in_row;
                }

                minimal_Elements.SetValue(minimal_element_in_row, i);

            }
            Console.WriteLine("\b");
            for (int i = 0; i < num_of_rows; i += 1)
            {
                Console.Write(minimal_Elements[i].ToString() + "; "); 
            }
            Console.WriteLine("\b");

            int sumOfMinimalElements = 0;

            for (int i = 0; i < num_of_rows; i += 1)
            {
                sumOfMinimalElements += minimal_Elements[i];
            }

            Console.WriteLine("\b");
            Console.Write("Сумма минимальных элементов мфатрицы в строке равна: ");
            Console.WriteLine(sumOfMinimalElements.ToString());
            Console.WriteLine("\b");
            Console.ReadLine();
        }
    }
}
