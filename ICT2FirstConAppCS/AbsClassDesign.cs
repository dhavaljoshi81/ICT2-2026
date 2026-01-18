using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2FirstConAppCS
{
    internal abstract class AbsClassDesign : IClassDesign
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public abstract void Display();

        public string GetUpdateData(int x)
        {
            throw new NotImplementedException();
        }
    }
}
