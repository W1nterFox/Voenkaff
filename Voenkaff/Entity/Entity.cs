using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voenkaff.Entity
{
    abstract class Entity<T>
    {
       public T Instance { get; set; } 
    }
}
