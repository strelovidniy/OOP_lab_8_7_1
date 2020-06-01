using System.Collections.Generic;

namespace OOP_lab_7_7_2
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
