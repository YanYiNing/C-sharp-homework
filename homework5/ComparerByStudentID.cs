using c__sharp__test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    class ComparerByStudentID : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x.studentID > y.studentID)
                return 1;
            else if (x.studentID < y.studentID)
                return -1;
            else
                return 0;
        }
    }
}
