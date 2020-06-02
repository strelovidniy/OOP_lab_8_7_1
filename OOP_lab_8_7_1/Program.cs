using System.Collections.Generic;

namespace OOP_lab_8_7_1
{
    class Program
    {
        public static List<Weather> weather = new List<Weather>();

        static void Main()
        {
            new Input().Read();
        }
    }
}
