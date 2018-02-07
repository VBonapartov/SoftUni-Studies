namespace _02.LineNumbers
{
    using System;
    using System.IO;
    using System.Text;

    class Program
    {
        private const string OutputFileName = @"Output.txt";

        static void Main(string[] args)
        {
            Console.Write("Choose a file path: ");
            string filePath = Console.ReadLine();

            if (File.Exists(filePath))
            {
                string line = string.Empty;

                int countLines = 0;
                StringBuilder result = new StringBuilder();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (result.Length > 0)
                            result.Append(Environment.NewLine);

                        result.AppendFormat("Line {0}: {1}", ++countLines, line);
                    }
                }

                WriteToOutputFile(result);
                Console.WriteLine($"The result was saved in file \"{OutputFileName}\"");
            }
            else
            {
                Console.WriteLine($"File {filePath} not found!");
            }
        }

        private static void WriteToOutputFile(StringBuilder text)
        {
            if (File.Exists(OutputFileName))
            {
                File.Delete(OutputFileName);
            }

            using (FileStream target = File.Open(OutputFileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(target))
                {
                    writer.WriteLine(text);
                }
            }
        }
    }
}
