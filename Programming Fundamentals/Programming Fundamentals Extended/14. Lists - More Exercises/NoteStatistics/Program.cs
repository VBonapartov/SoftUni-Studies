using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> frequencies = Console.ReadLine().Trim().Split(' ').Select(double.Parse).ToList();

            double naturalsNotesFreqSum = 0.00d;
            double sharpsNotesFreqSum = 0.00d;

            List<string> allNotes = new List<string>();
            for (int i = 0; i < frequencies.Count; i++)
            {
                string note = GetMusicalNote(frequencies[i]);
                allNotes.Add(note);

                if(note.Length == 1)
                {
                    naturalsNotesFreqSum += frequencies[i];
                }
                else
                {
                    sharpsNotesFreqSum += frequencies[i];
                }
            }

            List<string> naturalsNotes = allNotes.Where(x => x.Length == 1).ToList();
            List<string> sharpNotes = allNotes.Where(x => x.Length > 1).ToList();

            Console.WriteLine($"Notes: " + string.Join(" ", allNotes));
            Console.WriteLine($"Naturals: " + string.Join(", ", naturalsNotes));
            Console.WriteLine($"Sharps: " + string.Join(", ", sharpNotes));
            Console.WriteLine($"Naturals sum: {naturalsNotesFreqSum}");
            Console.WriteLine($"Sharps sum: {sharpsNotesFreqSum }");
        }

        static private string GetMusicalNote(double frequencies)
        {
            string result = string.Empty;

            switch(frequencies)
            {
                case 261.63:
                    result = "C";
                    break;
                case 277.18:
                    result = "C#";
                    break;
                case 293.66:
                    result = "D";
                    break;
                case 311.13:
                    result = "D#";
                    break;
                case 329.63:
                    result = "E";
                    break;
                case 349.23:
                    result = "F";
                    break;
                case 369.99:
                    result = "F#";
                    break;
                case 392.00:
                    result = "G";
                    break;
                case 415.30:
                    result = "G#";
                    break;
                case 440.00:
                    result = "A";
                    break;
                case 466.16:
                    result = "A#";
                    break;
                case 493.88:
                    result = "B";
                    break;
            }

            return result;
        }
    }
}
