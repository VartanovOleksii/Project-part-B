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
    }
}
