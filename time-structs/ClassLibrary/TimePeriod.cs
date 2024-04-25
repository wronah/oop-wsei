using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        public long Duration { get; } = 0;
        public TimePeriod(long hours, long minutes, long seconds)
        {
            if (hours < 0 )
            {
                throw new ArgumentException("Invalid number of hours (cannot be less than 0)");
            }
            if (minutes < 0 || minutes > 59)
            {
                throw new ArgumentException("Invalid number of minutes (min 0, max 59)");
            }
            if (seconds < 0 || seconds > 59)
            {
                throw new ArgumentException("Invalid number of seconds (min 0, max 59)");
            }
            Duration = hours * 3600 + minutes * 60 + seconds;
        }
        public TimePeriod(long hours, long minutes)
        {
            if (hours < 0)
            {
                throw new ArgumentException("Invalid number of hours (cannot be less than 0)");
            }
            if (minutes < 0 || minutes > 59)
            {
                throw new ArgumentException("Invalid number of minutes (min 0, max 59)");
            }
            Duration = hours * 3600 + minutes * 60;
        }
        public TimePeriod(long seconds)
        {
            if (seconds < 0 || seconds > 59)
            {
                throw new ArgumentException("Invalid number of seconds (min 0, max 59)");
            }
            Duration = seconds;
        }
        public TimePeriod(string input)
        {
            var pattern = "^([0-9]+):([0-5][0-9]):([0-5][0-9])$";
            var regex = new Regex(pattern);
            var matches = regex.Matches(input);
            if (matches.Count == 0)
            {
                throw new FormatException("Invalid format => try h:mm:ss");
            }
            var hours = byte.Parse(matches[0].Groups.Values.ToList()[1].Value);
            var minutes = byte.Parse(matches[0].Groups.Values.ToList()[2].Value);
            var seconds = byte.Parse(matches[0].Groups.Values.ToList()[3].Value);
            Duration = hours * 3600 + minutes * 60 + seconds;
        }
        public override string ToString()
        {
            return $"{GetHours(Duration)}:{GetMinutes(Duration):00}:{GetSeconds(Duration):00}";
        }

        private long GetHours(long allSeconds)
        {
            return allSeconds / 3600;
        }
        private long GetMinutes(long allSeconds)
        {
            return allSeconds / 60 - GetHours(allSeconds) * 60;
        }
        private long GetSeconds(long allSeconds)
        {
            return allSeconds - GetHours(allSeconds) * 3600 - GetMinutes(allSeconds) * 60;
        }

        public bool Equals(TimePeriod other)
        {
            if (Equals(this, other)) return true;
            return this.Duration == other.Duration;
        }
        public override bool Equals(object? obj)
        {
            return obj is TimePeriod other && Equals(other);
        }
        public override int GetHashCode()
        {
            return Duration.GetHashCode();
        }

        public int CompareTo(TimePeriod other)
        {
            if (this.Equals(other)) return 0;
            if (GetHours(Duration) != GetHours(other.Duration))
                return GetHours(Duration).CompareTo(GetHours(other.Duration));
            if (GetMinutes(Duration) != GetMinutes(other.Duration))
                return GetMinutes(Duration).CompareTo(GetMinutes(other.Duration));
            return GetSeconds(Duration).CompareTo(GetSeconds(other.Duration));
        }

        public static bool operator ==(TimePeriod t1, TimePeriod t2)
        {
            return t1.Equals(t2);
        }
        public static bool operator !=(TimePeriod t1, TimePeriod t2)
        {
            return !(t1 == t2);
        }
        public static bool operator <(TimePeriod t1, TimePeriod t2)
        {
            if (t1.CompareTo(t2) == -1)
                return true;
            return false;
        }
        public static bool operator <=(TimePeriod t1, TimePeriod t2)
        {
            if (t1.CompareTo(t2) == -1 || t1.CompareTo(t2) == 0)
                return true;
            return false;
        }
        public static bool operator >(TimePeriod t1, TimePeriod t2)
        {
            if (t1.CompareTo(t2) == 1)
                return true;
            return false;
        }
        public static bool operator >=(TimePeriod t1, TimePeriod t2)
        {
            if (t1.CompareTo(t2) == 1 || t1.CompareTo(t2) == 0)
                return true;
            return false;
        }
    }
}
