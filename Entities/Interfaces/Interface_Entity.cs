using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lv02_Entities.Entities;
using Lv02_Entities.EntityBase;

namespace Lv02_Entities.Interfaces
{
    public interface Interface_Entity<T> where T: EntityBase<T>
    {
        T Entity();
    }
}
