using Project__part_B_;

namespace TestProject
{
    [TestClass]
    public sealed class TestArtist
    {
        private Artist artist;

        //Setup
        [TestInitialize]
        public void Setup()
        {
            artist = new Artist();
        }

        [TestCleanup]
        public void Cleanup()
        {
            artist = null;
        }

        //Public properties
        [TestMethod]
        public void Name_empty_input()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => artist.Name = "");
        }

        [TestMethod]
        [DataRow ("a")] //less than 3 symbols
        [DataRow ("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")] //more than 50 symbols
        public void Name_incorrect_input(string s)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => artist.Name = s);
        }

        [TestMethod]
        public void Name_correct_input()
        {
            //Arrange
            string name = "Kurt Cobain";
            string expected = name;

            //Act
            artist.Name = name;
            string actual = artist.Name;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        [DataRow (16)] //less than 18
        [DataRow (100)] //more than 95
        public void Age_incorrect_input(int age)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => artist.Age = age);
        }

        [TestMethod]
        public void Age_correct_input()
        {
            //Arrange
            int age = 21;
            int expected = age;

            //Act
            artist.Age = age;
            int actual = artist.Age;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow (-20)] //less or equal 0
        [DataRow (0)] //less or equal 0
        public void Salary_incorrect_input(double salary)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => artist.Salary = salary);
        }

        [TestMethod]
        public void Salary_correct_input()
        {
            //Arrange
            double salary = 150000;
            double expected = salary;

            //Act
            artist.Salary = salary;
            double actual = artist.Salary;

            //Assert
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void Instrument_empty_input()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => artist.Instrument = "");
        }

        [TestMethod]
        [DataRow ("a")] //less than 3 symbols
        [DataRow ("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")] //more than 50 symbols
        public void Instrument_incorrect_string_size(string s)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => artist.Instrument = s);
        }

        [TestMethod]
        [DataRow ("@@@")] //special symbols
        [DataRow ("Укулеле")] //cyrillic symbols
        public void Instrument_incorrect_input(string s)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => artist.Instrument = s);
        }

        [TestMethod]
        public void Instrument_correct_input()
        {
            //Arrange
            string instrument = "Electric guitar";
            string expected = instrument;

            //Act
            artist.Instrument = instrument;
            string actual = artist.Instrument;


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow (true)]
        [DataRow (false)]
        public void IsActive(bool isActive)
        {
            //Arrange
            bool expected = isActive;

            //Act
            artist.IsActive = isActive;
            bool actual = artist.IsActive;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(-20)] //less than 0
        public void FanCount_incorrect_input(int count)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => artist.FanCount = count);
        }

        [TestMethod]
        public void FanCount_correct_input()
        {
            //Arrange
            int count = 1500;
            int expected = count;

            //Act
            artist.FanCount = count;
            int actual = artist.FanCount;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
