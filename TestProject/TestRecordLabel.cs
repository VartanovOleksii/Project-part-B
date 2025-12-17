using Project__part_B_;

namespace TestProject
{
    [TestClass]
    public sealed class TestRecordLabel
    {
        private RecordLabel recordLabel;

        //Setup
        [TestInitialize]
        public void Setup()
        {
            recordLabel = new RecordLabel();
        }

        [TestCleanup]
        public void Cleanup()
        {
            recordLabel = null;
        }

        //Public properties
        [TestMethod]
        public void RecordLabelName_empty_input()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => recordLabel.RecordLabelName = "");
        }

        [TestMethod]
        [DataRow("a")] //less than 3 symbols
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")] //more than 50 symbols
        public void RecordLabelName_incorrect_input(string s)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => recordLabel.RecordLabelName = s);
        }

        [TestMethod]
        public void RecordLabelName_correct_input()
        {
            //Arrange
            string name = "Sub Pop";
            string expected = name;

            //Act
            recordLabel.RecordLabelName = name;
            string actual = recordLabel.RecordLabelName;

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

            //Act
            Band band1 = new Band("Nirvana", producers);
            band1.Artists.AddRange(artists);

            List<Band> bands = new List<Band>() { band1 };
            recordLabel.Bands = bands;

            List<Band> expected = bands;
            List<Band> actual = recordLabel.Bands;

            //Assert
            Assert.HasCount(expected.Count, actual);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.HasCount(expected[i].Producers.Count, actual); 
                for (int j = 0; j < expected[i].Producers.Count; j++)
                {
                    Assert.IsTrue(Producer.AreEqual(expected[i].Producers[j], actual[i].Producers[j]));
                }

                Assert.HasCount(expected[i].Artists.Count, actual);
                for (int j = 0; j < expected[i].Artists.Count; j++)
                {
                    Assert.IsTrue(Artist.AreEqual(expected[i].Artists[j], actual[i].Artists[j]));
                }
            }
        }

        //Public methods
        [TestMethod]
        public void SignBand_add_one_band()
        {
            //Arrange
            Producer producer1 = new Producer("Butch Vig", 70, 100000, "Architecture of grunge sound");
            List<Producer> producers = new List<Producer>() { producer1 };

            Artist artist1 = new Artist("Kurt Cobain", 27, 150000, "Electric guitar");
            List<Artist> artists = new List<Artist>() { artist1 };

            //Act
            Band band1 = new Band("Nirvana", producers);
            band1.Artists.AddRange(artists);

            List<Band> bands = new List<Band>() { band1 };
            recordLabel.SignBand(band1);

            List<Band> expected = bands;
            List<Band> actual = recordLabel.Bands;

            //Assert
            Assert.HasCount(expected.Count, actual);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.HasCount(expected[i].Producers.Count, actual);
                for (int j = 0; j < expected[i].Producers.Count; j++)
                {
                    Assert.IsTrue(Producer.AreEqual(expected[i].Producers[j], actual[i].Producers[j]));
                }

                Assert.HasCount(expected[i].Artists.Count, actual);
                for (int j = 0; j < expected[i].Artists.Count; j++)
                {
                    Assert.IsTrue(Artist.AreEqual(expected[i].Artists[j], actual[i].Artists[j]));
                }
            }
        }

        [TestMethod]
        public void SignBand_add_band_collection()
        {
            //Arrange
            Producer producer1 = new Producer("Butch Vig", 70, 100000, "Architecture of grunge sound");
            List<Producer> producers = new List<Producer>() { producer1 };

            Artist artist1 = new Artist("Kurt Cobain", 27, 150000, "Electric guitar");
            List<Artist> artists1 = new List<Artist>() { artist1 };

            Artist artist2 = new Artist("Thurston Moore", 67, 75000, "Guitar");
            List<Artist> artists2 = new List<Artist>() { artist2 };

            //Act
            Band band1 = new Band("Nirvana", producers);
            band1.Artists.AddRange(artists1);

            Band band2 = new Band("Sonic Youth", producers);
            band2.Artists.AddRange(artists2);

            List<Band> bands = new List<Band>() { band1, band2 };
            recordLabel.SignBand(bands);

            List<Band> expected = bands;
            List<Band> actual = recordLabel.Bands;

            //Assert
            Assert.HasCount(expected.Count, actual);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.HasCount(expected[i].Producers.Count, actual[i].Producers);
                for (int j = 0; j < expected[i].Producers.Count; j++)
                {
                    Assert.IsTrue(Producer.AreEqual(expected[i].Producers[j], actual[i].Producers[j]));
                }

                Assert.HasCount(expected[i].Artists.Count, actual[i].Artists);
                for (int j = 0; j < expected[i].Artists.Count; j++)
                {
                    Assert.IsTrue(Artist.AreEqual(expected[i].Artists[j], actual[i].Artists[j]));
                }
            }
        }

        [TestMethod]
        [DataRow(-1)] //less than 0
        [DataRow(20)] //more than current Band counter
        public void UnsignBand_index_incorrect_input(int index)
        {
            //Arrange
            Producer producer1 = new Producer("Butch Vig", 70, 100000, "Architecture of grunge sound");
            List<Producer> producers = new List<Producer>() { producer1 };

            Artist artist1 = new Artist("Kurt Cobain", 27, 150000, "Electric guitar");
            List<Artist> artists1 = new List<Artist>() { artist1 };

            Artist artist2 = new Artist("Thurston Moore", 67, 75000, "Guitar");
            List<Artist> artists2 = new List<Artist>() { artist2 };

            Band band1 = new Band("Nirvana", producers);
            band1.Artists.AddRange(artists1);

            Band band2 = new Band("Sonic Youth", producers);
            band2.Artists.AddRange(artists2);

            List<Band> bands = new List<Band>() { band1, band2 };
            recordLabel.SignBand(bands);

            //Act

            //Assert
            Assert.IsFalse(recordLabel.UnsignBand(index));
        }

        [TestMethod]
        public void UnsignBand_index_correct_input()
        {
            //Arrange
            Producer producer1 = new Producer("Butch Vig", 70, 100000, "Architecture of grunge sound");
            List<Producer> producers = new List<Producer>() { producer1 };

            Artist artist1 = new Artist("Kurt Cobain", 27, 150000, "Electric guitar");
            List<Artist> artists1 = new List<Artist>() { artist1 };

            Artist artist2 = new Artist("Thurston Moore", 67, 75000, "Guitar");
            List<Artist> artists2 = new List<Artist>() { artist2 };

            Band band1 = new Band("Nirvana", producers);
            band1.Artists.AddRange(artists1);

            Band band2 = new Band("Sonic Youth", producers);
            band2.Artists.AddRange(artists2);

            List<Band> bands = new List<Band>() { band1, band2 };
            recordLabel.SignBand(bands);

            List<Band> expected = new List<Band>() { band2 };

            //Act
            recordLabel.UnsignBand(0);
            List<Band> actual = recordLabel.Bands;


            //Assert
            Assert.HasCount(expected.Count, actual);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.HasCount(expected[i].Producers.Count, actual);
                for (int j = 0; j < expected[i].Producers.Count; j++)
                {
                    Assert.AreEqual(expected[i].Producers[j].Name, actual[i].Producers[j].Name);
                    Assert.AreEqual(expected[i].Producers[j].Age, actual[i].Producers[j].Age);
                    Assert.AreEqual(expected[i].Producers[j].Salary, actual[i].Producers[j].Salary);
                    Assert.AreEqual(expected[i].Producers[j].YearsOfExperience, actual[i].Producers[j].YearsOfExperience);
                    Assert.AreEqual(expected[i].Producers[j].Specialization, actual[i].Producers[j].Specialization);
                }

                Assert.HasCount(expected[i].Artists.Count, actual);
                for (int j = 0; j < expected[i].Artists.Count; j++)
                {
                    Assert.AreEqual(expected[i].Artists[j].Name, actual[i].Artists[j].Name);
                    Assert.AreEqual(expected[i].Artists[j].Age, actual[i].Artists[j].Age);
                    Assert.AreEqual(expected[i].Artists[j].Salary, actual[i].Artists[j].Salary);
                    Assert.AreEqual(expected[i].Artists[j].Instrument, actual[i].Artists[j].Instrument);
                    Assert.AreEqual(expected[i].Artists[j].IsActive, actual[i].Artists[j].IsActive);
                    Assert.AreEqual(expected[i].Artists[j].FanCount, actual[i].Artists[j].FanCount);
                }
            }
        }

        [TestMethod]
        public void UnsignBand_name_empty_input()
        {
            //Arrange
            string name = ""; 

            Producer producer1 = new Producer("Butch Vig", 70, 100000, "Architecture of grunge sound");
            List<Producer> producers = new List<Producer>() { producer1 };

            Artist artist1 = new Artist("Kurt Cobain", 27, 150000, "Electric guitar");
            List<Artist> artists1 = new List<Artist>() { artist1 };

            Artist artist2 = new Artist("Thurston Moore", 67, 75000, "Guitar");
            List<Artist> artists2 = new List<Artist>() { artist2 };

            Band band1 = new Band("Nirvana", producers);
            band1.Artists.AddRange(artists1);

            Band band2 = new Band("Sonic Youth", producers);
            band2.Artists.AddRange(artists2);

            List<Band> bands = new List<Band>() { band1, band2 };
            recordLabel.SignBand(bands);

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => recordLabel.UnsignBand(name));
        }

        [TestMethod]
        [DataRow("a")] //less than 3 symbols
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")] //more than 50 symbols
        public void UnsignBand_name_incorrect_input()
        {
            //Arrange
            string name = "";

            Producer producer1 = new Producer("Butch Vig", 70, 100000, "Architecture of grunge sound");
            List<Producer> producers = new List<Producer>() { producer1 };

            Artist artist1 = new Artist("Kurt Cobain", 27, 150000, "Electric guitar");
            List<Artist> artists1 = new List<Artist>() { artist1 };

            Artist artist2 = new Artist("Thurston Moore", 67, 75000, "Guitar");
            List<Artist> artists2 = new List<Artist>() { artist2 };

            Band band1 = new Band("Nirvana", producers);
            band1.Artists.AddRange(artists1);

            Band band2 = new Band("Sonic Youth", producers);
            band2.Artists.AddRange(artists2);

            List<Band> bands = new List<Band>() { band1, band2 };
            recordLabel.SignBand(bands);

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => recordLabel.UnsignBand(name));
        }

        [TestMethod]
        [DataRow("Rolling Stones", false)]
        [DataRow("Sonic Youth", true)]
        public void UnsignBand_name_correct_input(string name, bool expectedRes)
        {
            //Arrange
            Producer producer1 = new Producer("Butch Vig", 70, 100000, "Architecture of grunge sound");
            List<Producer> producers = new List<Producer>() { producer1 };

            Artist artist1 = new Artist("Kurt Cobain", 27, 150000, "Electric guitar");
            List<Artist> artists1 = new List<Artist>() { artist1 };

            Artist artist2 = new Artist("Thurston Moore", 67, 75000, "Guitar");
            List<Artist> artists2 = new List<Artist>() { artist2 };

            Band band1 = new Band("Nirvana", producers);
            band1.Artists.AddRange(artists1);

            Band band2 = new Band("Sonic Youth", producers);
            band2.Artists.AddRange(artists2);

            List<Band> bands = new List<Band>() { band1, band2 };
            recordLabel.SignBand(bands);
            List<Band> expected = null;

            if (expectedRes)
            {
                expected = new List<Band>() { band1 };
            }
            else
            {
                expected = bands;
            }

            //Act
            bool actualRes = recordLabel.UnsignBand(name);
            List<Band> actual = recordLabel.Bands;
            

            //Assert
            Assert.AreEqual(expectedRes, actualRes);
            Assert.HasCount(expected.Count, actual);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.HasCount(expected[i].Producers.Count, actual);
                for (int j = 0; j < expected[i].Producers.Count; j++)
                {
                    Assert.AreEqual(expected[i].Producers[j].Name, actual[i].Producers[j].Name);
                    Assert.AreEqual(expected[i].Producers[j].Age, actual[i].Producers[j].Age);
                    Assert.AreEqual(expected[i].Producers[j].Salary, actual[i].Producers[j].Salary);
                    Assert.AreEqual(expected[i].Producers[j].YearsOfExperience, actual[i].Producers[j].YearsOfExperience);
                    Assert.AreEqual(expected[i].Producers[j].Specialization, actual[i].Producers[j].Specialization);
                }

                Assert.HasCount(expected[i].Artists.Count, actual);
                for (int j = 0; j < expected[i].Artists.Count; j++)
                {
                    Assert.AreEqual(expected[i].Artists[j].Name, actual[i].Artists[j].Name);
                    Assert.AreEqual(expected[i].Artists[j].Age, actual[i].Artists[j].Age);
                    Assert.AreEqual(expected[i].Artists[j].Salary, actual[i].Artists[j].Salary);
                    Assert.AreEqual(expected[i].Artists[j].Instrument, actual[i].Artists[j].Instrument);
                    Assert.AreEqual(expected[i].Artists[j].IsActive, actual[i].Artists[j].IsActive);
                    Assert.AreEqual(expected[i].Artists[j].FanCount, actual[i].Artists[j].FanCount);
                }
            }
        }
    }
}