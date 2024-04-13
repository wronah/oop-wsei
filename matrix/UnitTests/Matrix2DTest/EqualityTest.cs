using ClassLibrary;

namespace UnitTests.Matrix2DTest
{
    public class EqualityTest
    {
        [Fact]
        public void When_TwoObjectsWithTheSameValues_Should_ReturnTrue()
        {
            //Arrange
            var matrix1 = new Matrix2D(1, 1, 1, 1);
            var matrix2 = new Matrix2D(1, 1, 1, 1);
            //Act
            var isEqual = matrix1.Equals(matrix2);
            //Assert
            Assert.True(isEqual);
        }
        [Fact]
        public void When_TwoObjectsWithDifferentValues_Should_ReturnFalse()
        {
            //Arrange
            var matrix1 = new Matrix2D(1, 1, 1, 1);
            var matrix2 = new Matrix2D(1, 2, 2, 1);
            //Act
            var isEqual = matrix1.Equals(matrix2);
            //Assert
            Assert.False(isEqual);
        }
        [Fact]
        public void When_TwoObjectsWithDifferentValuesAndUsingOverrideEquals_Should_ReturnFalse()
        {
            //Arrange
            var matrix1 = new Matrix2D(1, 1, 1, 1);
            object matrix2 = new Matrix2D(1, 2, 2, 1);
            //Act
            var isEqual = matrix1.Equals(matrix2);
            //Assert
            Assert.False(isEqual);
        }
        [Fact]
        public void When_TwoObjectsWithTheSameValuesAndUsingOverrideEquals_Should_ReturnTrue()
        {
            //Arrange
            var matrix1 = new Matrix2D(1, 1, 1, 1);
            object matrix2 = new Matrix2D(1, 1, 1, 1);
            //Act
            var isEqual = matrix1.Equals(matrix2);
            //Assert
            Assert.True(isEqual);
        }
        [Fact]
        public void When_TwoObjectsWithDifferentValuesAndUsingNotEqualOperator_Should_ReturnTrue()
        {
            //Arrange
            var matrix1 = new Matrix2D(1, 1, 1, 1);
            var matrix2 = new Matrix2D(1, 2, 2, 1);
            //Act
            var isEqual = matrix1 != matrix2;
            //Assert
            Assert.True(isEqual);
        }
        [Fact]
        public void When_TwoObjectsWithTheSameValuesAndUsingNotEqualOperator_Should_ReturnFalse()
        {
            //Arrange
            var matrix1 = new Matrix2D(1, 1, 1, 1);
            var matrix2 = new Matrix2D(1, 1, 1, 1);
            //Act
            var isEqual = matrix1 != matrix2;
            //Assert
            Assert.False(isEqual);
        }
        [Fact]
        public void When_TwoObjectsWithTheSameValuesAndUsingEqualOperator_Should_ReturnTrue()
        {
            //Arrange
            var matrix1 = new Matrix2D(1, 1, 1, 1);
            var matrix2 = new Matrix2D(1, 1, 1, 1);
            //Act
            var isEqual = matrix1 == matrix2;
            //Assert
            Assert.True(isEqual);
        }
        [Fact]
        public void When_TwoObjectsWithDifferentValuesAndUsingEqualOperator_Should_ReturnFalse()
        {
            //Arrange
            var matrix1 = new Matrix2D(1, 1, 1, 1);
            var matrix2 = new Matrix2D(1, 2, 1, 1);
            //Act
            var isEqual = matrix1 == matrix2;
            //Assert
            Assert.False(isEqual);
        }
        [Fact]
        public void When_OneMatrixObjectIsNull_Should_ReturnFalse()
        {
            //Arrange
            var matrix1 = new Matrix2D(1, 1, 1, 1);
            Matrix2D? matrix2 = null;
            //Act
            var isEqual = matrix1.Equals(matrix2);
            //Assert
            Assert.False(isEqual);
        }
        [Fact]
        public void When_ComparingTheSameReference_Should_ReturnTrue()
        {
            //Arrange
            var matrix1 = new Matrix2D(1, 1, 1, 1);
            var matrix2 = matrix1;
            //Act
            var isEqual = matrix1.Equals(matrix2);
            //Assert
            Assert.True(isEqual);
        }
        [Fact]
        public void When_ObjectsHaveTheSameValues_Should_ReturnTrue()
        {
            //Arrange
            var matrix1 = new Matrix2D(1, 1, 1, 1);
            var matrix2 = new Matrix2D(1, 1, 1, 1);
            //Act
            var hashCode1 = matrix1.GetHashCode();
            var hashCode2 = matrix2.GetHashCode();
            var areEqual = hashCode1 == hashCode2;
            //Assert
            Assert.True(areEqual);
        }
        [Fact]
        public void When_ObjectsHaveTheSameValuesInDifferentVariables_Should_ReturnFalse()
        {
            //Arrange
            var matrix1 = new Matrix2D(1, 1, 2, 1);
            var matrix2 = new Matrix2D(1, 2, 1, 1);
            //Act
            var hashCode1 = matrix1.GetHashCode();
            var hashCode2 = matrix2.GetHashCode();
            var areEqual = hashCode1 == hashCode2;
            //Assert
            Assert.False(areEqual);
        }
        [Fact]
        public void When_ObjectsHaveDifferentValues_Should_ReturnFalse()
        {
            //Arrange
            var matrix1 = new Matrix2D(7, 2, 2, 3);
            var matrix2 = new Matrix2D(1, 2, 3, 4);
            //Act
            var hashCode1 = matrix1.GetHashCode();
            var hashCode2 = matrix2.GetHashCode();
            var areEqual = hashCode1 == hashCode2;
            //Assert
            Assert.False(areEqual);
        }
    }
}
