using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> persons = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int firstIndex = input.IndexOf('@');
                int secondIndex = input.IndexOf('|');
                int thirdIndex = input.IndexOf('#');
                int fourthIndex = input.IndexOf('*');
                string name = input.Substring(firstIndex + 1, secondIndex - firstIndex - 1);
                int age = int.Parse(input.Substring(thirdIndex + 1, fourthIndex - thirdIndex - 1));
                persons.Add(name, age);

            }

            foreach (var item in persons)
            {
                Console.WriteLine($"{item.Key} is {item.Value} years old.");
            }
           
        }
    }
}
