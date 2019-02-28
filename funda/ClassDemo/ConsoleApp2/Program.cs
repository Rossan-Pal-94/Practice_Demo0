using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(99.76f);

            GradeStatistics gradeStatistics = book.ComputeStatistics();
            Console.WriteLine(gradeStatistics.lowestGrade);
            Console.WriteLine(gradeStatistics.averageGrade);
            Console.WriteLine(gradeStatistics.highestGrade);
        }
    }
}
