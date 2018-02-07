namespace _05.SlicingFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Choose a file path: ");
            string filePath = Console.ReadLine();
            // string filePath = @"Canguru.jpg";

            Console.Write("Number of parts: ");
            int parts = int.Parse(Console.ReadLine());

            string destinationDirectory = @"test";

            if (!Slice(filePath, destinationDirectory, parts))
            {
                Console.WriteLine("An error occurred while slicing file.");
                return;
            }

            if (!Directory.Exists(destinationDirectory))
            {
                Console.WriteLine("Directory does not exists.");
                return;
            }

            List<string> files = GetFilesFromDirectory(destinationDirectory);
            Assemble(files, destinationDirectory);
        }

        private static List<string> GetFilesFromDirectory(string destinationDirectory)
        {
            return Directory.GetFiles(destinationDirectory).ToList();
        }

        private static bool Slice(string sourceFile, string destinationDirectory, int parts)
        {
            if (!File.Exists(sourceFile))
            {
                Console.WriteLine($"File {sourceFile} not found!");
                return false;
            }

            string extension = Path.GetExtension(sourceFile);

            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                long partSize = reader.Length / parts + 1;

                for (int i = 0; i < parts; i++)
                {
                    string outputFile = Path.Combine(destinationDirectory, $"Part-{i}{extension}");

                    using (FileStream writer = new FileStream(outputFile, FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];

                        while (writer.Length < partSize)
                        {
                            int readBytes = reader.Read(buffer, 0, buffer.Length);

                            if (readBytes == 0)
                            {
                                break;
                            }

                            writer.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }

            return true;
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            string extension = Path.GetExtension(files[0]);
            string outputFile = Path.Combine(destinationDirectory, $"Assembled{extension}");

            try
            {
                using (FileStream writer = new FileStream(outputFile, FileMode.Create))
                {
                    foreach (string file in files)
                    {
                        try
                        {
                            using (FileStream reader = new FileStream(file, FileMode.Open))
                            {
                                byte[] buffer = new byte[4096];

                                int readBytes = reader.Read(buffer, 0, buffer.Length);

                                while (readBytes != 0)
                                {
                                    writer.Write(buffer, 0, readBytes);
                                    readBytes = reader.Read(buffer, 0, buffer.Length);
                                }
                            }
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine($"File {file} not found!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
