using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        public byte Hours { get; } = 0;
        public byte Minutes { get; } = 0;
        public byte Seconds { get; } = 0;
        public Time(byte hours, byte minutes, byte seconds)
        {
            if (hours > 23)
            {
                throw new ArgumentException("Invalid number of hours (min 0, max 23)");
            }
            if (minutes > 59)
            {
                throw new ArgumentException("Invalid number of minutes (min 0, max 59)");
            }
            if (seconds > 59)
            {
                throw new ArgumentException("Invalid number of seconds (min 0, max 59)");
            }
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
        public Time(byte hours, byte minutes)
        {
            if (hours > 23)
            {
                throw new ArgumentException("Invalid number of hours (min 0, max 23)");
            }
            if (minutes > 59)
            {
                throw new ArgumentException("Invalid number of minutes (min 0, max 59)");
            }
            Hours = hours;
            Minutes = minutes;
        }
        public Time(byte hours)
        {
            if (hours > 23)
            {
                throw new ArgumentException("Invalid number of hours (min 0, max 23)");
            }
            Hours = hours;
        }
        public Time(string input)
        {
            var pattern = "^([0-2][0-3]):([0-5][0-9]):([0-5][0-9])$";
            var regex = new Regex(pattern);
            var matches = regex.Matches(input);
            if (matches.Count == 0) 
            {
                throw new FormatException("Invalid format => try hh:mm:ss");
            }
            Hours = byte.Parse(matches[0].Groups.Values.ToList()[1].Value);
            Minutes = byte.Parse(matches[0].Groups.Values.ToList()[2].Value);
            Seconds = byte.Parse(matches[0].Groups.Values.ToList()[3].Value);
        }
        public override string ToString()
        {
            return $"{Hours:00}:{Minutes:00}:{Seconds:00}"; 
        }

        public bool Equals(Time other)
        {
            if(Equals(this, other)) return true;
            return this.Hours == other.Hours && this.Minutes == other.Minutes && this.Seconds == other.Seconds;
        }
        public override bool Equals(object? obj)
        {
            return obj is Time other && Equals(other);
        }
        public override int GetHashCode()
        {
            return (Hours, Minutes, Seconds).GetHashCode();
        }

        public int CompareTo(Time other)
        {
            if(this.Equals(other)) return 0;
            if(this.Hours != other.Hours) 
                return this.Hours.CompareTo(other.Hours);
            if(this.Minutes != other.Minutes)
                return this.Minutes.CompareTo(other.Minutes);
            return this.Seconds.CompareTo(other.Seconds);
        }

        public static bool operator == (Time t1, Time t2)
        {
            return t1.Equals(t2);
        }
        public static bool operator != (Time t1, Time t2)
        {
            return !(t1 == t2);
        }
        public static bool operator < (Time t1, Time t2)
        {
            if(t1.CompareTo(t2) == -1)
                return true;
            return false;
        }
        public static bool operator <= (Time t1, Time t2)
        {
            if (t1.CompareTo(t2) == -1 || t1.CompareTo(t2) == 0) 
                return true;
            return false;
        }
        public static bool operator > (Time t1, Time t2)
        {
            if(t1.CompareTo(t2) == 1) 
                return true;
            return false;
        }
        public static bool operator >= (Time t1, Time t2)
        {
            if(t1.CompareTo(t2) == 1 || t1.CompareTo(t2) == 0)
                return true;
            return false;
        }
        public Time Plus(TimePeriod timePeriod)
        {
            var values = timePeriod.ToString().Split(':');
            return new Time
            (
                Convert.ToByte(Hours + Convert.ToByte(values[0]) % 24),
                Convert.ToByte(Minutes + Convert.ToByte(values[1]) % 60),
                Convert.ToByte(Seconds + Convert.ToByte(values[2]) % 24)
            );
        }
        public static Time Plus(Time time, TimePeriod timePeriod)
        {
            var values = timePeriod.ToString().Split(':');
            return new Time
            (
                Convert.ToByte(time.Hours + Convert.ToByte(values[0]) % 24),
                Convert.ToByte(time.Minutes + Convert.ToByte(values[1]) % 60),
                Convert.ToByte(time.Seconds + Convert.ToByte(values[2]) % 24)
            );
        }
        public static Time operator +(Time time, TimePeriod timePeriod)
        {
            return Plus(time, timePeriod);
        }
    }
}
