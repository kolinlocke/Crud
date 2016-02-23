using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Common;
using EntityBase;

namespace Interfaces
{
    public interface Interface_ModelDataAccess<T_Entity, T_EntityKey>
        where T_Entity : EntityBase<T_Entity, T_EntityKey>, new()
        where T_EntityKey : EntityKey, new()
    {
        List<String> GetEntityKeys(String EntityName);

        T_Entity Load(T_EntityKey EntityKey);

        T_Entity Load(Expression<Func<T_Entity, bool>> LoadPredicate);

        void Save(T_Entity Entity);

        //T_Re Load_RelatedEntity<T_Re>(Parameters.Keys Keys) where T_Re : EntityBase<T_Re>;

        T_RelatedEntity Load_RelatedEntity<T_RelatedEntity>(T_EntityKey EntityKey) where T_RelatedEntity : EntityBase.EntityBase;
    }
}
