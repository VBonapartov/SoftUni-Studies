namespace _06.ZippingSlicedFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;

    class Program
    {
        private const string Extension = ".gz";

        static void Main(string[] args)
        {
            Console.Write("Choose a file path: ");
            string filePath = Console.ReadLine();
            // string filePath = @"Canguru.jpg";

            Console.Write("Number of parts: ");
            int parts = int.Parse(Console.ReadLine());

            string destinationDirectory = @"test";

            if (!SliceAndCompress(filePath, destinationDirectory, parts))
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
            DecompressAndAssemble(files, destinationDirectory, Path.GetExtension(filePath));
        }

        private static List<string> GetFilesFromDirectory(string destinationDirectory)
        {
            return Directory.GetFiles(destinationDirectory, "*.*", SearchOption.AllDirectories)
                            .Where(s => Path.GetExtension(s).Equals(Extension))
                            .ToList();
        }

        private static bool SliceAndCompress(string sourceFile, string destinationDirectory, int parts)
        {
            if (!File.Exists(sourceFile))
            {
                Console.WriteLine($"File {sourceFile} not found!");
                return false;
            }

            string extension = Path.GetExtension(sourceFile);

            using (FileStream reader = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                long partSize = reader.Length / parts + 1;

                for (int i = 0; i < parts; i++)
                {
                    string outputFile = Path.Combine(destinationDirectory, $"Part-{i}{Extension}");

                    using (FileStream writer = new FileStream(outputFile, FileMode.Create))
                    {
                        using (GZipStream compressionStream = new GZipStream(writer, CompressionMode.Compress, false))
                        {
                            byte[] buffer = new byte[4096];

                            while (writer.Length < partSize)
                            {
                                int readBytes = reader.Read(buffer, 0, buffer.Length);

                                if (readBytes == 0)
                                {
                                    break;
                                }

                                compressionStream.Write(buffer, 0, readBytes);
                            }
                        }
                    }
                }
            }

            return true;
        }

        private static void DecompressAndAssemble(List<string> files, string destinationDirectory, string originalExtension)
        {
            if (files.Count == 0)
            {
                return;
            }

            string outputFile = Path.Combine(destinationDirectory, $"Assembled{originalExtension}");

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
                                using (GZipStream compressionStream = new GZipStream(reader, CompressionMode.Decompress, false))
                                {
                                    byte[] buffer = new byte[4096];

                                    int readBytes = compressionStream.Read(buffer, 0, buffer.Length);

                                    while (readBytes != 0)
                                    {
                                        writer.Write(buffer, 0, readBytes);
                                        readBytes = compressionStream.Read(buffer, 0, buffer.Length);
                                    }
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
