using Project__part_B_;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Project__part_B_
{
    public abstract class Person: IPerson, IComparable<Person>
    {
        public static string DefName = "Alan";
        public static int DefAge = 25;
        public static double DefSalary = 0.01;
        
        public abstract string Name { get; set; }
        public abstract int Age { get; set; }
        public abstract double Salary { get; set; }

        public int CompareTo(Person? other)
        {
            if (other == null)
                throw new ArgumentNullException("Incorrect value.");
            return Name.CompareTo(other.Name);
        }

        public virtual string GetInfo()
        {
            string info = string.Empty;

            info += $"Name: {Name}\n" +
                    $"Age: {Age}\n" +
                    $"Salary: {Salary}$";

            return info;
        }
    }
}
