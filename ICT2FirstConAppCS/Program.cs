using System.Globalization;
using ICT2FirstConAppCS.MyTypes;
using System.Collections;

namespace ICT2FirstConAppCS
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            A objA = new A();
            //objA.Display();

            Console.WriteLine(objA);

        }
        static void Main2(string[] args)
        {
            A objA = new A(11, 22);
            //objA.Display();
            Console.WriteLine(objA);

            int i = 100;
            Object obj = i;
            Console.WriteLine(obj);
            String str = "PRQ";
            obj = str;
            Console.WriteLine(obj);
            obj = objA;
            Console.WriteLine(obj);

        }

        static void Main3(string[] args)
        {
            C objC = new C(300, 44);
            objC.Display();
            objC.Data = 555;
            Console.WriteLine(objC.Y);
            Console.WriteLine(objC.Data);
        }

        static void Main4(string[] args)
        {
            IClassDesign classDesign = new Student()
            {
                StudentID = 101,
                Name = "Prq"
            };
            classDesign.Display();

            Console.WriteLine("-------------------");

            classDesign = new Product()
            {
                ID = 201,
                Name = "Laptop",
                Rate = 45000
            };
            classDesign.Display();
        }

        static void Main5(string[] args)
        {
            IClassDesign absDemo = new AbsDemo()
            {
                ID = 1,
                Name = "Abstract Demo"
            };

            absDemo.Display();

        }

        static void Main6(string[] args)
        {
            StudentList students = new StudentList();
            students.Add(new Student() { StudentID = 101, Name = "Prq" });
            students.Add(new Student() { StudentID = 102, Name = "Aaa" });
            students.Add(new Student() { StudentID = 103, Name = "Bbb" });
            students.Add(new Student() { StudentID = 106, Name = "Aaa" });

            foreach (var stu in students.GetAllStudents("Aaa"))
            {
                if (stu is Student)
                {
                    ((Student)stu).Display();
                }
                else
                    Console.WriteLine(stu);
            }

        }

        static void Main7(string[] args)
        {
            List<Student> students = new List<Student>();

            students.Add(new Student() { StudentID = 101, Name = "Prq" });
            students.Add(new Student() { StudentID = 102, Name = "Aaa" });
            students.Add(new Student() { StudentID = 103, Name = "Bbb" });

            foreach (Student stu in students)
            {
                stu.Display();
            }

        }

        static void Main8(string[] args)
        {
            MyCollection<Student> myCollection = new MyCollection<Student>();
            myCollection.Add(new Student { StudentID = 1, Name = "ABC"});
            myCollection.Add(new Student { StudentID = 2, Name = "PQR" });
            myCollection.Add(new Student { StudentID = 3, Name = "XYZ" });

            foreach (var data in myCollection.DataList)
            {
                data.Display();
            }
            Console.WriteLine("----------");

            Student tempStudent = myCollection.DataList[1];
            myCollection.Remove(tempStudent);

            foreach (var data in myCollection.DataList)
            {
                data.Display();
            }
        }

        static void Main9(string[] args)
        {
            Products products = new Products();
            
        }
    }
}
