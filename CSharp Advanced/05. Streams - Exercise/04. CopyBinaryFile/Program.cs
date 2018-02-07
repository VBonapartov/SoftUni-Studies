namespace _04.CopyBinaryFile
{
    using System;
    using System.IO;

    class Program
    {
        private const string BinaryInputFile = @"Canguru.jpg";
        private const string BinaryOutputFile = @"Output.jpg";

        static void Main(string[] args)
        {
            if (File.Exists(BinaryInputFile))
            {
                using (var source = new FileStream(BinaryInputFile, FileMode.Open))
                {
                    using (var destination = new FileStream(BinaryOutputFile, FileMode.Create))
                    {
                        double fileLength = source.Length;
                        byte[] buffer = new byte[4096];
                        while (true)
                        {
                            int readBytes = source.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0)
                            {
                                break;
                            }

                            destination.Write(buffer, 0, readBytes);
                        }
                    }
                }

                Console.WriteLine("Done copying.");
            }
            else
            {
                Console.WriteLine($"File {BinaryInputFile} not found!");
            }
        }
    }
}
