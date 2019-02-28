using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class GradeBook
    {
        public GradeBook()
        {
            grades = new List<float>();
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            float sum = 0;
            foreach(float grade in grades)
            {
                stats.highestGrade = Math.Max(grade, stats.highestGrade);
                stats.lowestGrade = Math.Min(grade, stats.lowestGrade);
                sum = sum + grade;
            }
            stats.averageGrade = sum / grades.Count;
            return stats;
        }
        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }
        List<float> grades;
    }
}
