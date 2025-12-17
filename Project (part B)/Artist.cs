using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Project__part_B_
{
    public class Artist: Person
    {
        //Private properties
        private string _name;
        private int _age;
        private double _salary;
        private string _instrument;
        private bool _isActive;
        private int _fanCount;

        public static string DefInstrument = "Guitar";
        public static bool DefIsActive = false;
        public static int DefFanCount = 0;
        
        //Public properties
        public override string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Enter name.");
                
                if (value.Length < 3 || value.Length > 50)
                    throw new ArgumentOutOfRangeException("Name have to be between 3 and 50 characters.");

                _name = value;
            }
        }
        public override int Age
        {
            get => _age;
            set
            {
                if (value < 18 || value > 95)
                    throw new ArgumentOutOfRangeException("Age have to be between 18 and 95 years.");

                _age = value;
            }
        }

        public override double Salary
        {
            get => _salary;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Salary have to be more than zero.");

                _salary = value;
            }
        }

        public string Instrument
        {
            get => _instrument;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Enter instrument.");

                if (value.Length < 3 || value.Length > 50)
                    throw new ArgumentOutOfRangeException("Instrument name have to be between 3 and 50 characters.");

                if (!Regex.IsMatch(value, @"^[a-zA-Z0-9\s]+$"))
                    throw new ArgumentException("Instrument name have to contain only latin letters or numbers.");

                _instrument = value;
            }
        }
        public bool IsActive { get; set; }
        public int FanCount
        {
            get => _fanCount;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Fan count have to be more than zero");

                _fanCount = value;
            }
        }

        //Public methods
        public override string GetInfo()
        {
            string info = string.Empty;

            info += $"Name: {Name}\n" +
                    $"Age: {Age}\n" +
                    $"Salary: {Salary}$\n" +
                    $"Instrument: {Instrument}\n" +
                    $"Is active: {IsActive}\n" +
                    $"Amount of fans: {FanCount}";

            return info;
        }

        public bool AreEqual(Artist? artist1, Artist? artist2)
        {
            bool areEqual;

            areEqual = (artist1.Name == artist2.Name) && 
                       (artist1.Age == artist2.Age) && 
                       (artist1.Salary == artist2.Salary) &&
                       (artist1.Instrument == artist2.Instrument) &&
                       (artist1.IsActive == artist2.IsActive) &&
                       (artist1.FanCount == artist2.FanCount);

            return areEqual;
        }

        //Constructors
        public Artist() : this(Person.DefName, Person.DefAge, Person.DefSalary, DefInstrument, DefIsActive, DefFanCount)
        {
        }

        public Artist(string name, int age, double salary, string instrument) : this (name, age, salary, instrument, DefIsActive, DefFanCount)
        {
        }

        public Artist(string name, int age, double salary, string instrument, bool isActive, int fanCount)
        {
            Name = name;
            Age = age;
            Salary = salary;
            Instrument = instrument;
            IsActive = isActive;
            FanCount = fanCount;
        }
    }
}
