using Project__part_B_;

namespace TestProject
{
    [TestClass]
    public sealed class TestBand
    {
        private Band band;

        //Setup
        [TestInitialize]
        public void Setup()
        {
            band = new Band();
        }

        [TestCleanup]
        public void Cleanup()
        {
            band = null;
        }

        //Public properties
        [TestMethod]
        public void BandName_empty_input()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => band.BandName = "");
        }

        [TestMethod]
        [DataRow("a")] //less than 3 symbols
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")] //more than 50 symbols
        public void BandName_incorrect_input(string s)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => band.BandName = s);
        }

        [TestMethod]
        public void BandName_correct_input()
        {
            //Arrange
            string name = "Nirvana";
            string expected = name;

            //Act
            band.BandName = name;
            string actual = band.BandName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(-20)] //less than 0
        public void MonthlyListening_incorrect_input(int count)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => band.MonthlyListening = count);
        }

        [TestMethod]
        public void MonthlyListening_correct_input()
        {
            //Arrange
            int count = 1500;
            int expected = count;

            //Act
            band.MonthlyListening = count;
            int actual = band.MonthlyListening;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Producers()
        {
            //Arrange
            Producer producer1 = new Producer("Butch Vig", 70, 100000, "Architecture of grunge sound");
            Producer producer2 = new Producer("Butch Viga", 70, 100000, "Architecture of grunge sound");

            List<Producer> producers = new List<Producer>() { producer1, producer2 };
            List<Producer> expected = producers;

            //Act
            band.Producers = producers;
            List<Producer> actual = band.Producers;

            //Assert
            Assert.HasCount(expected.Count, actual);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.IsTrue(Producer.AreEqual(expected[i], actual[i]));
            }
        }

        [TestMethod]
        public void Artists()
        {
            //Arrange
            Artist artist1 = new Artist("Kurt Cobain", 27, 150000, "Electric guitar");
            List<Artist> artists = new List<Artist>() { artist1 };
            List<Artist> expected = artists;

            //Act
            band.Artists = artists;
            List<Artist> actual = band.Artists;

            //Assert
            Assert.HasCount(expected.Count, actual);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.IsTrue(Artist.AreEqual(expected[i], actual[i]));
            }
        }
    }
}