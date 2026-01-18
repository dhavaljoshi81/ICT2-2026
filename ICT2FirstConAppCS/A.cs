using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2FirstConAppCS
{
    public class A
    {
        public int x;
        private int y;
        protected int z;
        //internal int test;
        public int Y 
        {
            get { return y; }
            //set; 
        }
        public A()
        {
            x = 10;
            y = 20;
            z = 30;        
        }

        public A(int a)
        {
            y = a;
        }
        public A(int a, int b, int c = 20)
        {
            x = a;
            y = b;
            z = c;
        }

        public virtual void Display()
        {
            Console.WriteLine("x:" + x + " y:" + y + " z:" + z);
        }

        public override string ToString()
        {
            return "Current Value of x:" + x + " y:" + y + " z:" + z;
        }
    }
    public class B : A
    {

    }
}
