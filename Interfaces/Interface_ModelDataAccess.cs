using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using _Common;
using _EntityBase;

namespace _Interfaces
{
    public interface Interface_ModelDataAccess<T_Entity>
        where T_Entity : EntityBase<T_Entity>, new()
    {
        List<String> GetEntityKeys(String EntityName);

        T_Entity Load<T_EntityKey>(T_EntityKey EntityKey)
            where T_EntityKey : EntityKey;

        void Save(T_Entity Entity);

        T_RelatedEntity Load_RelatedEntity<T_RelatedEntity, T_EntityKey>
            (T_EntityKey EntityKey)
            where T_RelatedEntity : EntityBase, new()
            where T_EntityKey : EntityKey, new();
    }
}
