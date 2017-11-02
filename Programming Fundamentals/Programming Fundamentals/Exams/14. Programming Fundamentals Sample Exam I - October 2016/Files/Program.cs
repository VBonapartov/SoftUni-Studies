using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class Program
    {
        class File
        {
            public string FileName { get; set; }
            public string Root { get; set; }
        }

        static void Main(string[] args)
        {
            int numberOfFiles = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, decimal>> files = new Dictionary<string, Dictionary<string, decimal>>();
            for(int i = 0; i < numberOfFiles; i++)
            {
                string[] fileInfo = Console.ReadLine().Split('\\');
                string[] fileAttr = fileInfo[fileInfo.Length - 1].Split(';');

                string root = fileInfo[0];
                string fileName = fileAttr[0];
                decimal fileSize = Convert.ToDecimal(fileAttr[1]);

                if(!files.ContainsKey(root))
                {
                    files.Add(root, new Dictionary<string, decimal> { });
                }

                files[root][fileName] = fileSize;

            }

            string[] command = Console.ReadLine().Split(' ');
            PrintFiles(files, command[0], command[2]);
        }

        private static void PrintFiles(Dictionary<string, Dictionary<string, decimal>> files, string fileExtension, string root)
        {
            if (files.Count == 0 || !files.ContainsKey(root))
            {
                Console.WriteLine("No");
                return;
            }

            Dictionary<string, decimal> allFilesInRoot = files
                                                        .Where(f => f.Key.Equals(root))
                                                        .Select(f => f.Value)
                                                        .First()
                                                        .Where(f => f.Key.Contains("." + fileExtension))
                                                        .OrderByDescending(f => f.Value)
                                                        .ThenBy(f => f.Key)
                                                        .ToDictionary(f => f.Key, f => f.Value);

            if (allFilesInRoot.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                foreach (KeyValuePair<string, decimal> file in allFilesInRoot)
                {
                    Console.WriteLine($"{file.Key} - {file.Value} KB");
                }
            }
        }
    }
}
