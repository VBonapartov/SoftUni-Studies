using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    class User
    {
        public string Username { get; set; }
        public List<Message> ReceivedMessages { get; set; }
    }

    class Message
    {
        public string Sender { get; set; }
        public string Content { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<User> usersMsg = ReadInput();

            string[] users = Console.ReadLine().Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            PrintMessagesByUsers(usersMsg, users[0], users[1]);
        }

        private static List<User> ReadInput()
        {
            List<User> usersMsg = new List<User>();

            string input = string.Empty;
            while (!(input = Console.ReadLine().Trim()).Equals("exit"))
            {
                string[] command = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (command[0].Equals("register"))
                {
                    RegisterUser(usersMsg, command[1]);
                }
                else if (command[1].Equals("send"))
                {
                    ReadAndSaveMesageInfo(usersMsg, command[0], command[2], command[3]);
                }
            }

            return usersMsg;
        }

        private static void ReadAndSaveMesageInfo(List<User> usersMsg, string senderUsername, string recipientUsername, string content)
        {
            bool isSenderUsernameExists = usersMsg.Where(u => u.Username.Equals(senderUsername)).Any();
            bool isRecipientUsernameExists = usersMsg.Where(u => u.Username.Equals(recipientUsername)).Any();

            if (!isSenderUsernameExists || !isRecipientUsernameExists)
                return;

            Message message = new Message
            {
                Sender = senderUsername,
                Content = content
            };

            User user = usersMsg.First(u => u.Username.Equals(recipientUsername));
            user.ReceivedMessages.Add(message);
        }

        private static void RegisterUser(List<User> usersMsg, string username)
        {
            bool isUsernameExists = usersMsg.Where(u => u.Username.Equals(username)).Any();

            if (isUsernameExists)
                return;

            User user = new User
            {
                Username = username,
                ReceivedMessages = new List<Message> { }
            };

            usersMsg.Add(user);
        }

        private static void PrintMessagesByUsers(List<User> usersMsg, string firstUser, string secondUser)
        {
            List<Message> msgsSendByFirstUser = usersMsg
                                                    .Where(u => u.Username.Equals(secondUser))
                                                    .Select(u => u.ReceivedMessages)
                                                    .SelectMany(u => u)
                                                    .ToList()
                                                    .Where(m => m.Sender.Equals(firstUser))
                                                    .ToList();

            List<Message> msgsSendBySecondUser = usersMsg
                                                    .Where(u => u.Username.Equals(firstUser))
                                                    .Select(u => u.ReceivedMessages)
                                                    .SelectMany(u => u)
                                                    .ToList()
                                                    .Where(m => m.Sender.Equals(secondUser))
                                                    .ToList();

            int maxCountMsgs = Math.Max(msgsSendByFirstUser.Count, msgsSendBySecondUser.Count);
            for(int i = 0; i < maxCountMsgs; i++)
            {        
                if (i < msgsSendByFirstUser.Count)
                    Console.WriteLine($"{firstUser}: {msgsSendByFirstUser[i].Content}");

                if (i < msgsSendBySecondUser.Count)
                    Console.WriteLine($"{msgsSendBySecondUser[i].Content} :{secondUser}");
            }

            if(maxCountMsgs == 0)
                Console.WriteLine("No messages");
        }
    }
}
