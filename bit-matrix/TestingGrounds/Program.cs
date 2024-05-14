using ClassLibrary;

namespace TestingGrounds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // indekser - poprawne indeksy
            var m = new BitMatrix(3, 4);
            m[0, 0] = 1;
            Console.WriteLine(m[0, 0]);

            m[2, 3] = 1;
            Console.WriteLine(m[2, 3]);

            m[1, 1] = 1;
            Console.WriteLine(m[1, 1]);
        }
    }
}
