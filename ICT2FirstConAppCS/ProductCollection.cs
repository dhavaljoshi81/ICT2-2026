using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2FirstConAppCS
{
    class Product1
    {
        public int ID { get; set; }
        public string ?Name { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }

    }
    internal class ProductCollection : IGenClassDesign<Product>
    {
        private List<int> list = new List<int>();

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Product newObject)
        {
            throw new NotImplementedException();
        }

        public void Insert(Product newObject)
        {
            throw new NotImplementedException();
        }

        public List<Product> ShowAll()
        {
            throw new NotImplementedException();
        }
    }
}
