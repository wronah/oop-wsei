namespace ClassLibrary
{
    public partial class BitMatrix : IEquatable<BitMatrix>
    {
        public bool Equals(BitMatrix? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if(NumberOfRows != other.NumberOfRows && NumberOfColumns != other.NumberOfColumns) return false;
            for(int i = 0; i < data.Length; i++)
            {
                if (data[i] != other.data[i]) return false;
            }
            return NumberOfRows == other.NumberOfRows && NumberOfColumns == other.NumberOfColumns && IsReadOnly == other.IsReadOnly;
        }
        public override bool Equals(object? obj)
        {
            return obj is BitMatrix other && Equals(other);
        }
        public static bool operator ==(BitMatrix left, BitMatrix right)
        {
            return ReferenceEquals(left, right) || (left is not null && left.Equals(right));
        }
        public static bool operator !=(BitMatrix left, BitMatrix right)
        {
            return !(left == right);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(data, NumberOfRows, NumberOfColumns, IsReadOnly);
        }
    }
}
