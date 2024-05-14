using ClassLibrary;

namespace TestingGrounds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // konstruktor BitMatrix(int, int, params int[])
            // macierz 2x2, tablica null
            var m = new BitMatrix(2, 2, null);
            Console.WriteLine(m);

            // macierz 4x3, tablica zerowej długości
            m = new BitMatrix(4, 3, new int[0]);
            Console.WriteLine(m);
        }
    }
}
