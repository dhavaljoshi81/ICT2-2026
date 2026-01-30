using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2FirstConAppCS.PartialClasses
{
    internal partial class Employee : IClassDesign
    {
        public void Display()
        {
            Console.WriteLine("ID=" + EmpID + " Name=" + Name);
        }
    }
}
