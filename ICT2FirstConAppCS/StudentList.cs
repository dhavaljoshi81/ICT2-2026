using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2FirstConAppCS
{
    internal class StudentList
    {
        private List<Student> students = new List<Student>();

        public void Add(Student student)
        {
            students.Add(student);
        }

        public void DisplayAll()
        {
            foreach (Student student in students)
            {
                student.Display();
            }
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public ArrayList GetAllStudents(string name)
        {
            ArrayList newList = new ArrayList();
            foreach (Student student in students)
            {
                if (student.Name == name)
                {
                    newList.Add(student);
                }
            }
            return newList;
        }
    }
}
