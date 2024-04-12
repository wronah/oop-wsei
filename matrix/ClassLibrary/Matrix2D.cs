namespace ClassLibrary
{
    public class Matrix2D
    {
        public static Matrix2D Id { get { return new Matrix2D(1, 0, 0, 1); } }
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

        public override string ToString()
        {
            return $"[[{a},{b}], [{c}, {d}]]";
        }
    }
}
