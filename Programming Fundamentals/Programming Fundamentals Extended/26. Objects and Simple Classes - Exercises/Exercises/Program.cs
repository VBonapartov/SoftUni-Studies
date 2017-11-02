using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    class Exercise
    {
        public string Topic { get; set; }
        public string CourseName { get; set; }
        public string JudgeContestLink { get; set; }
        public List<string> Problems { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Exercise> exercises = ReadExercises();
            PrintExercises(exercises);
        }

        private static List<Exercise> ReadExercises()
        {
            List<Exercise> exercises = new List<Exercise>();

            string input = string.Empty;
            while (!(input = Console.ReadLine().Trim()).Equals("go go go"))
            {
                exercises.Add(ReadExercise(input));
            }

            return exercises;
        }

        private static Exercise ReadExercise(string input)
        {
            string[] command = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

            Exercise exercise = new Exercise
            {
                Topic = command[0],
                CourseName = command[1],
                JudgeContestLink = command[2],
                Problems = command[3]
                                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                .ToList()
            };

            return exercise;
        }

        private static void PrintExercises(List<Exercise> exercises)
        {
            foreach(Exercise exercise in exercises)
            {
                Console.WriteLine($"Exercises: {exercise.Topic}");
                Console.WriteLine($"Problems for exercises and homework for the \"{exercise.CourseName}\" course @ SoftUni.");
                Console.WriteLine($"Check your solutions here: {exercise.JudgeContestLink}");

                int countProblems = 1;
                foreach (string problem in exercise.Problems)
                {
                    Console.WriteLine($"{countProblems++}. {problem}");
                }
            }
        }
    }
}
