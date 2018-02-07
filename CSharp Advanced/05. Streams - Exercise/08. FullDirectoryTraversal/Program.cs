namespace _08.FullDirectoryTraversal
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

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string fileReport = Path.Combine(desktopPath, "result.txt");

            if (!Directory.Exists(directory))
            {
                Console.WriteLine("Directory does not exists.");
                return;
            }

            List<string> files = FullDirectoryTraversal(directory);

            GetFilesInfo(files);

            SaveFilesInfo(fileReport);
        }

        private static void SaveFilesInfo(string fileReport)
        {
            var sortedExtAndFiles = extAndFiles.OrderByDescending(f => f.Value.Count)
                                               .ThenBy(f => f.Key)
                                               .ToDictionary(f => f.Key, f => f.Value);

            using (FileStream fileStream = new FileStream(fileReport, FileMode.Create))
            {
                foreach (KeyValuePair<string, Dictionary<string, double>> extension in sortedExtAndFiles)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(extension.Key + Environment.NewLine);
                    fileStream.Write(bytes, 0, bytes.Length);

                    foreach (KeyValuePair<string, double> file in extension.Value.OrderBy(l => l.Value))
                    {
                        bytes = Encoding.UTF8.GetBytes(string.Format($"--{Path.GetFileName(file.Key)} - {file.Value / 1000}kb" + Environment.NewLine));
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

        private static List<String> FullDirectoryTraversal(string sDir)
        {
            List<String> files = new List<String>();

            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(FullDirectoryTraversal(d));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Full Directory Traversal Error!");
            }

            return files;
        }
    }
}
