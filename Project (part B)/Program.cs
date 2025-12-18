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
    }
}
