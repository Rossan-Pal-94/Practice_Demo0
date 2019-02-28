using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class GradeStatistics
    {
       public float averageGrade;
       public float lowestGrade;
       public float highestGrade;

        public GradeStatistics()
        {
            averageGrade = 0;
            lowestGrade = float.MaxValue; ; ;
            highestGrade = float.MinValue;
        }
    }
}
