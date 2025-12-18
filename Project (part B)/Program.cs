using Project__part_B_;
using System;
using System.Collections.Generic;

namespace Project__part_B_
{
    class Program
    {
        private static List<RecordLabel> recordLabels = new List<RecordLabel>();
        private static List<Song> songs = new List<Song>();
        private static List<Song> songsPlaying = new List<Song>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            InitializeTestData();

            bool exit = false;
            while (!exit)
            {
                DisplayMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageRecordLabels();
                        break;
                    case "2":
                        ManageBands();
                        break;
                    case "3":
                        ManageArtists();
                        break;
                    case "4":
                        ManageProducers();
                        break;
                    case "5":
                        ManageSongs();
                        break;
                    case "6":
                        ViewStatistics();
                        break;
                    case "7":
                        SearchAndFilter();
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("\nThank you for using Music Industry Management System!");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        static void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     MUSIC INDUSTRY MANAGEMENT SYSTEM - MAIN MENU           ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║  1. Record Label Management                                ║");
            Console.WriteLine("║  2. Band Management                                        ║");
            Console.WriteLine("║  3. Artist Management                                      ║");
            Console.WriteLine("║  4. Producer Management                                    ║");
            Console.WriteLine("║  5. Song Management                                        ║");
            Console.WriteLine("║  6. Statistics & Reports                                   ║");
            Console.WriteLine("║  7. Search & Filter                                        ║");
            Console.WriteLine("║  0. Exit                                                   ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.Write("\nEnter your choice: ");
        }

        #region Record Label Management
        static void ManageRecordLabels()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║            RECORD LABEL MANAGEMENT                         ║");
                Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║  1. Add New Record Label                                   ║");
                Console.WriteLine("║  2. View All Record Labels                                 ║");
                Console.WriteLine("║  3. View Record Label Details                              ║");
                Console.WriteLine("║  4. Delete Record Label                                    ║");
                Console.WriteLine("║  0. Back to Main Menu                                      ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
                Console.Write("\nEnter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddRecordLabel();
                        Console.ReadKey();
                        break;
                    case "2":
                        ViewAllRecordLabels();
                        Console.ReadKey();
                        break;
                    case "3":
                        ViewRecordLabelDetails();
                        Console.ReadKey();
                        break;
                    case "4":
                        DeleteRecordLabel();
                        Console.ReadKey();
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AddRecordLabel()
        {
            Console.Clear();
            Console.WriteLine("=== ADD NEW RECORD LABEL ===\n");

            try
            {
                Console.Write("Enter label name (3-50 characters): ");
                string name = Console.ReadLine();

                RecordLabel label = new RecordLabel(name, new List<Band>());
                recordLabels.Add(label);

                Console.WriteLine($"\n✓ Record label '{name}' added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Error: {ex.Message}");
            }
        }

        static void ViewAllRecordLabels()
        {
            Console.Clear();
            Console.WriteLine("=== ALL RECORD LABELS ===\n");

            if (recordLabels.Count == 0)
            {
                Console.WriteLine("No record labels found.");
            }
            else
            {
                for (int i = 0; i < recordLabels.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {recordLabels[i].RecordLabelName} ({recordLabels[i].Bands.Count} bands)");
                }
            }
        }

        static void ViewRecordLabelDetails()
        {
            Console.Clear();
            Console.WriteLine("=== RECORD LABEL DETAILS ===\n");

            if (recordLabels.Count == 0)
            {
                Console.WriteLine("No record labels found.");
                return;
            }

            ViewAllRecordLabels();
            Console.Write("\nEnter label number: ");

            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= recordLabels.Count)
            {
                RecordLabel label = recordLabels[index - 1];
                Console.WriteLine($"\n--- {label.RecordLabelName} ---");
                Console.WriteLine($"Total Bands: {label.Bands.Count}");
                Console.WriteLine("\nBands:");

                foreach (var band in label.Bands)
                {
                    Console.WriteLine($"  • {band.BandName} ({band.Artists.Count} artists, {band.MonthlyListening:N0} monthly listeners)");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid selection.");
            }
        }

        static void DeleteRecordLabel()
        {
            Console.Clear();
            Console.WriteLine("=== DELETE RECORD LABEL ===\n");

            if (recordLabels.Count == 0)
            {
                Console.WriteLine("No record labels found.");
                return;
            }

            ViewAllRecordLabels();
            Console.Write("\nEnter label number to delete: ");

            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= recordLabels.Count)
            {
                string name = recordLabels[index - 1].RecordLabelName;
                recordLabels.RemoveAt(index - 1);
                Console.WriteLine($"\n✓ Record label '{name}' deleted successfully!");
            }
            else
            {
                Console.WriteLine("\nInvalid selection.");
            }
        }
        #endregion

        #region Band Management
        static void ManageBands()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                 BAND MANAGEMENT                            ║");
                Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║  1. Add Band to Record Label                               ║");
                Console.WriteLine("║  2. View All Bands                                         ║");
                Console.WriteLine("║  3. View Band Details                                      ║");
                Console.WriteLine("║  4. Add Artist to Band                                     ║");
                Console.WriteLine("║  5. Remove Band from Label                                 ║");
                Console.WriteLine("║  0. Back to Main Menu                                      ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
                Console.Write("\nEnter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddBandToLabel();
                        Console.ReadKey();
                        break;
                    case "2":
                        ViewAllBands();
                        Console.ReadKey();
                        break;
                    case "3":
                        ViewBandDetails();
                        Console.ReadKey();
                        break;
                    case "4":
                        AddArtistToBand();
                        Console.ReadKey();
                        break;
                    case "5":
                        RemoveBandFromLabel();
                        Console.ReadKey();
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AddBandToLabel()
        {
            Console.Clear();
            Console.WriteLine("=== ADD BAND TO RECORD LABEL ===\n");

            if (recordLabels.Count == 0)
            {
                Console.WriteLine("No record labels found. Please create a label first.");
                return;
            }

            try
            {
                for (int i = 0; i < recordLabels.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {recordLabels[i].RecordLabelName}");
                }

                Console.Write("\nSelect label number: ");
                if (!int.TryParse(Console.ReadLine(), out int labelIndex) || labelIndex < 1 || labelIndex > recordLabels.Count)
                {
                    Console.WriteLine("\nInvalid label selection.");
                    return;
                }

                Console.Write("Enter band name (3-50 characters): ");
                string bandName = Console.ReadLine();

                Console.Write("Enter monthly listening count: ");
                if (!int.TryParse(Console.ReadLine(), out int monthlyListening) || monthlyListening < 0)
                {
                    Console.WriteLine("\nInvalid listening count.");
                    return;
                }

                List<Producer> producers = new List<Producer>();
                Console.Write("Add producer to band? (y/n): ");
                if (Console.ReadLine()?.ToLower() == "y")
                {
                    producers = SelectProducers();
                }

                Band band = new Band(bandName, monthlyListening, producers);
                recordLabels[labelIndex - 1].SignBand(band);

                Console.WriteLine($"\n✓ Band '{bandName}' added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Error: {ex.Message}");
            }
        }

        static List<Producer> SelectProducers()
        {
            List<Producer> producers = new List<Producer>();
            bool addMore = true;

            while (addMore)
            {
                try
                {
                    Console.WriteLine("\n--- Add Producer ---");
                    Console.Write("Name (3-50 characters): ");
                    string name = Console.ReadLine();

                    Console.Write("Age (20-95): ");
                    int age = int.Parse(Console.ReadLine());

                    Console.Write("Salary (> 0): ");
                    double salary = double.Parse(Console.ReadLine());

                    Console.Write("Years of experience (3-90): ");
                    int experience = int.Parse(Console.ReadLine());

                    Console.Write("Specialization (3-50 characters): ");
                    string specialization = Console.ReadLine();

                    Producer producer = new Producer(name, age, salary, experience, specialization);
                    producers.Add(producer);

                    Console.Write("\nAdd another producer? (y/n): ");
                    addMore = Console.ReadLine()?.ToLower() == "y";
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n✗ Error: {ex.Message}");
                    addMore = false;
                }
            }

            return producers;
        }

        static void ViewAllBands()
        {
            Console.Clear();
            Console.WriteLine("=== ALL BANDS ===\n");

            bool found = false;
            for (int i = 0; i < recordLabels.Count; i++)
            {
                if (recordLabels[i].Bands.Count > 0)
                {
                    Console.WriteLine($"\n{recordLabels[i].RecordLabelName}:");
                    for (int j = 0; j < recordLabels[i].Bands.Count; j++)
                    {
                        Band band = recordLabels[i].Bands[j];
                        Console.WriteLine($"  • {band.BandName} - {band.MonthlyListening:N0} listeners, {band.Artists.Count} artists");
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("No bands found.");
            }
        }

        static List<Band> GetAllBands()
        {
            List<Band> allBands = new List<Band>();
            for (int i = 0; i < recordLabels.Count; i++)
            {
                for (int j = 0; j < recordLabels[i].Bands.Count; j++)
                {
                    allBands.Add(recordLabels[i].Bands[j]);
                }
            }
            return allBands;
        }

        static void ViewBandDetails()
        {
            Console.Clear();
            Console.WriteLine("=== BAND DETAILS ===\n");

            List<Band> allBands = GetAllBands();

            if (allBands.Count == 0)
            {
                Console.WriteLine("No bands found.");
                return;
            }

            for (int i = 0; i < allBands.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allBands[i].BandName}");
            }

            Console.Write("\nSelect band number: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= allBands.Count)
            {
                Band band = allBands[index - 1];
                Console.WriteLine($"\n--- {band.BandName} ---");
                Console.WriteLine($"Monthly Listeners: {band.MonthlyListening:N0}");
                Console.WriteLine($"\nProducers ({band.Producers.Count}):");
                for (int i = 0; i < band.Producers.Count; i++)
                {
                    Console.WriteLine($"  • {band.Producers[i].Name} - {band.Producers[i].Specialization}");
                }

                Console.WriteLine($"\nArtists ({band.Artists.Count}):");
                for (int i = 0; i < band.Artists.Count; i++)
                {
                    Console.WriteLine($"  • {band.Artists[i].Name} - {band.Artists[i].Instrument} ({band.Artists[i].FanCount:N0} fans)");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid selection.");
            }
        }

        static void AddArtistToBand()
        {
            Console.Clear();
            Console.WriteLine("=== ADD ARTIST TO BAND ===\n");

            List<Band> allBands = GetAllBands();

            if (allBands.Count == 0)
            {
                Console.WriteLine("No bands found.");
                return;
            }

            for (int i = 0; i < allBands.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allBands[i].BandName}");
            }

            Console.Write("\nSelect band number: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > allBands.Count)
            {
                Console.WriteLine("\nInvalid selection.");
                return;
            }

            try
            {
                Console.WriteLine("\n--- Add Artist ---");
                Console.Write("Name (3-50 characters): ");
                string name = Console.ReadLine();

                Console.Write("Age (18-95): ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Salary (> 0): ");
                double salary = double.Parse(Console.ReadLine());

                Console.Write("Instrument (3-50 characters, Latin letters/numbers): ");
                string instrument = Console.ReadLine();

                Console.Write("Is active? (true/false): ");
                bool isActive = bool.Parse(Console.ReadLine());

                Console.Write("Fan count (≥ 0): ");
                int fanCount = int.Parse(Console.ReadLine());

                Artist artist = new Artist(name, age, salary, instrument, isActive, fanCount);
                allBands[index - 1].Artists.Add(artist);

                Console.WriteLine($"\n✓ Artist '{name}' added to '{allBands[index - 1].BandName}' successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Error: {ex.Message}");
            }
        }

        static void RemoveBandFromLabel()
        {
            Console.Clear();
            Console.WriteLine("=== REMOVE BAND FROM LABEL ===\n");

            if (recordLabels.Count == 0)
            {
                Console.WriteLine("No record labels found.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < recordLabels.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recordLabels[i].RecordLabelName} ({recordLabels[i].Bands.Count} bands)");
            }

            Console.Write("\nSelect label number: ");
            if (!int.TryParse(Console.ReadLine(), out int labelIndex) || labelIndex < 1 || labelIndex > recordLabels.Count)
            {
                Console.WriteLine("\nInvalid selection.");
                return;
            }

            RecordLabel selectedLabel = recordLabels[labelIndex - 1];
            if (selectedLabel.Bands.Count == 0)
            {
                Console.WriteLine("\nNo bands in this label.");
                return;
            }

            Console.WriteLine($"\nBands in {selectedLabel.RecordLabelName}:");
            for (int i = 0; i < selectedLabel.Bands.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {selectedLabel.Bands[i].BandName}");
            }

            Console.Write("\nSelect band number to remove: ");
            if (int.TryParse(Console.ReadLine(), out int bandIndex) && bandIndex > 0 && bandIndex <= selectedLabel.Bands.Count)
            {
                string bandName = selectedLabel.Bands[bandIndex - 1].BandName;
                selectedLabel.UnsignBand(bandIndex - 1);
                Console.WriteLine($"\n✓ Band '{bandName}' removed successfully!");
            }
            else
            {
                Console.WriteLine("\nInvalid selection.");
            }
        }
        #endregion

        #region Artist Management
        static void ManageArtists()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║               ARTIST MANAGEMENT                            ║");
                Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║  1. View All Artists                                       ║");
                Console.WriteLine("║  2. View Artist Details                                    ║");
                Console.WriteLine("║  3. Update Artist Status                                   ║");
                Console.WriteLine("║  4. Compare Two Artists                                    ║");
                Console.WriteLine("║  0. Back to Main Menu                                      ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
                Console.Write("\nEnter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ViewAllArtists();
                        Console.ReadKey();
                        break;
                    case "2":
                        ViewArtistDetails();
                        Console.ReadKey();
                        break;
                    case "3":
                        UpdateArtistStatus();
                        Console.ReadKey();
                        break;
                    case "4":
                        CompareTwoArtists();
                        Console.ReadKey();
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static List<Artist> GetAllArtists()
        {
            List<Artist> allArtists = new List<Artist>();
            for (int i = 0; i < recordLabels.Count; i++)
            {
                for (int j = 0; j < recordLabels[i].Bands.Count; j++)
                {
                    for (int k = 0; k < recordLabels[i].Bands[j].Artists.Count; k++)
                    {
                        Artist artist = recordLabels[i].Bands[j].Artists[k];
                        bool alreadyAdded = false;
                        for (int a = 0; a < allArtists.Count; a++)
                        {
                            if (Artist.AreEqual(allArtists[a], artist))
                            {
                                alreadyAdded = true;
                                break;
                            }
                        }
                        if (!alreadyAdded)
                        {
                            allArtists.Add(artist);
                        }
                    }
                }
            }
            return allArtists;
        }

        static void SortArtistsByName(List<Artist> artists)
        {
            artists.Sort();
        }

        static void ViewAllArtists()
        {
            Console.Clear();
            Console.WriteLine("=== ALL ARTISTS ===\n");

            List<Artist> allArtists = GetAllArtists();

            if (allArtists.Count == 0)
            {
                Console.WriteLine("No artists found.");
            }
            else
            {
                SortArtistsByName(allArtists);
                for (int i = 0; i < allArtists.Count; i++)
                {
                    string status = allArtists[i].IsActive ? "Active" : "Inactive";
                    Console.WriteLine($"• {allArtists[i].Name} - {allArtists[i].Instrument} - {status} - {allArtists[i].FanCount:N0} fans");
                }
            }
        }

        static void ViewArtistDetails()
        {
            Console.Clear();
            Console.WriteLine("=== ARTIST DETAILS ===\n");

            List<Artist> allArtists = GetAllArtists();

            if (allArtists.Count == 0)
            {
                Console.WriteLine("No artists found.");
                return;
            }

            for (int i = 0; i < allArtists.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allArtists[i].Name}");
            }

            Console.Write("\nSelect artist number: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= allArtists.Count)
            {
                Console.WriteLine($"\n{allArtists[index - 1].GetInfo()}");
            }
            else
            {
                Console.WriteLine("\nInvalid selection.");
            }
        }

        static void UpdateArtistStatus()
        {
            Console.Clear();
            Console.WriteLine("=== UPDATE ARTIST STATUS ===\n");

            List<Artist> allArtists = GetAllArtists();

            if (allArtists.Count == 0)
            {
                Console.WriteLine("No artists found.");
                return;
            }

            for (int i = 0; i < allArtists.Count; i++)
            {
                string status = allArtists[i].IsActive ? "Active" : "Inactive";
                Console.WriteLine($"{i + 1}. {allArtists[i].Name} - {status}");
            }

            Console.Write("\nSelect artist number: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= allArtists.Count)
            {
                Artist artist = allArtists[index - 1];
                artist.IsActive = !artist.IsActive;
                string newStatus = artist.IsActive ? "Active" : "Inactive";
                Console.WriteLine($"\n✓ {artist.Name} status changed to: {newStatus}");
            }
            else
            {
                Console.WriteLine("\nInvalid selection.");
            }
        }

        static void CompareTwoArtists()
        {
            Console.Clear();
            Console.WriteLine("=== COMPARE TWO ARTISTS ===\n");

            List<Artist> allArtists = GetAllArtists();

            if (allArtists.Count < 2)
            {
                Console.WriteLine("Need at least 2 artists to compare.");
                return;
            }

            for (int i = 0; i < allArtists.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allArtists[i].Name}");
            }

            Console.Write("\nSelect first artist number: ");
            if (!int.TryParse(Console.ReadLine(), out int index1) || index1 < 1 || index1 > allArtists.Count)
            {
                Console.WriteLine("\nInvalid selection.");
                return;
            }

            Console.Write("Select second artist number: ");
            if (!int.TryParse(Console.ReadLine(), out int index2) || index2 < 1 || index2 > allArtists.Count)
            {
                Console.WriteLine("\nInvalid selection.");
                return;
            }

            bool areEqual = Artist.AreEqual(allArtists[index1 - 1], allArtists[index2 - 1]);
            string result = areEqual ? "EQUAL" : "NOT EQUAL";
            Console.WriteLine($"\n{allArtists[index1 - 1].Name} and {allArtists[index2 - 1].Name} are {result}");
        }
        #endregion

        #region Producer Management
        static void ManageProducers()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║              PRODUCER MANAGEMENT                           ║");
                Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║  1. View All Producers                                     ║");
                Console.WriteLine("║  2. View Producer Details                                  ║");
                Console.WriteLine("║  3. Compare Two Producers                                  ║");
                Console.WriteLine("║  0. Back to Main Menu                                      ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
                Console.Write("\nEnter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ViewAllProducers();
                        Console.ReadKey();
                        break;
                    case "2":
                        ViewProducerDetails();
                        Console.ReadKey();
                        break;
                    case "3":
                        CompareTwoProducers();
                        Console.ReadKey();
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static List<Producer> GetAllProducers()
        {
            List<Producer> allProducers = new List<Producer>();
            for (int i = 0; i < recordLabels.Count; i++)
            {
                for (int j = 0; j < recordLabels[i].Bands.Count; j++)
                {
                    for (int k = 0; k < recordLabels[i].Bands[j].Producers.Count; k++)
                    {
                        Producer producer = recordLabels[i].Bands[j].Producers[k];
                        bool alreadyAdded = false;
                        for (int p = 0; p < allProducers.Count; p++)
                        {
                            if (Producer.AreEqual(allProducers[p], producer))
                            {
                                alreadyAdded = true;
                                break;
                            }
                        }
                        if (!alreadyAdded)
                        {
                            allProducers.Add(producer);
                        }
                    }
                }
            }
            return allProducers;
        }

        static void SortProducersByName(List<Producer> producers)
        {
            producers.Sort();
        }

        static void ViewAllProducers()
        {
            Console.Clear();
            Console.WriteLine("=== ALL PRODUCERS ===\n");

            List<Producer> allProducers = GetAllProducers();

            if (allProducers.Count == 0)
            {
                Console.WriteLine("No producers found.");
            }
            else
            {
                SortProducersByName(allProducers);
                for (int i = 0; i < allProducers.Count; i++)
                {
                    Console.WriteLine($"• {allProducers[i].Name} - {allProducers[i].Specialization} - {allProducers[i].YearsOfExperience} years exp.");
                }
            }
        }

        static void ViewProducerDetails()
        {
            Console.Clear();
            Console.WriteLine("=== PRODUCER DETAILS ===\n");

            List<Producer> allProducers = GetAllProducers();

            if (allProducers.Count == 0)
            {
                Console.WriteLine("No producers found.");
                return;
            }

            for (int i = 0; i < allProducers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allProducers[i].Name}");
            }

            Console.Write("\nSelect producer number: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= allProducers.Count)
            {
                Console.WriteLine($"\n{allProducers[index - 1].GetInfo()}");
            }
            else
            {
                Console.WriteLine("\nInvalid selection.");
            }
        }

        static void CompareTwoProducers()
        {
            Console.Clear();
            Console.WriteLine("=== COMPARE TWO PRODUCERS ===\n");

            List<Producer> allProducers = GetAllProducers();

            if (allProducers.Count < 2)
            {
                Console.WriteLine("Need at least 2 producers to compare.");
                return;
            }

            for (int i = 0; i < allProducers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allProducers[i].Name}");
            }

            Console.Write("\nSelect first producer number: ");
            if (!int.TryParse(Console.ReadLine(), out int index1) || index1 < 1 || index1 > allProducers.Count)
            {
                Console.WriteLine("\nInvalid selection.");
                return;
            }

            Console.Write("Select second producer number: ");
            if (!int.TryParse(Console.ReadLine(), out int index2) || index2 < 1 || index2 > allProducers.Count)
            {
                Console.WriteLine("\nInvalid selection.");
                return;
            }

            bool areEqual = Producer.AreEqual(allProducers[index1 - 1], allProducers[index2 - 1]);
            string result = areEqual ? "EQUAL" : "NOT EQUAL";
            Console.WriteLine($"\n{allProducers[index1 - 1].Name} and {allProducers[index2 - 1].Name} are {result}");
        }
        #endregion

        #region Song Management
        static void ManageSongs()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                SONG MANAGEMENT                             ║");
                Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║  1. Add New Song                                           ║");
                Console.WriteLine("║  2. View All Songs                                         ║");
                Console.WriteLine("║  3. View Song Details                                      ║");
                Console.WriteLine("║  4. Play Song                                              ║");
                Console.WriteLine("║  5. Stop Song                                              ║");
                Console.WriteLine("║  0. Back to Main Menu                                      ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
                Console.Write("\nEnter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddSong();
                        Console.ReadKey();
                        break;
                    case "2":
                        ViewAllSongs();
                        Console.ReadKey();
                        break;
                    case "3":
                        ViewSongDetails();
                        Console.ReadKey();
                        break;
                    case "4":
                        PlaySong();
                        Console.ReadKey();
                        break;
                    case "5":
                        StopSong();
                        Console.ReadKey();
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AddSong()
        {
            Console.Clear();
            Console.WriteLine("=== ADD NEW SONG ===\n");

            List<Band> allBands = GetAllBands();

            if (allBands.Count == 0)
            {
                Console.WriteLine("No bands found. Please add a band first.");
                return;
            }

            try
            {
                Console.Write("Enter song name (3-50 characters): ");
                string name = Console.ReadLine();

                Console.Write("Enter total plays (≥ 0): ");
                long totalPlays = long.Parse(Console.ReadLine());

                Console.WriteLine("\nAvailable bands:");
                for (int i = 0; i < allBands.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {allBands[i].BandName}");
                }

                Console.Write("\nSelect band number: ");
                int bandIndex = int.Parse(Console.ReadLine());

                if (bandIndex < 1 || bandIndex > allBands.Count)
                {
                    Console.WriteLine("\nInvalid band selection.");
                    return;
                }

                Console.WriteLine("\nAvailable genres:");
                Genre[] genres = (Genre[])Enum.GetValues(typeof(Genre));
                for (int i = 0; i < genres.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {genres[i]}");
                }

                Console.Write("\nSelect genre number: ");
                int genreIndex = int.Parse(Console.ReadLine());

                if (genreIndex < 1 || genreIndex > genres.Length)
                {
                    Console.WriteLine("\nInvalid genre selection.");
                    return;
                }

                Genre selectedGenre = genres[genreIndex - 1];
                Song song = new Song(name, totalPlays, allBands[bandIndex - 1], selectedGenre);
                songs.Add(song);

                Console.WriteLine($"\n✓ Song '{name}' added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Error: {ex.Message}");
            }
        }

        static void SortSongsByName(List<Song> songsList)
        {
            songsList.Sort();
        }

        static void ViewAllSongs()
        {
            Console.Clear();
            Console.WriteLine("=== ALL SONGS ===\n");

            if (songs.Count == 0)
            {
                Console.WriteLine("No songs found.");
            }
            else
            {
                List<Song> sortedSongs = new List<Song>(songs);
                SortSongsByName(sortedSongs);
                for (int i = 0; i < sortedSongs.Count; i++)
                {
                    Console.WriteLine($"• {sortedSongs[i].SongName} - {sortedSongs[i].Band.BandName} - {sortedSongs[i].Genre} - {sortedSongs[i].TotalPlays:N0} plays");
                }
            }
        }

        static void ViewSongDetails()
        {
            Console.Clear();
            Console.WriteLine("=== SONG DETAILS ===\n");

            if (songs.Count == 0)
            {
                Console.WriteLine("No songs found.");
                return;
            }

            for (int i = 0; i < songs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {songs[i].SongName}");
            }

            Console.Write("\nSelect song number: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= songs.Count)
            {
                Console.WriteLine($"\n{songs[index - 1].GetMetadata()}");
            }
            else
            {
                Console.WriteLine("\nInvalid selection.");
            }
        }

        static void PlaySong()
        {
            Console.Clear();
            Console.WriteLine("=== PLAY SONG ===\n");

            if (songs.Count == 0)
            {
                Console.WriteLine("No songs found.");
                return;
            }

            for (int i = 0; i < songs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {songs[i].SongName} - {songs[i].Band.BandName}");
            }

            Console.Write("\nSelect song number: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 0 || index > songs.Count)
            {
                Console.WriteLine("\nInvalid selection.");
            }
            else if (songsPlaying.Contains(songs[index - 1]))
            {
                Console.WriteLine("\nThis song is already playing.");
            }
            else
            {
                Console.WriteLine($"\n{songs[index - 1].Play()}");
                Console.WriteLine($"Total plays: {songs[index - 1].TotalPlays:N0}");
                songsPlaying.Add(songs[index - 1]);
            }
        }

        static void StopSong()
        {
            Console.Clear();
            Console.WriteLine("=== STOP SONG ===\n");

            if (songsPlaying.Count == 0)
            {
                Console.WriteLine("No songs are playing.");
                return;
            }

            for (int i = 0; i < songsPlaying.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {songsPlaying[i].SongName} - {songsPlaying[i].Band.BandName}");
            }

            Console.Write("\nSelect song number: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= songsPlaying.Count)
            {
                Console.WriteLine($"\n{songsPlaying[index - 1].Stop()}");
                songsPlaying.Remove(songsPlaying[index - 1]);
            }
            else
            {
                Console.WriteLine("\nInvalid selection.");
            }
        }
        #endregion

        #region Statistics & Reports
        static void ViewStatistics()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║           STATISTICS & REPORTS                             ║");
                Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║  1. Overall Statistics                                     ║");
                Console.WriteLine("║  2. Top Artists by Fans                                    ║");
                Console.WriteLine("║  3. Top Bands by Listeners                                 ║");
                Console.WriteLine("║  4. Top Songs by Plays                                     ║");
                Console.WriteLine("║  5. Genre Distribution                                     ║");
                Console.WriteLine("║  0. Back to Main Menu                                      ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
                Console.Write("\nEnter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ShowOverallStatistics();
                        Console.ReadKey();
                        break;
                    case "2":
                        ShowTopArtists();
                        Console.ReadKey();
                        break;
                    case "3":
                        ShowTopBands();
                        Console.ReadKey();
                        break;
                    case "4":
                        ShowTopSongs();
                        Console.ReadKey();
                        break;
                    case "5":
                        ShowGenreDistribution();
                        Console.ReadKey();
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ShowOverallStatistics()
        {
            Console.Clear();
            Console.WriteLine("=== OVERALL STATISTICS ===\n");

            int labelCount = recordLabels.Count;
            List<Band> allBands = GetAllBands();
            List<Artist> allArtists = GetAllArtists();
            List<Producer> allProducers = GetAllProducers();
            int songCount = songs.Count;

            Console.WriteLine($"Record Labels: {labelCount}");
            Console.WriteLine($"Bands: {allBands.Count}");
            Console.WriteLine($"Artists: {allArtists.Count}");
            Console.WriteLine($"Producers: {allProducers.Count}");
            Console.WriteLine($"Songs: {songCount}");

            if (allArtists.Count > 0)
            {
                int activeArtists = 0;
                for (int i = 0; i < allArtists.Count; i++)
                {
                    if (allArtists[i].IsActive)
                        activeArtists++;
                }
                double percentage = (double)activeArtists / allArtists.Count * 100;
                Console.WriteLine($"\nActive Artists: {activeArtists} ({percentage:F1}%)");
            }

            if (songCount > 0)
            {
                long totalPlays = 0;
                for (int i = 0; i < songs.Count; i++)
                {
                    totalPlays += songs[i].TotalPlays;
                }
                Console.WriteLine($"\nTotal Song Plays: {totalPlays:N0}");
                Console.WriteLine($"Average Plays per Song: {totalPlays / songCount:N0}");
            }
        }

        static void SortArtistsByFans(List<Artist> artists)
        {
            for (int i = 0; i < artists.Count - 1; i++)
            {
                for (int j = 0; j < artists.Count - i - 1; j++)
                {
                    if (artists[j].FanCount < artists[j + 1].FanCount)
                    {
                        Artist temp = artists[j];
                        artists[j] = artists[j + 1];
                        artists[j + 1] = temp;
                    }
                }
            }
        }

        static void ShowTopArtists()
        {
            Console.Clear();
            Console.WriteLine("=== TOP ARTISTS BY FANS ===\n");

            List<Artist> allArtists = GetAllArtists();

            if (allArtists.Count == 0)
            {
                Console.WriteLine("No artists found.");
            }
            else
            {
                SortArtistsByFans(allArtists);
                int limit = allArtists.Count < 10 ? allArtists.Count : 10;
                for (int i = 0; i < limit; i++)
                {
                    Console.WriteLine($"{i + 1}. {allArtists[i].Name} - {allArtists[i].FanCount:N0} fans - {allArtists[i].Instrument}");
                }
            }
        }

        static void SortBandsByListeners(List<Band> bands)
        {
            for (int i = 0; i < bands.Count - 1; i++)
            {
                for (int j = 0; j < bands.Count - i - 1; j++)
                {
                    if (bands[j].MonthlyListening < bands[j + 1].MonthlyListening)
                    {
                        Band temp = bands[j];
                        bands[j] = bands[j + 1];
                        bands[j + 1] = temp;
                    }
                }
            }
        }

        static void ShowTopBands()
        {
            Console.Clear();
            Console.WriteLine("=== TOP BANDS BY MONTHLY LISTENERS ===\n");

            List<Band> allBands = GetAllBands();

            if (allBands.Count == 0)
            {
                Console.WriteLine("No bands found.");
            }
            else
            {
                SortBandsByListeners(allBands);
                int limit = allBands.Count < 10 ? allBands.Count : 10;
                for (int i = 0; i < limit; i++)
                {
                    Console.WriteLine($"{i + 1}. {allBands[i].BandName} - {allBands[i].MonthlyListening:N0} listeners - {allBands[i].Artists.Count} artists");
                }
            }
        }

        static void SortSongsByPlays(List<Song> songsList)
        {
            for (int i = 0; i < songsList.Count - 1; i++)
            {
                for (int j = 0; j < songsList.Count - i - 1; j++)
                {
                    if (songsList[j].TotalPlays < songsList[j + 1].TotalPlays)
                    {
                        Song temp = songsList[j];
                        songsList[j] = songsList[j + 1];
                        songsList[j + 1] = temp;
                    }
                }
            }
        }

        static void ShowTopSongs()
        {
            Console.Clear();
            Console.WriteLine("=== TOP SONGS BY PLAYS ===\n");

            if (songs.Count == 0)
            {
                Console.WriteLine("No songs found.");
            }
            else
            {
                List<Song> sortedSongs = new List<Song>(songs);
                SortSongsByPlays(sortedSongs);
                int limit = sortedSongs.Count < 10 ? sortedSongs.Count : 10;
                for (int i = 0; i < limit; i++)
                {
                    Console.WriteLine($"{i + 1}. {sortedSongs[i].SongName} - {sortedSongs[i].Band.BandName} - {sortedSongs[i].TotalPlays:N0} plays");
                }
            }
        }

        static void ShowGenreDistribution()
        {
            Console.Clear();
            Console.WriteLine("=== GENRE DISTRIBUTION ===\n");

            if (songs.Count == 0)
            {
                Console.WriteLine("No songs found.");
                return;
            }

            Dictionary<Genre, int> genreCounts = new Dictionary<Genre, int>();

            for (int i = 0; i < songs.Count; i++)
            {
                if (genreCounts.ContainsKey(songs[i].Genre))
                {
                    genreCounts[songs[i].Genre]++;
                }
                else
                {
                    genreCounts[songs[i].Genre] = 1;
                }
            }

            List<KeyValuePair<Genre, int>> genreList = new List<KeyValuePair<Genre, int>>(genreCounts);

            for (int i = 0; i < genreList.Count - 1; i++)
            {
                for (int j = 0; j < genreList.Count - i - 1; j++)
                {
                    if (genreList[j].Value < genreList[j + 1].Value)
                    {
                        KeyValuePair<Genre, int> temp = genreList[j];
                        genreList[j] = genreList[j + 1];
                        genreList[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < genreList.Count; i++)
            {
                double percentage = (double)genreList[i].Value / songs.Count * 100;
                Console.WriteLine($"{genreList[i].Key}: {genreList[i].Value} songs ({percentage:F1}%)");
            }
        }
        #endregion

        #region Search & Filter
        static void SearchAndFilter()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║              SEARCH & FILTER                               ║");
                Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║  1. Search Artists by Name                                 ║");
                Console.WriteLine("║  2. Search Bands by Name                                   ║");
                Console.WriteLine("║  3. Filter Artists by Instrument                           ║");
                Console.WriteLine("║  4. Filter Songs by Genre                                  ║");
                Console.WriteLine("║  5. Filter Active/Inactive Artists                         ║");
                Console.WriteLine("║  0. Back to Main Menu                                      ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
                Console.Write("\nEnter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        SearchArtistsByName();
                        Console.ReadKey();
                        break;
                    case "2":
                        SearchBandsByName();
                        Console.ReadKey();
                        break;
                    case "3":
                        FilterArtistsByInstrument();
                        Console.ReadKey();
                        break;
                    case "4":
                        FilterSongsByGenre();
                        Console.ReadKey();
                        break;
                    case "5":
                        FilterArtistsByStatus();
                        Console.ReadKey();
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void SearchArtistsByName()
        {
            Console.Clear();
            Console.WriteLine("=== SEARCH ARTISTS BY NAME ===\n");

            Console.Write("Enter artist name (partial match): ");
            string searchTerm = Console.ReadLine()?.ToLower() ?? "";

            List<Artist> allArtists = GetAllArtists();
            List<Artist> results = new List<Artist>();

            for (int i = 0; i < allArtists.Count; i++)
            {
                if (allArtists[i].Name.ToLower().Contains(searchTerm))
                {
                    results.Add(allArtists[i]);
                }
            }

            Console.WriteLine($"\nFound {results.Count} artist(s):\n");

            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine($"• {results[i].Name} - {results[i].Instrument} - {results[i].FanCount:N0} fans");
            }
        }

        static void SearchBandsByName()
        {
            Console.Clear();
            Console.WriteLine("=== SEARCH BANDS BY NAME ===\n");

            Console.Write("Enter band name (partial match): ");
            string searchTerm = Console.ReadLine()?.ToLower() ?? "";

            List<Band> allBands = GetAllBands();
            List<Band> results = new List<Band>();

            for (int i = 0; i < allBands.Count; i++)
            {
                if (allBands[i].BandName.ToLower().Contains(searchTerm))
                {
                    results.Add(allBands[i]);
                }
            }

            Console.WriteLine($"\nFound {results.Count} band(s):\n");

            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine($"• {results[i].BandName} - {results[i].MonthlyListening:N0} listeners - {results[i].Artists.Count} artists");
            }
        }

        static void FilterArtistsByInstrument()
        {
            Console.Clear();
            Console.WriteLine("=== FILTER ARTISTS BY INSTRUMENT ===\n");

            Console.Write("Enter instrument: ");
            string instrument = Console.ReadLine()?.ToLower() ?? "";

            List<Artist> allArtists = GetAllArtists();
            List<Artist> results = new List<Artist>();

            for (int i = 0; i < allArtists.Count; i++)
            {
                if (allArtists[i].Instrument.ToLower().Contains(instrument))
                {
                    results.Add(allArtists[i]);
                }
            }

            Console.WriteLine($"\nFound {results.Count} artist(s):\n");

            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine($"• {results[i].Name} - {results[i].Instrument} - {results[i].FanCount:N0} fans");
            }
        }

        static void FilterSongsByGenre()
        {
            Console.Clear();
            Console.WriteLine("=== FILTER SONGS BY GENRE ===\n");

            Console.WriteLine("Available genres:");
            Genre[] genres = (Genre[])Enum.GetValues(typeof(Genre));
            for (int i = 0; i < genres.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {genres[i]}");
            }

            Console.Write("\nSelect genre number: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= genres.Length)
            {
                Genre selectedGenre = genres[index - 1];
                List<Song> results = new List<Song>();

                for (int i = 0; i < songs.Count; i++)
                {
                    if (songs[i].Genre == selectedGenre)
                    {
                        results.Add(songs[i]);
                    }
                }

                Console.WriteLine($"\nFound {results.Count} song(s) in {selectedGenre}:\n");

                for (int i = 0; i < results.Count; i++)
                {
                    Console.WriteLine($"• {results[i].SongName} - {results[i].Band.BandName} - {results[i].TotalPlays:N0} plays");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid selection.");
            }
        }

        static void FilterArtistsByStatus()
        {
            Console.Clear();
            Console.WriteLine("=== FILTER ARTISTS BY STATUS ===\n");

            Console.WriteLine("1. Active Artists");
            Console.WriteLine("2. Inactive Artists");
            Console.Write("\nEnter choice: ");

            string choice = Console.ReadLine();
            bool? filterActive = choice == "1" ? true : choice == "2" ? false : null;

            if (filterActive == null)
            {
                Console.WriteLine("\nInvalid choice.");
                return;
            }

            List<Artist> allArtists = GetAllArtists();
            List<Artist> results = new List<Artist>();

            for (int i = 0; i < allArtists.Count; i++)
            {
                if (allArtists[i].IsActive == filterActive)
                {
                    results.Add(allArtists[i]);
                }
            }

            string statusText = filterActive.Value ? "active" : "inactive";
            Console.WriteLine($"\nFound {results.Count} {statusText} artist(s):\n");

            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine($"• {results[i].Name} - {results[i].Instrument} - {results[i].FanCount:N0} fans");
            }
        }
        #endregion

    }
}
