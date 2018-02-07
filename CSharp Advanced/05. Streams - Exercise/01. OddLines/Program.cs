namespace _01.OddLines
{
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Choose a file path: ");
            string filePath = Console.ReadLine();

            if (File.Exists(filePath))
            {
                int countLines = 0;

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line = string.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (countLines++ % 2 == 0)
                            continue;

                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine($"File {filePath} not found!");
            }
        }
    }
}
