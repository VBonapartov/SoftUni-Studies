namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class RepositoryFilters
    {
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake)
        {
            if(wantedFilter.Equals("excellent"))
            {
                FilterAndTake(wantedData, mark => mark >= 5.00, studentsToTake);
            }
            else if(wantedFilter.Equals("average"))
            {
                FilterAndTake(wantedData, mark => 3.50 <= mark && mark < 5.00, studentsToTake);
            }
            else if (wantedFilter.Equals("poor"))
            {
                FilterAndTake(wantedData, mark => mark < 3.50, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterForPrinted = 0;

            foreach(KeyValuePair<string, List<int>> userName_Points in wantedData)
            {
                if(counterForPrinted == studentsToTake)
                {
                    break;
                }

                //double averageMark = Average(userName_Points.Value);

                double averageScore = userName_Points.Value.Average();
                double percentageOfFullfilment = averageScore / 100;
                double mark = percentageOfFullfilment * 4 + 2;

                if (givenFilter(mark))
                {
                    OutputWriter.PrintStudent(userName_Points);
                    counterForPrinted++;
                }
            }
        }

        //private static bool ExcellentFilter(double mark)
        //{
        //    return mark >= 5.00;
        //}

        //private static bool AverageFilter(double mark)
        //{
        //    return mark >= 3.50 && mark < 5.00;
        //}

        //private static bool PoorFilter(double mark)
        //{
        //    return mark < 3.50;
        //}

        private static double Average(List<int> scoresOnTask)
        {
            int totalScore = 0;

            foreach(int score in scoresOnTask)
            {
                totalScore += score;
            }

            double percentageOfAll = (double)totalScore / ((double)scoresOnTask.Count * 100);
            double mark = percentageOfAll * 4 + 2;

            return mark;
        }
    }
}
