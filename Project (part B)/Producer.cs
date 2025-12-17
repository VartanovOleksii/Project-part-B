using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace Project__part_B_
{
    public class Producer: Person
    {
        //Public properties
        public override string Name { get; set; }
        public override int Age { get; set; }
        public override double Salary { get; set; }

        public int YearsOfExperience { get; set; }
        public string Specialization { get; set; }

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
        public Producer()
        {
            throw new NotImplementedException();
        }

        public Producer(string name, int age, double salary, string specialization)
        {
            throw new NotImplementedException();

            Name = name;
            Age = age;
            Salary = salary;
            Specialization = specialization;
        }
    }
}
