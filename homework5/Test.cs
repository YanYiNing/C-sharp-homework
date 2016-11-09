using c__sharp__test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    class Test
    {
        static void Main(string[] args)
        {
            ArrayCalculator array1 = new ArrayCalculator();
            array1.numbers.Add(1);
            ArrayCalculator array2 = new ArrayCalculator();
            array2.numbers.Add(2);
            ArrayCalculator array3 = new ArrayCalculator();
            array3 = array1 + array2;
            

            List<Student> students = new List<Student>() {
            new Student(name: "student3", age: 17, studentID: 2016210002) ,
            new Student(name: "student2", age: 18, studentID: 2016210001) ,
            new Student(name: "student1", age: 19, studentID: 2016210003) ,
            };

            ComparerByAge age = new ComparerByAge();
            ComparerByStudentID studentID = new ComparerByStudentID();
            ComparerByName name = new ComparerByName();
            Console.WriteLine("请选择排序方式：A姓名  B年龄  C学号");
            char ch = Convert.ToChar(Console.ReadLine());
            switch (ch)
            {
                case 'A': students.Sort(name);break;
                case 'B': students.Sort(age); break;
                case 'C': students.Sort(studentID); break;
            }
            
            foreach (Student student in students)
            {
                Console.WriteLine("My name is " + student.Name + ". I'm " + student.Age + " years old. My studentsID is " + student.StudentID);
            }
        }
    }
}
