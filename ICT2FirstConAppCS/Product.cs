using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2FirstConAppCS
{
    internal class Product : IClassDesign
    {
        public int ID { get; set; }
        public string ?Name { get; set; }
        public int Rate { get; set; }
        public string ?Description { get; set; }
        public string ? Category { get; set; }
        public void Display()
        {
            Console.WriteLine("Product Id:" + ID + " Name:" + Name + " Rate:" + Rate + " Desc: " + Description);
        }

        public string GetUpdateData(int x)
        {
            throw new NotImplementedException();
        }
    }
}
