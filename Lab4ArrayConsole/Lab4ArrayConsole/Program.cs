using System;

namespace Lab4ArrayConsole
{

    class Program
    {
        static void Main(string[] args)
        {
            int arr_length = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[arr_length];
            Random rnd = new Random();

            for (int i = 0; i < arr_length; i += 1)
            {
                int value = rnd.Next(-20, 20);
                arr.SetValue(value, i);
            }

            Console.WriteLine("==============================");

            for (int i = 0; i < arr_length; i += 1)
            {
                Console.Write(arr[i].ToString() + "; ");
            }

            Console.WriteLine("==============================");

            Array.Sort(arr);

            Console.WriteLine("========= Sorted Array Start ============");

            for (int i = 0; i < arr_length; i += 1)
            {
                Console.Write(arr[i].ToString() + "; ");
            }

            Console.WriteLine("========= Sorted Array End ==============");

            int current_index = 0;
            int[] newArr = new int[arr_length];

            for (int i = 0; i < arr_length; i += 1) {

                if (arr[i] != 0) {
                    newArr.SetValue(arr[i], current_index);
                    current_index += 1;
                }
            }

            Console.WriteLine("========= Filtred Array Start ============");

            for (int i = 0; i < arr_length; i += 1)
            {
                Console.Write(newArr[i].ToString() + "; ");
            }

            Console.WriteLine("========= Filtred Array End ==============");

            var a = Console.ReadLine();
        }
    }
}
