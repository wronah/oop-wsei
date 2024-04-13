using System.Text.RegularExpressions;

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
        public static Matrix2D operator + (Matrix2D left, Matrix2D right)
        {
            return new Matrix2D(left.a + right.a, left.b + right.b, left.c + right.c, left.d + right.d);
        }
        public static Matrix2D operator - (Matrix2D left, Matrix2D right)
        {
            return new Matrix2D(left.a - right.a, left.b - right.b, left.c - right.c, left.d - right.d);
        }
        public static Matrix2D operator * (Matrix2D left, Matrix2D right)
        {
            return new Matrix2D(
                left.a * right.a + left.b * right.c,
                left.a * right.b + left.b * right.d,
                left.c * right.a + left.d * right.c,
                left.c * right.b + left.d * right.d
            );
        }
        public static Matrix2D operator * (Matrix2D matrix, int k)
        {
            return new Matrix2D(matrix.a * k, matrix.b * k, matrix.c * k, matrix.d * k);
        }
        public static Matrix2D operator * (int k, Matrix2D matrix)
        {
            return k * matrix;
        }
        public static Matrix2D operator - (Matrix2D matrix)
        {
            return -1 * matrix;
        }
        public static Matrix2D Transpose(Matrix2D matrix)
        {
            return new Matrix2D(matrix.a, matrix.c, matrix.b, matrix.d);
        }
        public static int Determinant(Matrix2D matrix)
        {
            return matrix.a * matrix.d - matrix.b * matrix.c;
        }
        public int Det()
        {
            return Determinant(this);
        }
        public static explicit operator int[,] (Matrix2D matrix)
        {
            return new int[2, 2] { { matrix.a, matrix.b }, { matrix.c, matrix.d } };
        }
        public static Matrix2D Parse(string input)
        {
            var pattern = @"\[\[([0-9]+), ([0-9]+)\], \[([0-9]+), ([0-9]+)\]\]";
            Regex regex = new Regex(pattern);

            var matches = regex.Matches(input);
            if(matches.Count > 0)
            {
                return new Matrix2D(
                    int.Parse(matches[0].Groups[1].Value),
                    int.Parse(matches[0].Groups[2].Value),
                    int.Parse(matches[0].Groups[3].Value),
                    int.Parse(matches[0].Groups[4].Value)
                );
            }
            throw new FormatException();
        }
    }
}
