using ClassLibrary;

namespace UnitTests.Matrix2DTest
{
    public class MatrixOperationsTest
    {
        [Fact]
        public void Should_TransposeMatrix()
        {
            //Arrange
            var matrix1 = new Matrix2D(1, 2, 3, 4);
            //Act
            var result = Matrix2D.Transpose(matrix1);
            //Assert
            Assert.Equal(new Matrix2D(1, 3, 2, 4), result);
        }
        [Fact]
        public void Should_CalculateDeterminantStaticMethod()
        {
            //Arrange
            var matrix1 = Matrix2D.Zero;
            var matrix2 = new Matrix2D(1, 2, 3, 4);
            //Act
            var result1 = Matrix2D.Determinant(matrix1);
            var result2 = Matrix2D.Determinant(matrix2);
            //Assert
            Assert.Equal(0, result1);
            Assert.Equal(-2, result2);
        }
        [Fact]
        public void Should_CalculateDeterminant()
        {
            //Arrange
            var matrix1 = Matrix2D.Id;
            //Act
            var result = matrix1.Det();
            //Assert
            Assert.Equal(1, result);
        }
        [Fact]
        public void Should_CastToArray()
        {
            //Arrange
            var matrix1 = new Matrix2D(1, 2, 3, 4);
            //Act
            var result = (int[,])matrix1;
            //Assert
            Assert.Equal(new int[,] { { 1, 2 }, { 3, 4 } }, result);
        }
        [Fact]
        public void Should_ParseStringToMatrix2D()
        {
            //Arrange
            var input = "[[22, 3], [333, 1]]";
            //Act
            var result = Matrix2D.Parse(input);
            //Assert
            Assert.Equal(new Matrix2D(22, 3, 333, 1), result);
        }
        [Fact]
        public void When_InputDoesNotMatchPattern_Should_ThrowFormatException()
        {
            //Arrange
            var input = "[[22, 3] [333, 1]]";
            //Act
            //Assert
            Assert.Throws<FormatException>(() => Matrix2D.Parse(input));
        }
        [Fact]
        public void Should_ParseMatrix2DToString()
        {
            //Arrange
            var matrix1 = new Matrix2D();
            //Act
            var result = matrix1.ToString();
            //Assert
            Assert.Equal("[[1, 0], [0, 1]]", result);
        }
    }
}
