namespace _07.DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    class Program
    {
        private static Dictionary<string, Dictionary<string, double>> extAndFiles = new Dictionary<string, Dictionary<string, double>>();

        static void Main(string[] args)
        {
            Console.Write("Enter directory: ");
            string directory = Console.ReadLine();
            //string directory = @"C:\Windows";

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string outputFile = Path.Combine(desktopPath, "result.txt");

            if (!Directory.Exists(directory))
            {
                Console.WriteLine("Directory does not exists.");
                return;
            }

            List<string> files = GetFilesFromDirectory(directory);

            GetFilesInfo(files);

            SaveFilesInfo(outputFile);
        }

        private static void SaveFilesInfo(string outputFile)
        {
            var sortedExtAndFiles = extAndFiles.OrderByDescending(f => f.Value.Count)
                                               .ThenBy(f => f.Key)
                                               .ToDictionary(f => f.Key, f => f.Value);

            using (FileStream fileStream = new FileStream(outputFile, FileMode.Create))
            {
                foreach (KeyValuePair<string, Dictionary<string, double>> extension in sortedExtAndFiles)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(extension.Key + Environment.NewLine);
                    fileStream.Write(bytes, 0, bytes.Length);

                    foreach (KeyValuePair<string, double> file in extension.Value.OrderBy(l => l.Value))
                    {
                        double fileSize = (double)file.Value / 1024;

                        bytes = Encoding.UTF8.GetBytes(string.Format($"--{Path.GetFileName(file.Key)} - {fileSize:F3}kb" + Environment.NewLine));
                        fileStream.Write(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        private static void GetFilesInfo(List<string> files)
        {
            foreach (string file in files)
            {
                string fileExtension = Path.GetExtension(file);
                long fileLength = new FileInfo(file).Length;

                if (!extAndFiles.ContainsKey(fileExtension))
                {
                    extAndFiles.Add(fileExtension, new Dictionary<string, double>());
                }

                extAndFiles[fileExtension][file] = fileLength;
            }
        }

        private static List<string> GetFilesFromDirectory(string destinationDirectory)
        {
            return Directory.GetFiles(destinationDirectory).ToList();
        }
    }
}
