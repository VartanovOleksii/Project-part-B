using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace Project__part_B_
{
    public class Producer: Person
    {
        //Public static properties
        public static int DefYearsOfExperience = 3;
        public static string DefSpecialization = "Writing lyrics";

        //Private properties
        private string _name;
        private int _age;
        private double _salary;
        private int _yearsOfExperience;
        private string _specialization;

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
                if (value < 20 || value > 95)
                    throw new ArgumentOutOfRangeException("Age have to be between 20 and 95 years.");

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

        public int YearsOfExperience
        {
            get => _yearsOfExperience;
            set
            {
                if (value < 3 || value > 90)
                    throw new ArgumentOutOfRangeException("Years of experience have to be between 3 and 90 years.");

                _yearsOfExperience = value;
            }
        }

        public string Specialization
        {
            get => _specialization;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Enter specialization.");

                if (value.Length < 3 || value.Length > 50)
                    throw new ArgumentOutOfRangeException("Specialization value have to be between 3 and 50 characters.");

                _specialization = value;
            }
        }

        //Public methods
        public override string GetInfo()
        {
            string info = string.Empty;

            info += $"Name: {Name}\n" +
                    $"Age: {Age}\n" +
                    $"Salary: {Salary}$\n" +
                    $"Years of experience: {YearsOfExperience}\n" +
                    $"Specialization: {Specialization}";

            return info;
        }

        //Constructors
        public Producer() : this(Person.DefName, Person.DefAge, Person.DefSalary, DefYearsOfExperience, DefSpecialization)
        {
        }

        public Producer(string name, int age, double salary, string specialization) : this(name, age, salary, DefYearsOfExperience, specialization)
        {
        }

        public Producer(string name, int age, double salary, int yearsOfExperience, string specialization)
        {
            Name = name;
            Age = age;
            Salary = salary;
            YearsOfExperience = yearsOfExperience;
            Specialization = specialization;
        }
    }
}
