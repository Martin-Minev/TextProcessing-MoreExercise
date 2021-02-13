using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string pattern = @"&(.+)&.*?<(.+)>";
            Regex regex = new Regex(pattern);

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "find")
                {
                    break;
                }

                string decriptText = DecriptingInput(input, key);

                if (regex.IsMatch(decriptText))
                {
                    Match matchTreasure = regex.Match(decriptText);
                    string tresuare = matchTreasure.Groups[1].Value;
                    string coordinates = matchTreasure.Groups[2].Value;

                    Console.WriteLine($"Found {tresuare} at {coordinates}");
                }
            }
        }

        private static string DecriptingInput(string input, int[] key)
        {
            List<string> listOfText = DivideStringAndReturnCollection(input, key.Length);
            List<string> listOfDecriptText = DecriptListOfText(listOfText, key);

            string decriptText = string.Join("", listOfDecriptText);
            return decriptText;
        }

        private static List<string> DecriptListOfText(List<string> listOfText, int[] key)
        {
            List<string> listOfDecriptText = new List<string>();

            for (int i = 0; i < listOfText.Count; i++)
            {
                string currentString = listOfText[i];
                string newString = string.Empty;
                for (int j = 0; j < currentString.Length; j++)
                {
                    char oldCharacter = currentString[j];
                    int newCharInInt = oldCharacter - key[j];
                    char newCharacter = (char)newCharInInt;
                    newString += newCharacter;
                }
                listOfDecriptText.Add(newString);
            }

            return listOfDecriptText;
        }

        private static List<string> DivideStringAndReturnCollection(string input, int lenghtOfKey)
        {
            List<string> listOfText = new List<string>();
            int part = input.Length / lenghtOfKey;
            int residue = 0;
            if (input.Length % lenghtOfKey != 0)
            {
                residue = input.Length % lenghtOfKey;
            }

            int currentIndex = 0;
            for (int i = 1; i <= part; i++)
            {
                string currentString = input.Substring(currentIndex, lenghtOfKey);
                listOfText.Add(currentString);
                currentIndex += lenghtOfKey;
            }

            if (residue != 0)
            {
                string currentString = input.Substring(currentIndex);
                listOfText.Add(currentString);
            }

            return listOfText;
        }
    }
}