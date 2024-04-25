using ClassLibrary;

namespace UnitTests
{
    public class TimePeriodTest
    {
        [Fact]
        public void When_IncorrectData_Should_ThrowArgumentException()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => { new TimePeriod(-24); });
        }
        [Fact]
        public void When_UsingConstructorWith3Elements_Should_CorrectlyAssignData()
        {
            //Arrange
            byte hours = 23;
            byte minutes = 59;
            byte seconds = 59;
            //Act
            var time = new TimePeriod(hours, minutes, seconds);
            //Assert
            Assert.Equal(hours * 3600 + minutes * 60 + seconds, time.Duration);
        }
        [Fact]
        public void When_UsingConstructorWith2Elements_Should_CorrectlyAssignData()
        {
            //Arrange
            byte hours = 1;
            byte minutes = 2;
            //Act
            var time = new TimePeriod(hours, minutes);
            //Assert
            Assert.Equal(hours * 3600 + minutes * 60, time.Duration);

        }
        [Fact]
        public void When_UsingConstructorWith1Element_Should_CorrectlyAssignData()
        {
            //Arrange
            byte seconds = 100;
            //Act
            var time = new TimePeriod(seconds);
            //Assert
            Assert.Equal(seconds, time.Duration);
        }
        [Fact]
        public void When_UsingConstructorWithString_Should_CorrectyAssignData()
        {
            //Arrange
            byte hours = 23;
            byte minutes = 59;
            byte seconds = 59;
            string input = $"{hours}:{minutes}:{seconds}";
            //Act
            var time = new TimePeriod(input);
            //Assert
            Assert.Equal(input, time.ToString());
        }
    }
}
