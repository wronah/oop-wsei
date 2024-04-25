using ClassLibrary;

namespace UnitTests
{
    public class TimeTest
    {
        
        [Fact] 
        public void When_IncorrectData_Should_ThrowArgumentException()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => { new Time(24); });
        }
        [Fact]
        public void When_UsingConstructorWith3Elements_Should_CorrectlyAssignData()
        {
            //Arrange
            byte hours = 23;
            byte minutes = 59;
            byte seconds = 59;
            //Act
            var time = new Time(hours, minutes, seconds);
            //Assert
            Assert.Equal(hours, time.Hours);
            Assert.Equal(minutes, time.Minutes);
            Assert.Equal(seconds, time.Seconds);
        }
        [Fact]
        public void When_UsingConstructorWith2Elements_Should_CorrectlyAssignData()
        {
            //Arrange
            byte hours = 23;
            byte minutes = 59;
            //Act
            var time = new Time(hours, minutes);
            //Assert
            Assert.Equal(hours, time.Hours);
            Assert.Equal(minutes, time.Minutes);
        }
        [Fact]
        public void When_UsingConstructorWith1Element_Should_CorrectlyAssignData()
        {
            //Arrange
            byte hours = 23;
            //Act
            var time = new Time(hours);
            //Assert
            Assert.Equal(hours, time.Hours);
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
            var time = new Time(input);
            //Assert
            Assert.Equal(input, time.ToString());
        }
    }
}