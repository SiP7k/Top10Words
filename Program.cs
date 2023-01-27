using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Top10Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("C:\\Users\\cavva\\OneDrive\\Рабочий стол\\Text1.txt");
            char[] delimiters = new char[] { ' ', '\r', '\n', '.', ',', '–', '?', '!' };
            string[] splitedText = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            List<string> lines = new List<string>();
            lines.AddRange(splitedText);
            Dictionary<string, int> words = new Dictionary<string, int>();

            for (int i = 0; i < lines.Count; i++)
            {
                words.TryAdd(lines[i], 0);
                words[lines[i]]++;
            }

            var sortedDict = words.OrderByDescending(word => word.Value).ToDictionary(word => word.Key, word => word.Value);

            Console.WriteLine("Top-10 слов в тексте:");
            Console.WriteLine();
            int top10Counter = 10;

            foreach (var word in sortedDict)
            {
                Console.WriteLine(word.Key + " - " + word.Value);
                top10Counter--;
                if (top10Counter == 0)
                    break;
            }
        }
    }
}