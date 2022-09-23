using System;
using System.Collections.Generic;

namespace GenChallengeSolution
{
    public class ClassicCar
    {
        public string m_Make;
        public string m_Model;
        public int m_Year;
        public int m_Value;

        public ClassicCar(string make, string model, int year, int val)
        {
            m_Make = make;
            m_Model = model;
            m_Year = year;
            m_Value = val;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<ClassicCar> carList = new List<ClassicCar>();
            populateData(carList);

            // How many cars are in the collection?
            Console.WriteLine("There are {0} cars in the entire collection\n", carList.Count);

            // How many Fords are there?
            List<ClassicCar> fordList = carList.FindAll(IsFord);
            Console.WriteLine("There are {0} Fords in the entire collection\n", fordList.Count);


            // What is the most valuable car?
            ClassicCar mostValCar = null!;
            int highValue = 0;

            foreach (ClassicCar car in carList)
            {
                if (highValue < car.m_Value)
                {
                    mostValCar = car;
                    highValue = car.m_Value;
                }
            }

            Console.WriteLine("The most valuable car is a {0} {1} {2} at ${3}\n",
                mostValCar.m_Year, mostValCar.m_Make, mostValCar.m_Model, mostValCar.m_Value);


            // What is the entire collection worth?
            int totalWorth = 0;
            foreach (ClassicCar car in carList)
                totalWorth += car.m_Value;
            Console.WriteLine("The entire collection is worth ${0}\n", totalWorth);


            // How many unique manufacturers are there?
            Dictionary<string, bool> makes = new();
            foreach (ClassicCar car in carList)
            {
                try
                {
                    makes.Add(car.m_Make, true);
                }
                catch (System.Exception) { }
            }
            Console.WriteLine("The entire collection contains {0} unique manifactures\n", makes.Keys.Count);


            Console.WriteLine("\nHit Enter key to continue...");
            Console.ReadLine();
        }

        static bool IsFord(ClassicCar car)
        {
            return car.m_Make.Equals("Ford");
        }

        static void populateData(List<ClassicCar> theList)
        {
            theList.Add(new ClassicCar("Alfa Romeo", "Spider Veloce", 1965, 15000));
            theList.Add(new ClassicCar("Alfa Romeo", "1750 Berlina", 1970, 20000));
            theList.Add(new ClassicCar("Alfa Romeo", "Giuletta", 1978, 45000));

            theList.Add(new ClassicCar("Ford", "Thunderbird", 1971, 35000));
            theList.Add(new ClassicCar("Ford", "Mustang", 1976, 29800));
            theList.Add(new ClassicCar("Ford", "Corsair", 1970, 17900));
            theList.Add(new ClassicCar("Ford", "LTD", 1969, 12000));

            theList.Add(new ClassicCar("Chevrolet", "Camaro", 1979, 7000));
            theList.Add(new ClassicCar("Chevrolet", "Corvette Stringray", 1966, 21000));
            theList.Add(new ClassicCar("Chevrolet", "Monte Carlo", 1984, 10000));

            theList.Add(new ClassicCar("Mercedes", "300SL Roadster", 1957, 19800));
            theList.Add(new ClassicCar("Mercedes", "SSKL", 1930, 14300));
            theList.Add(new ClassicCar("Mercedes", "130H", 1936, 18400));
            theList.Add(new ClassicCar("Mercedes", "250SL", 1968, 13200));
        }
    }
}