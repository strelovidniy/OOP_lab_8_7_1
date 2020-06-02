using System;
using System.IO;

namespace OOP_lab_8_7_1
{
    class Input : IInput
    {
        public void Read()
        {
            ReadBase();
            ReadKey();
        }

        public void ReadBase()
        {
            StreamReader file = new StreamReader("base.txt");

            string[] tempStr = file.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tempStr.Length; i += 5)
            {
                Program.weather.Add(new Weather(DateTime.Parse(tempStr[i]), tempStr[i + 1], int.Parse(tempStr[i + 2]), int.Parse(tempStr[i + 3]), int.Parse(tempStr[i + 4])));
            }

            file.Close();
        }

        public void ReadKey()
        {
            
        Start:

            Console.WriteLine("Додавання записiв: +");
            Console.WriteLine("Редагування записiв: E");
            Console.WriteLine("Знищення записiв: -");
            Console.WriteLine("Виведення записiв: Enter");
            Console.WriteLine("Сортування за датою: D");
            Console.WriteLine("Сортування за температурою повiтря: T");
            Console.WriteLine("Сортування за атмосферним тиском: P");
            Console.WriteLine("Сортування за швидкiстю вiтру: V");
            Console.WriteLine("Вихiд: Esc");

            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.OemPlus:
                    new Work().Add();
                    goto Start;

                case ConsoleKey.E:
                    new Work().Edit();
                    goto Start;

                case ConsoleKey.D:
                    new Work().SortByDate();
                    goto Start;

                case ConsoleKey.T:
                    new Work().SortByTemperature();
                    goto Start;

                case ConsoleKey.V:
                    new Work().SortByWindSpeed();
                    goto Start;

                case ConsoleKey.P:
                    new Work().SortByPerssure();
                    goto Start;

                case ConsoleKey.OemMinus:
                    new Work().Remove();
                    goto Start;

                case ConsoleKey.Enter:
                    new Output().Write();
                    goto Start;

                case ConsoleKey.Escape:
                    return;

                default:
                    Console.WriteLine();
                    goto Start;
            }
        }
    }
}
