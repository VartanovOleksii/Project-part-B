using System.Threading.Tasks.Sources;
using Project__part_B_;

namespace TestProject
{
    [TestClass]
    public sealed class TestSong
    {
        private Song song;

        //Setup
        [TestInitialize]
        public void Setup()
        {
            song = new Song();
        }

        [TestCleanup]
        public void Cleanup()
        {
            song = null;
        }

        //Public properties
        [TestMethod]
        public void SongName_empty_input()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => song.SongName = "");
        }

        [TestMethod]
        [DataRow("a")] //less than 3 symbols
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")] //more than 50 symbols
        public void SongName_incorrect_input(string s)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => song.SongName = s);
        }

        [TestMethod]
        public void SongName_correct_input()
        {
            //Arrange
            string name = "Come as you are";
            string expected = name;

            //Act
            song.SongName = name;
            string actual = song.SongName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(-20)] //less than 0
        public void TotalPlays_incorrect_input(long count)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => song.TotalPlays = count);
        }

        [TestMethod]
        public void TotalPlays_correct_input()
        {
            //Arrange
            int count = 1500;
            int expected = count;

            //Act
            song.TotalPlays = count;
            long actual = song.TotalPlays;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Bands()
        {
            //Arrange
            Producer producer1 = new Producer("Butch Vig", 70, 100000, "Architecture of grunge sound");
            List<Producer> producers = new List<Producer>() { producer1 };

            Artist artist1 = new Artist("Kurt Cobain", 27, 150000, "Electric guitar");
            List<Artist> artists = new List<Artist>() { artist1 };

            Band band1 = new Band("Nirvana", producers);
            band1.Artists.AddRange(artists);

            //Act
            song.Band = band1;

            Band expected = band1;
            Band actual = song.Band;

            //Assert
            for (int i = 0; i < expected.Producers.Count; i++)
            {
                Assert.AreEqual(expected.Producers[i].Name, actual.Producers[i].Name);
                Assert.AreEqual(expected.Producers[i].Age, actual.Producers[i].Age);
                Assert.AreEqual(expected.Producers[i].Salary, actual.Producers[i].Salary);
                Assert.AreEqual(expected.Producers[i].YearsOfExperience, actual.Producers[i].YearsOfExperience);
                Assert.AreEqual(expected.Producers[i].Specialization, actual.Producers[i].Specialization);
            }

            
            for (int j = 0; j < expected.Artists.Count; j++)
            {
                Assert.AreEqual(expected.Artists[j].Name, actual.Artists[j].Name);
                Assert.AreEqual(expected.Artists[j].Age, actual.Artists[j].Age);
                Assert.AreEqual(expected.Artists[j].Salary, actual.Artists[j].Salary);
                Assert.AreEqual(expected.Artists[j].Instrument, actual.Artists[j].Instrument);
                Assert.AreEqual(expected.Artists[j].IsActive, actual.Artists[j].IsActive);
                Assert.AreEqual(expected.Artists[j].FanCount, actual.Artists[j].FanCount);
            }
        }

        //Public methods
        [TestMethod]
        public void Play()
        {
            //Arrange
            int count = 10;
            song.TotalPlays = count;
            song.SongName = "Come as you are";

            //Act
            string actualRes = song.Play();
            long actual = song.TotalPlays;

            string expectedRes = $"Now is playing: {song.SongName}";
            int expected = count + 1;


            //Assert
            Assert.AreEqual(expectedRes, actualRes);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Stop()
        {
            //Arrange
            song.SongName = "Come as you are";

            //Act
            string actual = song.Stop();

            string expected = $"On pause: {song.SongName}";

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMetadata()
        {
            //Arrange
            Producer producer1 = new Producer("Butch Vig", 70, 100000, "Architecture of grunge sound");
            List<Producer> producers = new List<Producer>() { producer1 };

            Artist artist1 = new Artist("Kurt Cobain", 27, 150000, "Electric guitar");
            List<Artist> artists = new List<Artist>() { artist1 };

            Band band1 = new Band("Nirvana", producers);
            band1.Artists.AddRange(artists);

            song.SongName = "Come as you are";
            song.Band = band1;
            song.Genre = Genre.Rock;
            song.TotalPlays = 1800000000;

            //Act
            string actual = song.GetMetadata();
            string expected =
                "Name: Come as you are\n" +
                "Author: Nirvana\n" +
                "Genre: Rock\n" +
                "Total plays: 1800000000";

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}