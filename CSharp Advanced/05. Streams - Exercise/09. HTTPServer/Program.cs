namespace _09.HTTPServer
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    class Program
    {
        private const string ServerIPAdress = "127.0.0.1";
        private const int PortNumber = 1337;

        private const string IndexPage = @"pages\index.html";
        private const string InfoPage = @"pages\info.html";
        private const string ErrorPage = @"pages\error.html";

        static void Main(string[] args)
        {
            IPAddress localAddr = IPAddress.Parse(ServerIPAdress);
            TcpListener tcpListener = new TcpListener(localAddr, PortNumber);
            tcpListener.Start();

            Console.WriteLine("Server has started on {0}:{1}.{2}Waiting for a connection...", ServerIPAdress, PortNumber, Environment.NewLine);

            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();

                using (StreamReader reader = new StreamReader(tcpClient.GetStream()))
                {
                    using (StreamWriter writer = new StreamWriter(tcpClient.GetStream()))
                    {
                        string htmlResponse = string.Empty;

                        try
                        {
                            string request = reader.ReadLine();

                            Console.WriteLine(request);
                            string[] tokens = request.Split(' ');
                            string page = tokens[1];

                            if (page.Equals("/"))
                            {
                                htmlResponse = GetIndexPage().ToString();
                                writer.WriteLine("HTTP/1.0 200 OK" + Environment.NewLine);
                                writer.Write(htmlResponse);
                            }
                            else if (page.Equals("/info"))
                            {
                                var ci = new CultureInfo("en-US");
                                htmlResponse = string.Format("<!doctype html> <html> <head> <title>Info Page</title> </head> <body> <h2>Current Time: {0}</h2> <h2>Logical Processors: {1}</h2><h4>Back to the <a href=\"/\">homepage</a></h4> </body> </html>", DateTime.Now.ToString("dd MMM yyyy HH:mm:ss", ci), Environment.ProcessorCount);
                                writer.WriteLine("HTTP/1.0 200 OK" + Environment.NewLine);
                                writer.Write(htmlResponse);
                            }
                            else
                            {
                                htmlResponse = GetErrorPage().ToString();
                                writer.WriteLine("HTTP/1.0 200 OK" + Environment.NewLine);
                                writer.Write(htmlResponse);
                            }
                        }
                        catch (Exception e)
                        {
                            writer.WriteLine("HTTP/1.0 404 OK" + Environment.NewLine);
                            Console.WriteLine($"Exception: {e.Message}");
                        }

                        Console.WriteLine("Response sent.");
                    }
                }
            }
        }

        private static StringBuilder GetIndexPage()
        {
            StringBuilder fileContent = new StringBuilder();

            if (File.Exists(IndexPage))
            {
                using (StreamReader reader = new StreamReader(IndexPage))
                {
                    string line = string.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        fileContent.Append(line);
                    }
                }
            }

            return fileContent;
        }

        private static StringBuilder GetErrorPage()
        {
            StringBuilder fileContent = new StringBuilder();

            if (File.Exists(ErrorPage))
            {
                using (StreamReader reader = new StreamReader(ErrorPage))
                {
                    string line = string.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        fileContent.Append(line);
                    }
                }
            }

            return fileContent;
        }
    }
}
