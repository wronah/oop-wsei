using ClassLibrary;

namespace UnitTests.Matrix2DTest
{
    public class ArithmeticOperationsTest
    {
        [Fact]
        public void Should_AddMatrixes()
        {
            //Arrange
            var matrix1 = new Matrix2D(1, 1, 1, 1);
            var matrix2 = new Matrix2D(1, 1, 1, 1);
            //Act
            var result = matrix1 + matrix2;
            //Assert
            Assert.Equal(new Matrix2D(2, 2, 2, 2), result);
        }
        [Fact]
        public void Should_SubtractMatrixes()
        {
            //Arrange
            var matrix1 = new Matrix2D(1, 1, 1, 1);
            var matrix2 = new Matrix2D(1, 1, 1, 1);
            //Act
            var result = matrix1 - matrix2;
            //Assert
            Assert.Equal(new Matrix2D(0, 0, 0, 0), result);
        }
        [Fact]
        public void Should_MultiplyMatrixes()
        {
            //Arrange
            var matrix1 = new Matrix2D(1, 2, 3, 4);
            var matrix2 = new Matrix2D(1, 2, 3, 4);
            //Act
            var result = matrix1 * matrix2;
            //Assert
            Assert.Equal(new Matrix2D(7, 10, 15, 22), result);
        }
        [Fact]
        public void Should_MultiplyMatrixByK()
        {
            //Arrange
            var matrix1 = new Matrix2D(1, 2, 3, 4);
            var k = 2;
            //Act
            var result1 = matrix1 * k;
            //Assert
            Assert.Equal(new Matrix2D(2, 4, 6, 8), result1);
        }
        [Fact]
        public void Should_MultiplyKByMatrix()
        {
            //Arrange
            var matrix1 = new Matrix2D(1, 2, 3, 4);
            var k = 2;
            //Act
            var result1 = k * matrix1;
            //Assert
            Assert.Equal(new Matrix2D(2, 4, 6, 8), result1);
        }
        [Fact]
        public void Should_ChangeValuesInMatrix()
        {
            //Arrange
            var matrix1 = new Matrix2D(1, 2, 3, 4);
            //Act
            var result1 = -matrix1;
            //Assert
            Assert.Equal(new Matrix2D(-1, -2, -3, -4), result1);
        }
    }
}
