using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2FirstConAppCS.MyTypes
{
    internal class C : A
    {
        public int Data 
        { 
            get
            {
                return z * 20;
            }
            set
            {
                if (value < 300)
                {
                    z = value;
                }
                
            }
        }

        public C() 
        { 
        }
        public C(int a, int b) 
            :base (a)
        {
            z = b;
        }
        //public override void Display()
        //{
        //    Console.Write("x:" + x + " z:" + z);
        //}
        public void Display(string s)
        {
            Console.WriteLine("s:" + s + " and x:" + x + " z:" + z);
        }
        
    }

    
}
