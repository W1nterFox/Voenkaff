using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voenkaff
{
    class EntityWrapper<T> where T: Control
    {
        public EntityWrapper(T entity,int identifier)
        {
            Entity = entity;
            Identifier = identifier;
        }

        public int Identifier { get; set; }
        public T Entity { get; set; }
    }
}
