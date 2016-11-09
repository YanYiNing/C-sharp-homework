using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__sharp__test
{
    class Student
    {
        private string name;
        private int age;
        public long studentID;

        public string Name {
            get {
                return this.name;
            }
        }
        public int Age {
            get {
                return this.age;
            }
        }
        public long StudentID {
            get {
                return this.studentID;
            }
        }

        public Student(string name, int age, long studentID)
        {
            this.name = name;
            this.age = age;
            this.studentID = studentID;
        }

    }
}
