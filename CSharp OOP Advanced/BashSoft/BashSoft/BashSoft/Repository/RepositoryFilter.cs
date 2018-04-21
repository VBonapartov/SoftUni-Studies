namespace BashSoft
{
    using System;
    using System.Collections.Generic;

    public class RepositoryFilter
    {
        public void FilterAndTake(Dictionary<string, double> studentsWithMarks, string wantedFilter, int studentsToTake)
        {
            if (wantedFilter.Equals("excellent"))
            {
                this.FilterAndTake(studentsWithMarks, mark => mark >= 5.00, studentsToTake);
            }
            else if (wantedFilter.Equals("average"))
            {
                this.FilterAndTake(studentsWithMarks, mark => mark >= 3.50 && mark < 5.00, studentsToTake);
            }
            else if (wantedFilter.Equals("poor"))
            {
                this.FilterAndTake(studentsWithMarks, mark => mark < 3.50, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private void FilterAndTake(Dictionary<string, double> studentsWithMarks, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterForPrinted = 0;

            foreach (KeyValuePair<string, double> studentMark in studentsWithMarks)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }

                if (givenFilter(studentMark.Value))
                {
                    OutputWriter.PrintStudent(studentMark);
                    counterForPrinted++;
                }
            }
        }
    }
}
