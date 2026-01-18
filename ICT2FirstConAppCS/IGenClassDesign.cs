using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2FirstConAppCS
{
    internal interface IGenClassDesign<MyType>
    {
        void Insert(MyType newObject);
        void Delete(MyType objectToDelete);
        List<MyType> ShowAll();
        int Count();
    }
}
