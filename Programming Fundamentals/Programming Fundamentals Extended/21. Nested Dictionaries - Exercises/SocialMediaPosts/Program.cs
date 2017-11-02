using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaPosts
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<long>> postInfo = new Dictionary<string, List<long>>();
            Dictionary<string, Dictionary<string, List<string>>> commentInfo = new Dictionary<string, Dictionary<string, List<string>>>();

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("drop the media"))
            {
                string[] command = input.Trim().Split(' ');

                switch(command[0])
                {
                    case "post":
                        AddPost(postInfo, command);
                        break;

                    case "like":
                        LikePost(postInfo, command);
                        break;

                    case "dislike":
                        DislikePost(postInfo, command);
                        break;

                    case "comment":
                        CommentPost(commentInfo, command);
                        break;
                }
            }

            PrintPostInfo(postInfo, commentInfo);
        }

        static private void AddPost(Dictionary<string, List<long>> postInfo, string[] command)
        {
            string postName = command[1];
            
            if(!postInfo.ContainsKey(postName))
            {
                postInfo.Add(postName, new List<long>() { 0, 0 });
            }
        }

        static private void LikePost(Dictionary<string, List<long>> postInfo, string[] command)
        {
            string postName = command[1];

            if (postInfo.ContainsKey(postName))
            {
                // index 0 -> like; index 1 -> dislike
                postInfo[postName][0]++;
            }
        }

        static private void DislikePost(Dictionary<string, List<long>> postInfo, string[] command)
        {
            string postName = command[1];

            if (postInfo.ContainsKey(postName))
            {
                // index 0 -> like; index 1 -> dislike
                postInfo[postName][1]++;
            }
        }

        static private void CommentPost(Dictionary<string, Dictionary<string, List<string>>> commentInfo, string[] command)
        {
            string postName = command[1];
            string commenterName = command[2];
            string content = string.Join(" ", command.Where((x, index) => index > 2).ToArray());

            if (commentInfo.ContainsKey(postName))
            {
                if(commentInfo[postName].ContainsKey(commenterName))
                {
                    commentInfo[postName][commenterName].Add(content);
                }
                else
                {
                    commentInfo[postName].Add(commenterName, new List<string>() { content });
                }
            }
            else
            {
                commentInfo.Add( postName, 
                                 new Dictionary<string, List<string>>()
                                 {
                                    { commenterName, new List<string>() { content } }
                                 }
                                );
            }
        }

        static private void PrintPostInfo(Dictionary<string, List<long>> postInfo, Dictionary<string, Dictionary<string, List<string>>> commentInfo)
        {
            foreach (KeyValuePair<string, List<long>> post in postInfo)
            {
                Console.WriteLine($"Post: {post.Key} | Likes: {post.Value[0]} | Dislikes: {post.Value[1]}");

                Console.WriteLine("Comments:");
                if (commentInfo.ContainsKey(post.Key))
                {
                    foreach (KeyValuePair<string, List<string>> commenter in commentInfo[post.Key])
                    {
                        Console.WriteLine($"*  {commenter.Key}: {string.Join(", ", commenter.Value)}");
                    }
                }
                else
                {
                    Console.WriteLine("None");
                }
            }
        }
    }
}
