using ClassLibrary;

namespace TestingGrounds
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // weryfikacja implementacji
            // interfejsu `ICloneable`
            var m = new BitMatrix(1, 1);
            Console.WriteLine(m is ICloneable);
        }
    }
}
