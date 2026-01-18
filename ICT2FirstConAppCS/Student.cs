using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2FirstConAppCS
{
    internal class Student : A, IClassDesign
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public void Display()
        {
            Console.WriteLine("Id:" + StudentID + " Name:" + Name);
        }

        public string GetUpdateData(int x)
        {
            throw new NotImplementedException();
        }
    }
}
