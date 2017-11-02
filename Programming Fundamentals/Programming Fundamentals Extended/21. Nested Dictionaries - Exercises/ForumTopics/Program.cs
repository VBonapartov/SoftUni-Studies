using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumTopics
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> forumTopics = new Dictionary<string, HashSet<string>>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("filter"))
            {
                string[] command = input.Trim().Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string topic = command[0];
                string[] tags = command[1].Trim().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if(!forumTopics.ContainsKey(topic))
                {
                    forumTopics.Add(topic, new HashSet<string>() { });
                }                

                for (int i = 0; i < tags.Length; i++)
                {
                    forumTopics[topic].Add(tags[i].Trim());
                }
            }

            string[] sequenceOfTags = Console.ReadLine().Trim().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (KeyValuePair<string, HashSet<string>> topic in forumTopics)
            {
                string tags = string.Join(", ", topic.Value);

                bool isMissingTag = false;
                for (int i = 0; i < sequenceOfTags.Length; i++)
                {
                    if (!tags.Contains(sequenceOfTags[i].Trim()))
                    {
                        isMissingTag = true;
                        break;
                    }
                }

                if(!isMissingTag)
                {
                    Console.WriteLine($"{topic.Key} | #{string.Join(", #", topic.Value)}");
                }
            }
        }
    }
}
