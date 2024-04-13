namespace ClassLibrary
{
    public class Matrix2D : IEquatable<Matrix2D>
    {
        public static Matrix2D Id { get { return new Matrix2D(); } }
        public static Matrix2D Zero { get { return new Matrix2D(0, 0, 0, 0); } }

        private int a;
        private int b;
        private int c;
        private int d;

        public Matrix2D(int a, int b, int c, int d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }
        public Matrix2D() : this(1,0,0,1)
        {
        }

        public override string ToString()
        {
            return $"[[{a},{b}], [{c}, {d}]]";
        }

        public bool Equals(Matrix2D? other)
        {
            if(other is null) return false;
            if(ReferenceEquals(this, other)) return true;
            return a == other.a && b == other.b && c == other.c && d == other.d;
        }
        public override bool Equals(object? obj)
        {
            return obj is Matrix2D other && Equals(other);
        }
        public static bool operator == (Matrix2D left, Matrix2D right)
        {
            return ReferenceEquals(left, right) || (left is not null && left.Equals(right));
        }
        public static bool operator != (Matrix2D left, Matrix2D right)
        {
            return !(left == right);
        }
        
        public override int GetHashCode()
        {
            return HashCode.Combine(a,b,c,d);
        }

    }
}
