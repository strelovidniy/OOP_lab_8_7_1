using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OOP_lab_7_7_2
{
    class Work : IWork
    {
        public void Add()
        {
            StreamWriter file = new StreamWriter("base.txt", true);

            Console.WriteLine("\nВведiть новi данi");

        RetryDate:
            Console.Write("Дата: ");

            try
            {
                file.WriteLine(DateTime.Parse(Console.ReadLine()));
            }
            catch (SystemException)
            {
                Console.WriteLine("Неправильно вказана дата!");

                goto RetryDate;
            }

            Console.Write("Мiсто: ");

            file.WriteLine(Console.ReadLine());

        RetryPressure:
            Console.Write("Атмосферний тиск: ");

            try
            {
                file.WriteLine(int.Parse(Console.ReadLine()));
            }
            catch (SystemException)
            {
                Console.WriteLine("Атмосферний тиск має бути вказаний лише числом!");

                goto RetryPressure;
            }

        RetryTemperature:
            Console.Write("Температура: ");

            try
            {
                file.WriteLine(int.Parse(Console.ReadLine()));
            }
            catch (SystemException)
            {
                Console.WriteLine("Температура має бути вказана лише числом!");

                goto RetryTemperature;
            }

        RetryWindSpeed:
            Console.Write("Швидкiсть вiтру: ");

            try
            {
                file.WriteLine(int.Parse(Console.ReadLine()));
            }
            catch (SystemException)
            {
                Console.WriteLine("Швидкiсть вiтру має бути вказана лише числом!");

                goto RetryWindSpeed;
            }

            file.Close();

            new Input().ReadBase();
        }

        public void Remove()
        {
            Console.WriteLine();

            new Output().Write();

            Console.Write("\nВведiть данi для видалення: ");

            DateTime tempDate;
            string tempCity;
            int tempPressure;
            int tempTemperature;
            int tempWindSpeed;


        RetryDate:
            Console.Write("Дата: ");

            try
            {
                tempDate = DateTime.Parse(Console.ReadLine());
            }
            catch (SystemException)
            {
                Console.WriteLine("Неправильно вказана дата!");

                goto RetryDate;
            }

            Console.Write("Мiсто: ");

            tempCity = Console.ReadLine();

        RetryPressure:
            Console.Write("Атмосферний тиск: ");

            try
            {
                tempPressure = int.Parse(Console.ReadLine());
            }
            catch (SystemException)
            {
                Console.WriteLine("Атмосферний тиск має бути вказаний лише числом!");

                goto RetryPressure;
            }

        RetryTemperature:
            Console.Write("Температура: ");

            try
            {
                tempTemperature = int.Parse(Console.ReadLine());
            }
            catch (SystemException)
            {
                Console.WriteLine("Температура має бути вказана лише числом!");

                goto RetryTemperature;
            }

        RetryWindSpeed:
            Console.Write("Швидкiсть вiтру: ");

            try
            {
                tempWindSpeed = int.Parse(Console.ReadLine());
            }
            catch (SystemException)
            {
                Console.WriteLine("Швидкiсть вiтру має бути вказана лише числом!");

                goto RetryWindSpeed;
            }

            if (Program.weather.Remove(new Weather(tempDate, tempCity, tempPressure, tempTemperature, tempWindSpeed)))
            {
                Console.Write("Видалено.\n");

                StreamWriter file = new StreamWriter("base.txt");

                foreach (Weather w in Program.weather)
                {
                    file.WriteLine(w.Date.ToShortDateString());
                    file.WriteLine(w.City);
                    file.WriteLine(w.Pressure);
                    file.WriteLine(w.Temperature);
                    file.WriteLine(w.WindSpeed);
                }

                file.Close();

                new Input().ReadBase();
            }
        }

        public void Edit()
        {
            Console.WriteLine();

            new Output().Write();

            Weather[] tempW = Program.weather.ToArray();

            Console.Write("Порядковий номер запису для редагування: ");

            bool[] edit = new bool[tempW.Length];

            for (int i = 0; i < edit.Length; ++i)
            {
                edit[i] = false;
            }

            try
            {
                edit[int.Parse(Console.ReadLine()) - 1] = true;
            }
            catch (SystemException)
            {
                Console.WriteLine("Такого запису не iснує!");
                return;
            }

            StreamWriter file = new StreamWriter("base.txt");

            for (int i = 0; i < tempW.Length; ++i)
            {
                if (edit[i])
                {
                    Console.WriteLine("\nВведiть новi данi");

                RetryDate:
                    Console.Write("Дата: ");

                    try
                    {
                        file.WriteLine(DateTime.Parse(Console.ReadLine()));
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Неправильно вказана дата!");

                        goto RetryDate;
                    }

                    Console.Write("Мiсто: ");

                    file.WriteLine(Console.ReadLine());

                RetryPressure:
                    Console.Write("Атмосферний тиск: ");

                    try
                    {
                        file.WriteLine(int.Parse(Console.ReadLine()));
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Атмосферний тиск має бути вказаний лише числом!");

                        goto RetryPressure;
                    }

                RetryTemperature:
                    Console.Write("Температура: ");

                    try
                    {
                        file.WriteLine(int.Parse(Console.ReadLine()));
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Температура має бути вказана лише числом!");

                        goto RetryTemperature;
                    }

                RetryWindSpeed:
                    Console.Write("Швидкiсть вiтру: ");

                    try
                    {
                        file.WriteLine(int.Parse(Console.ReadLine()));
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Швидкiсть вiтру має бути вказана лише числом!");

                        goto RetryWindSpeed;
                    }
                }
                else
                {
                    file.WriteLine(Program.weather[i].Date.ToShortDateString());
                    file.WriteLine(Program.weather[i].City);
                    file.WriteLine(Program.weather[i].Pressure);
                    file.WriteLine(Program.weather[i].Temperature);
                    file.WriteLine(Program.weather[i].WindSpeed);
                }
            }

            Console.Write("Змiни внесено.\n");

            file.Close();

            new Input().ReadBase();
        }

        public void SortByDate()
        {
            Console.WriteLine();

            Program.weather.Sort();

            new Output().Write();
        }

        public void SortByTemperature()
        {
            Console.WriteLine();

            Weather[] tempW = Program.weather.ToArray();

            Array.Sort(tempW, new Weather.SortByTemperature());

            Program.weather = tempW.ToList();

            new Output().Write();
        }

        public void SortByWindSpeed()
        {
            Console.WriteLine();

            Weather[] tempW = Program.weather.ToArray();

            Array.Sort(tempW, new Weather.SortByWindSpeed());

            Program.weather = tempW.ToList();

            new Output().Write();
        }

        public void SortByPerssure()
        {
            Console.WriteLine();

            Weather[] tempW = Program.weather.ToArray();

            Array.Sort(tempW, new Weather.SortByPressure());

            Program.weather = tempW.ToList();

            new Output().Write();
        }
    }
}
