using System;
using System.Collections;

namespace OOP_lab_8_7_1
{
    class Weather : IComparable
    {
        private DateTime _date;
        private string _city;
        private int _pressure;
        private int _temperature;
        private int _windSpeed;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public int Pressure
        {
            get { return _pressure; }
            set { _pressure = value; }
        }
        public int Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }
        public int WindSpeed
        {
            get { return _windSpeed; }
            set { _windSpeed = value; }
        }

        public virtual string UkrainianI(string str)
        {
            char[] ch = str.ToCharArray();

            for (int i = 0; i < ch.Length; ++i)
            {
                if (ch[i] == 'і')
                {
                    ch[i] = 'i';
                }

                if (ch[i] == 'І')
                {
                    ch[i] = 'I';
                }
            }

            return new string(ch);
        }

        public Weather()
        {
            _date = DateTime.Parse("01.01.0001");
            _city = "Не вказано";
            _pressure = 0;
            _temperature = 0;
            _windSpeed = 0;
        }

        public Weather(DateTime Date, string City, int Pressure, int Temerature, int WindSpeed)
        {
            _date = Date;
            _city = UkrainianI(City);
            _pressure = Pressure;
            _temperature = Temerature;
            _windSpeed = WindSpeed;
        }

        public int CompareTo(object x)
        {
            Weather weather = (Weather)x;

            if (this.Date > weather.Date)
            {
                return 1;
            }

            if (this.Date < weather.Date)
            {
                return -1;
            }

            return 0;
        }

        public class SortByTemperature : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                Weather weather1 = (Weather)x;
                Weather weather2 = (Weather)y;

                if (weather1.Temperature > weather2.Temperature)
                {
                    return 1;
                }

                if (weather1.Temperature < weather2.Temperature)
                {
                    return -1;
                }

                return 0;
            }
        }

        public class SortByWindSpeed : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                Weather weather1 = (Weather)x;
                Weather weather2 = (Weather)y;

                if (weather1.WindSpeed > weather2.WindSpeed)
                {
                    return 1;
                }

                if (weather1.WindSpeed < weather2.WindSpeed)
                {
                    return -1;
                }

                return 0;
            }
        }

        public class SortByPressure : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                Weather weather1 = (Weather)x;
                Weather weather2 = (Weather)y;

                if (weather1.Pressure > weather2.Pressure)
                {
                    return 1;
                }

                if (weather1.Pressure < weather2.Pressure)
                {
                    return -1;
                }

                return 0;
            }
        }
    }
}
