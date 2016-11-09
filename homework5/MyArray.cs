using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__sharp__test
{
    class MyArray : System.Collections.CollectionBase
    {

        public int Add(object sender)
        {
            return List.Add(sender);
        }
        public void Remove(object sender)
        {
            List.Remove(sender);
        }
        public object this[int Index]
        {
            set
            {
                List[Index] = value;
            }
            get
            {
                return (object)List[Index];
            }

        }
        public new void Clear()
        {
            List.Clear();
        }
    }
}
