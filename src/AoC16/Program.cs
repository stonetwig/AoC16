using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC16
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, AdventSetup> dayToClass = new Dictionary<string, AdventSetup>();
            string s;

            dayToClass.Add("1", new One());
            dayToClass.Add("2", new Two());
            dayToClass.Add("3", new Three());
            dayToClass.Add("4", new Four());

            Console.WriteLine("Welcome to Markus Stenqvists (stonetwig) Advent of Code solutions for 2016!");
            do
            {
                Console.WriteLine("Write a number from 1-25 for the day you want the solution for (or q for exit)!");
                s = Console.ReadLine();
                if (dayToClass.ContainsKey(s))
                {
                    var chosenDay = dayToClass[s];
                    chosenDay.Input = chosenDay.GetInput(s);
                    Console.WriteLine("Final code (day " + s + ", part 1): " + chosenDay.RunFirst());
                    Console.WriteLine("Final code (day " + s + ", part 2): " + chosenDay.RunSecond());
                }
            } while (s.ToLower() != "q");
        }
    }
}
