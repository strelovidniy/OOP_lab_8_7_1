using System;

namespace OOP_lab_8_7_1
{
    class Output : IOutput
    {
        public const string Format = "{0,-15} {1, -15} {2, -30} {3, -30} {4, -15}";

        public void Write()
        {
            Console.WriteLine(Format, "Дата", "Мiсто", "Атмосферний тиск", "Температура повiтря", "Швидкiсть вiтру");

            foreach (Weather w in Program.weather)
            {
                Console.WriteLine(Format, w.Date.ToShortDateString(), w.City, w.Pressure, w.Temperature, w.WindSpeed);
            }
        }
    }
}
