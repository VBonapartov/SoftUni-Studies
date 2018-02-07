namespace _03.WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string wordsFileName = @"test\words.txt";
            string textFileName = @"test\text.txt";
            string resultFileName = @"test\result.txt";

            List<string> words = GetWordsFromFile(wordsFileName).Distinct().ToList();

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            for (int i = 0; i < words.Count; i++)
            {
                wordsCount.Add(words[i], 0);
            }

            wordsCount = CountWordContainsInFile(wordsCount, textFileName);
            SaveResultInFile(wordsCount, resultFileName);
        }

        private static List<string> GetWordsFromFile(string fileName)
        {
            List<string> words = new List<string>();

            if (File.Exists(fileName))
            {
                string line = string.Empty;
                using (StreamReader reader = File.OpenText(fileName))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        words.AddRange(line.Split(new string[] { " ", "-", ".", ",", "!", "?", ":", ";" }, StringSplitOptions.RemoveEmptyEntries).ToList());
                    }
                }
            }
            else
            {
                Console.WriteLine($"File {fileName} not found!");
            }

            return words;
        }

        private static Dictionary<string, int> CountWordContainsInFile(Dictionary<string, int> wordsCount, string textFileName)
        {
            List<string> wordsInTextFile = GetWordsFromFile(textFileName);

            wordsCount = wordsCount
                                .Select(wk =>
                                             new {
                                                 key = wk.Key,
                                                 value = wordsInTextFile
                                                                    .Where(w => w.Equals(wk.Key, StringComparison.InvariantCultureIgnoreCase))
                                                                    .Count()
                                             }
                                       )
                                .ToDictionary(w => w.key, w => w.value)
                                .OrderByDescending(w => w.Value)
                                .ToDictionary(w => w.Key, w => w.Value);

            return wordsCount;
        }

        private static void SaveResultInFile(Dictionary<string, int> wordsCount, string fileName)
        {
            if (wordsCount.Count == 0)
                return;

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (FileStream target = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(target))
                {
                    foreach (KeyValuePair<string, int> word in wordsCount)
                    {
                        writer.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }

            Console.WriteLine($"The result was saved in file \"{fileName}\"");
        }
    }
}
