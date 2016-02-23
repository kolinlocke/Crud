using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lv02_EntityBase.EntityBase;

namespace Lv02_EntityController
{
    public class EntityController
    {
        public static T Create_Entity<T>() where T : EntityBase<T>
        {


            return default(T);
        }
    }
}
