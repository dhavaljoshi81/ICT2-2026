using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2FirstConAppCS
{
    public class MyCollection<T>
    {
        private List<T> dataList = new List<T>();

        public List<T> DataList 
        {
            get
            {
                return dataList;
            }            
        }
        public MyCollection() { }

        public void Add(T item)
        {
            dataList.Add(item);
        }

        public void Clear()
        {
            dataList.Clear();
        }
        public void Remove(T item)
        {
            dataList.Remove(item);
        }

    }
}
