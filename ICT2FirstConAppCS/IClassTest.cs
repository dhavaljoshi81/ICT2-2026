using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2FirstConAppCS
{
    internal interface IClassTest : IClassDesign
    {
        public string Name { get; set; }

    }

    class IntTestClass : IClassTest
    {
        private string name;

        public string Name 
        { 
            get => name; 
            set => name = value; 
        }

        public void Display()
        {
            throw new NotImplementedException();
        }

        public string GetUpdateData(int x)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class ABSIntDemoClass : IClassTest
    {
        private string name;

        public string Name
        {
            get => name;
            set => name = value;
        }


        public abstract void Display();

        public string GetUpdateData(int x)
        {
            throw new NotImplementedException();
        }
    }

}
