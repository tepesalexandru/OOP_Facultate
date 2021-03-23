using System;
using System.Linq;

namespace Time
{
    class Time
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Milliseconds { get; set; }
        public Time(int Hours, int Minutes)
        {
            this.Hours = Hours;
            this.Minutes = Minutes;
        }
        public Time(int Hours, int Minutes, int Seconds)
        {
            this.Hours = Hours;
            this.Minutes = Minutes;
            this.Seconds = Seconds;
        }
        public Time(int Hours, int Minutes, int Seconds, int Milliseconds)
        {
            this.Hours = Hours;
            this.Minutes = Minutes;
            this.Seconds = Seconds;
            this.Milliseconds = Milliseconds;
        }
        public Time(string time)
        {
            try
            {
                var values = time.Split(';').Select(Int32.Parse).ToList();
                Hours = values[0];
                Minutes = values[1];
                Seconds = values[2];
                Milliseconds = values[3];
            } catch (Exception e)
            {
                Console.WriteLine("Invalid format");
            }
        }
        public static int SecondsToMilliseconds(int seconds)
        {
            return seconds * 1000;
        }
        public static int MinutesToMilliseconds(int minutes)
        {
            int minutesToSeconds = minutes * 60;
            return SecondsToMilliseconds(minutesToSeconds);
        }
        public static int HoursToMilliseconds(int hours)
        {
            int hoursToMinutes = hours * 60;
            return MinutesToMilliseconds(hoursToMinutes);
        }
        public static int TimeToMilliseconds(Time time)
        {
            return HoursToMilliseconds(time.Hours)     + 
                   MinutesToMilliseconds(time.Minutes) + 
                   SecondsToMilliseconds(time.Seconds) + 
                   time.Milliseconds;
        }
        public static Time MillisecondsToTime(int n)
        {
            int milliseconds = n % 1000;
            n /= 1000;
            int seconds = n % 60;
            n /= 60;
            int minutes = n % 60;
            n /= 60;
            int hours = n;
            return new Time(hours, minutes, seconds, milliseconds);
        }
        public static Time operator + (Time t1, Time t2)
        {
            int totalMilliseconds = TimeToMilliseconds(t1) + TimeToMilliseconds(t2);
            return MillisecondsToTime(totalMilliseconds);
        }
        public static Time operator - (Time t1, Time t2)
        {
            int totalMilliseconds = TimeToMilliseconds(t1) - TimeToMilliseconds(t2);
            return MillisecondsToTime(totalMilliseconds);
        }

        public static bool operator == (Time t1, Time t2)
        {
            return TimeToMilliseconds(t1) == TimeToMilliseconds(t2);
        }
        public static bool operator != (Time t1, Time t2)
        {
            return TimeToMilliseconds(t1) != TimeToMilliseconds(t2);
        }
        public static bool operator > (Time t1, Time t2)
        {
            return TimeToMilliseconds(t1) > TimeToMilliseconds(t2);
        }
        public static bool operator < (Time t1, Time t2)
        {
            return TimeToMilliseconds(t1) < TimeToMilliseconds(t2);
        }
        public static bool operator >= (Time t1, Time t2)
        {
            return TimeToMilliseconds(t1) >= TimeToMilliseconds(t2);
        }
        public static bool operator <= (Time t1, Time t2)
        {
            return TimeToMilliseconds(t1) <= TimeToMilliseconds(t2);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
