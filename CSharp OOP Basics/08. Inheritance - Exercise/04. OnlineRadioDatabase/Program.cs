namespace _04._OnlineRadioDatabase
{    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Song> songs = GetSongs();
            PrintPlaylist(songs);
        }

        private static List<Song> GetSongs()
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                try
                {
                    string[] cmdArs = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                    string artistName = cmdArs[0];
                    string songName = cmdArs[1];

                    int idxSongLengthSeparator = cmdArs[2].IndexOf(":");

                    if (cmdArs.Length < 3 || idxSongLengthSeparator < 1 || idxSongLengthSeparator > cmdArs[2].Length - 2)
                    {
                        throw new InvalidSongException();
                    }

                    int[] timeTokens = cmdArs[2]
                                        .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

                    int minutes = timeTokens[0];
                    int seconds = timeTokens[1];

                    Song song = new Song(artistName, songName, minutes, seconds);
                    songs.Add(song);

                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongException ise)
                {
                    Console.WriteLine(ise.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid song length.");
                }
            }

            return songs;
        }

        private static void PrintPlaylist(List<Song> songs)
        {
            Console.WriteLine($"Songs added: {songs.Count}");

            TimeSpan playlistLength = TimeSpan.FromSeconds(songs.Sum(s => s.CalculateSongLength()));
            Console.WriteLine($"Playlist length: {playlistLength.Hours}h {playlistLength.Minutes}m {playlistLength.Seconds}s");
        }
    }
}
