using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name)
            : base(name)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Not enough students for a Ranked Gradebook.");
            }

            //Returning the letter grade of the average grade
            //First, calculates the number of students with an average grade larger than averageGrade
            int numGreaterThanAvg = 0;
            foreach (var student in Students)
            {
                if (student.AverageGrade > averageGrade)
                {
                    numGreaterThanAvg++;
                }
            }

            //Then, uses that number to calculate the letter grade
            if (numGreaterThanAvg < Students.Count / 5)
            {
                return 'A';
            }

            else if (numGreaterThanAvg < 2 * (Students.Count / 5))
            {
                return 'B';
            }

            else if (numGreaterThanAvg < 3 * (Students.Count / 5))
            {
                return 'C';
            }

            else if (numGreaterThanAvg < 4 * (Students.Count / 5))
            {
                return 'D';
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
