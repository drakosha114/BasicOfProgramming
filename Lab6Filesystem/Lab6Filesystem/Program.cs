using System;
using System.Collections.Generic;
using System.IO;

namespace Lab6Filesystem
{
    class Program
    {
        static void Main(string[] args)
        {

            // string[] _lines = System.IO.File.ReadAllLines(@"C:\Temp\input.txt");
            // StreamWriter sw = new StreamWriter("name.txt");
            // sw.WriteLine("текст");
            // sw.Close();
            var inputFileName = @"C:\Temp\input.txt";
            var outpuFileName = @"C:\Temp\output.txt";

            


            int num_of_rows;
            int num_of_colls;
            int[,] arr;

            

            try {

                StreamReader streamReader;
                string str = "";
                string[] inputArr;

                streamReader = new StreamReader(inputFileName);
                
                while (!streamReader.EndOfStream)
                {
                    str += streamReader.ReadLine();
                    str += " ";
                };

                inputArr = str.Trim().Split(" ");

                Queue<string> q = new Queue<string>(
                    inputArr
                );

                num_of_rows = Convert.ToInt32(q.Dequeue());
                num_of_colls = Convert.ToInt32(q.Dequeue());

                arr = new int[num_of_rows, num_of_colls];

                for (int i = 0; i < num_of_rows; i += 1)
                {
                    for (int j = 0; j < num_of_colls; j += 1)
                    {
                        arr.SetValue(Convert.ToInt32(q.Dequeue()), i, j);
                    }
                }

            } catch {
                return;
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

            int sumOfMinimalElements = 0;

            for (int i = 0; i < num_of_rows; i += 1)
            {
                sumOfMinimalElements += minimal_Elements[i];
            }

            try
            {
                StreamWriter streamWritter = new StreamWriter(outpuFileName);
                streamWritter.Write("Result: ");
                streamWritter.Write(sumOfMinimalElements);
                streamWritter.Close();

            } catch
            { 
                Console.WriteLine("Error!!!");
            }

        }
    }
}
