using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2FirstConAppCS
{
    public abstract class GenAbsBase<U> : IGenClassDesign<U>
    {
        private List<U> list;
        public GenAbsBase()
        {
            if (list == null)
            {
                list = new List<U>();
            }
        }
        public int Count()
        {
            return list.Count;
        }

        public void Delete(U objectToDelete)
        {
            list.Remove(objectToDelete);
        }

        public void Insert(U newObject)
        {
            list.Add(newObject);
        }

        public List<U> ShowAll()
        {
            if (list != null)
            {
                list.ToList<U>();
            }
            return null;
        }
        public abstract void test();
    }

    internal class Products : GenAbsBase<Product>
    {
     
        public override void test()
        {
            throw new NotImplementedException();
        }

        
    }
}
