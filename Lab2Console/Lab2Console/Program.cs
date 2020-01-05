using System;

namespace Lab2Console
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Лабораторная работа №2. Консоль, вариант 11");

            DisplayInfo();

            var color = System.ConsoleColor.DarkRed;

            Console.BackgroundColor = color;
            Console.SetBufferSize(300, 200);

            DisplayInfo();
        }

        static void DisplayInfo() {            
            Console.WriteLine("Высота буфера {0} строк.", Console.BufferHeight);
            Console.WriteLine("Ширина буфера {0} колонок.", Console.BufferWidth);
            Console.WriteLine("Высота окна {0} строк.", Console.WindowHeight);
            Console.WriteLine("Ширина окна {0} колонок.", Console.WindowWidth);
            Console.WriteLine("Цвет фона {0}", Console.BackgroundColor);
        }
    }
}
