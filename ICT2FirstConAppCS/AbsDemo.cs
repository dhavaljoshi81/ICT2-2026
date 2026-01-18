using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2FirstConAppCS
{
    internal sealed class AbsDemo : AbsClassDesign
    {
        public override void Display()
        {
            Console.WriteLine($"ID: {ID}, Name: {Name}");
        }
    }

    class MyClass
    {
        public MyClass()
        {
        }
    }
}
