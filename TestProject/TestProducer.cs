using Project__part_B_;

namespace TestProject
{
    [TestClass]
    public sealed class TestProducer
    {
        private Producer producer;

        //Setup
        [TestInitialize]
        public void Setup()
        {
            producer = new Producer();
        }

        [TestCleanup]
        public void Cleanup()
        {
            producer = null;
        }

        //Public properties
        [TestMethod]
        public void Name_empty_input()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => producer.Name = "");
        }

        [TestMethod]
        [DataRow("a")] //less than 3 symbols
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")] //more than 50 symbols
        public void Name_incorrect_input(string s)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => producer.Name = s);
        }

        [TestMethod]
        public void Name_correct_input()
        {
            //Arrange
            string name = "Butch Vig";
            string expected = name;

            //Act
            producer.Name = name;
            string actual = producer.Name;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(19)] //less than 20
        [DataRow(100)] //more than 95
        public void Age_incorrect_input(int age)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => producer.Age = age);
        }

        [TestMethod]
        public void Age_correct_input()
        {
            //Arrange
            int age = 70;
            int expected = age;

            //Act
            producer.Age = age;
            int actual = producer.Age;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(-20)] //less or equal 0
        [DataRow(0)] //less or equal 0
        public void Salary_incorrect_input(double salary)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => producer.Salary = salary);
        }

        [TestMethod]
        public void Salary_correct_input()
        {
            //Arrange
            double salary = 150000;
            double expected = salary;

            //Act
            producer.Salary = salary;
            double actual = producer.Salary;

            //Assert
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        [DataRow (2)] //less than 3
        [DataRow (95)] //more than 90
        public void YearsOfExperience_incorrect_input(int years)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => producer.YearsOfExperience = years);
        }

        [TestMethod]
        public void YearsOfExperience_correct_input()
        {
            //Arrange
            int years = 25;
            int expected = years;

            //Act
            producer.YearsOfExperience = years;
            int actual = producer.YearsOfExperience;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Specialization_empty_input()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => producer.Specialization = "");
        }

        [TestMethod]
        [DataRow("a")] //less than 3 symbols
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")] //more than 50 symbols
        public void Specialization_incorrect_input(string s)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => producer.Specialization = s);
        }

        [TestMethod]
        public void Specialization_correct_input()
        {
            //Arrange
            string specialization = "Architecture of grunge sound";
            string expected = specialization;

            //Act
            producer.Specialization = specialization;
            string actual = producer.Specialization;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //Public methods
        [TestMethod]
        public void GetInfo_null_values()
        {
            //Arrange
            string expected = $"Name: Alan\n" +
                              $"Age: 25\n" +
                              $"Salary: 0,01$\n" +
                              $"Years of experience: 3\n" +
                              $"Specialization: Writing lyrics";

            //Act
            string actual = producer.GetInfo();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetInfo_full_values()
        {
            //Arrange
            Producer producer1 = new Producer("Butch Vig", 70, 100000, 30, "Architecture of grunge sound");

            string expected = $"Name: Butch Vig\n" +
                              $"Age: 70\n" +
                              $"Salary: 100000$\n" +
                              $"Years of experience: 30\n" +
                              $"Specialization: Architecture of grunge sound";

            //Act
            string actual = producer1.GetInfo();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AreEqual_not_equal()
        {
            //Arrange
            Producer producer1 = new Producer("Butch Vig", 70, 100000, 30, "Architecture of grunge sound");
            Producer producer2 = new Producer("Butch Vigaa", 70, 100000, 30, "Architecture of grunge sound");
            bool expected = false;

            //Act
            bool actual = Producer.AreEqual(producer1, producer2);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AreEqual_are_equal()
        {
            //Arrange
            Producer producer1 = new Producer("Butch Vig", 70, 100000, 30, "Architecture of grunge sound");
            Producer producer2 = new Producer("Butch Vig", 70, 100000, 30, "Architecture of grunge sound");
            bool expected = true;

            //Act
            bool actual = Producer.AreEqual(producer1, producer2);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}