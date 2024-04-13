using ClassLibrary;

namespace ClassUsage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Identity matrix (static): { Matrix2D.Id }");
            Console.WriteLine($"Zero matrix (static): { Matrix2D.Zero }");
            Console.WriteLine();

            var matrix1 = new Matrix2D(1,2,3,4);
            var matrix2 = new Matrix2D(1,2,3,4);

            Console.WriteLine($"Check if matrix: {matrix1} is equal to matrix: {matrix2}");
            Console.WriteLine($"Equals: {matrix1.Equals(matrix2)}");
            Console.WriteLine($"== Operator: {matrix1 == matrix2}");
            Console.WriteLine($"!= Operator: {matrix1 != matrix2}");
            Console.WriteLine();

            Console.WriteLine($"Arithmetic operations on matrix: {matrix1} and matrix: {matrix2}:");
            Console.WriteLine($"Add matrixes: {matrix1 + matrix2}");
            Console.WriteLine($"Subtract matrixes: {matrix1 - matrix2}");
            Console.WriteLine($"Multiply matrixes: {matrix1 * matrix2}");
            var k = 3;
            Console.WriteLine($"Multiply matrix: {matrix1} by k: {k}: {matrix1 * k} and the other way: {k * matrix1}");
            Console.WriteLine($"Inverse matrix: {matrix1}, result: {-matrix1}");
            Console.WriteLine();

            Console.WriteLine($"Matrix operations on matrix: {matrix1}");
            Console.WriteLine($"Transpose: {Matrix2D.Transpose(matrix1)}");
            Console.WriteLine($"Determinant (static method): {Matrix2D.Determinant(matrix1)}");
            Console.WriteLine($"Determinant : {matrix1.Det()}");
            Console.WriteLine();

            var input = "[[2, 2], [2, 2]]";
            Console.WriteLine($"Parse {input} string to matrix object: {Matrix2D.Parse(input)}");
        }
    }
}
