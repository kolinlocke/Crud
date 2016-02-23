using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EntityBase
{
    [Serializable()]
    public abstract class EntityBase { }

    [Serializable()]
    public abstract class EntityBase<T_Entity, T_EntityKey> : EntityBase
        where T_Entity : EntityBase<T_Entity, T_EntityKey>, new()
        where T_EntityKey : EntityKey, new()
    {
        #region _Constructor

        public EntityBase() { }

        #endregion

        #region _Properties

        public T_EntityKey pEntityKey
        {
            get { return new T_EntityKey(); }
        }

        #endregion
    }

    [Serializable()]
    public abstract class EntityKey { }
}