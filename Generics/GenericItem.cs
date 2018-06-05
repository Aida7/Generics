using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class GenericItem<T> where T : Entity, ICloneable, IComparable, new()
    {
        private T item;

        public GenericItem(T item)
        {
            this.item = item;
        }

        public GenericItem()
        {

        }

        public T GetItem()
        {
            return new T();
            //return item;
        }
    }
}
