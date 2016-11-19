using System;

namespace StatePattern
{
    //context
    public class Employee
    {
        public Position _developer { get; set; }
        public string _name { get; set; }

        public Employee(string name)
        {
            _name = name;
            _developer = new JuniorDeveloper();
        }

        // calculation of salaries
        public void CalculateSalaray(int overtime)
        {
            _developer.CalculateSalaray(this, overtime);
        }

        // promotion
        public void Promote()
        {
            _developer.Promote(this);
        }
    }
    //state
    public interface Position
    {
        void CalculateSalaray(Employee dev, int overtime);

        void Promote(Employee dev);
    }
    ////ConcreteState
    public class JuniorDeveloper : Position
    {
        int salary = 7000;
        public void CalculateSalaray(Employee dev, int overtime)
        {
            var result = 50 * overtime;
            var summarySalary = salary + result;
            Console.WriteLine(dev._name + "- current salary : " + summarySalary + " with " + overtime + " overtime");
        }

        public void Promote(Employee dev)
        {
            dev._developer = new SeniorDeveloper();
            Console.WriteLine(dev._name + " promoted to senior");
        }
    }
    ////ConcreteState
    public class SeniorDeveloper : Position
    {
        int salary = 15000;

        public void CalculateSalaray(Employee dev, int overtime)
        {
            var result = 150 * overtime;
            var summarySalary = salary + result;
            Console.WriteLine(dev._name + "- current salary : " + summarySalary + " with " + overtime + " overtime");
        }

        public void Promote(Employee dev)
        {
            dev._developer = new ExperDeveloper();
            Console.WriteLine(dev._name + " promoted to expert");
        }
    }
    ////ConcreteState
    public class ExperDeveloper : Position
    {
        int salary = 90000;

        public void CalculateSalaray(Employee dev, int overtime)
        {
            var result = 600 * overtime;
            var summarySalary = salary + result;
            Console.WriteLine(dev._name + "- current salary : " + summarySalary + " with " + overtime + " overtime");
        }

        public void Promote(Employee dev)
        {
            Console.WriteLine(dev._name + " can't advance");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee john = new Employee("Tom");
            Employee katie = new Employee("Jessica");

            john.CalculateSalaray(20);
            katie.CalculateSalaray(12);

            Console.ReadKey();

            Console.WriteLine("\nJessica promotion");
            katie.Promote();
            john.CalculateSalaray(20);
            katie.CalculateSalaray(12);

            Console.ReadKey();

            Console.WriteLine("\nTom promotion");
            john.Promote();
            john.CalculateSalaray(20);
            katie.CalculateSalaray(12);

            Console.ReadKey();

            Console.WriteLine("\nTom promotion");
            john.Promote();
            john.CalculateSalaray(20);
            katie.CalculateSalaray(12);

            Console.ReadKey();

            Console.WriteLine("\nTom promotion");
            john.Promote();
            john.CalculateSalaray(20);
            katie.CalculateSalaray(12);

            Console.ReadKey();
        }
    }
}


