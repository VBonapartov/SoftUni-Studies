namespace _19.ChatLogger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security;

    class Program
    {
        static void Main(string[] args)
        {
            DateTime currentDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            List<Message> messages = ReadMessagesFromInput();
            PrintMessages(messages, currentDate);
        }

        private static List<Message> ReadMessagesFromInput()
        {
            List<Message> messages = new List<Message>();

            string input = string.Empty;

            while(!(input = Console.ReadLine()).Equals("END"))
            {
                string[] cmdArgs = input.Split(new[] { " / " }, StringSplitOptions.RemoveEmptyEntries);
                string content = cmdArgs[0];
                DateTime date = DateTime.ParseExact(cmdArgs[1], "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                messages.Add(new Message(content, date));
            }

            return messages;
        }

        private static void PrintMessages(List<Message> messages, DateTime currentDate)
        {
            messages = messages.OrderBy(m => m.Date).ToList();

            foreach(Message message in messages)
            {
                Console.WriteLine(message);
            }

            Message lastMessage = messages.LastOrDefault();

            if (currentDate.Year == lastMessage.Date.Year && currentDate.Month == lastMessage.Date.Month &&
                currentDate.Day - lastMessage.Date.Day <= 1)
            {
                if(currentDate.Day != lastMessage.Date.Day)
                {
                    Console.WriteLine("<p>Last active: <time>yesterday</time></p>");
                    return;
                }

                TimeSpan timeDiff = currentDate - lastMessage.Date;

                if(timeDiff.Hours >= 1)
                {
                    Console.WriteLine($"<p>Last active: <time>{timeDiff.Hours} hour(s) ago</time></p>");
                }
                else if(timeDiff.Minutes >= 1)
                {
                    Console.WriteLine($"<p>Last active: <time>{timeDiff.Minutes} minute(s) ago</time></p>");
                }
                else
                {
                    Console.WriteLine("<p>Last active: <time>a few moments ago</time></p>");
                }
            }
            else
            {
                string format = "dd-MM-yyyy";
                Console.WriteLine($"<p>Last active: <time>{lastMessage.Date.ToString(format)}</time></p>");
            }    
        }
    }

    class Message
    {
        public Message(string content, DateTime date)
        {
            this.Content = content;
            this.Date = date;
        }

        public string Content { get; private set; }

        public DateTime Date { get; private set; }

        public override string ToString()
        {
            return $"<div>{SecurityElement.Escape(this.Content)}</div>";
        }
    }
}
