using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace _EntityBase
{
    [Serializable()]
    public abstract class EntityBase { }

    public abstract class EntityBase<T_Entity> : EntityBase
        where T_Entity : EntityBase<T_Entity>, new()
    { }

    [Serializable()]
    public abstract class EntityBase<T_Entity, T_EntityKey> : EntityBase<T_Entity>
        where T_Entity : EntityBase<T_Entity, T_EntityKey>, new()
        where T_EntityKey : EntityKey, new()
    {
        public T_EntityKey pEntityKey
        {
            get { return new T_EntityKey(); }
        }
    }

    [Serializable()]
    public abstract class EntityKey { }
}