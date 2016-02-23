using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using _Common;
using _EntityBase;
using _Interfaces;

namespace Implementation_SQLServer
{
    public class ModelDataAccess<T_Entity> : Interface_ModelDataAccess<T_Entity>
        where T_Entity : EntityBase<T_Entity>, new()
    {
        public List<string> GetEntityKeys(string EntityName)
        {
            throw new NotImplementedException();
        }

        public T_Entity Load<T_EntityKey>(T_EntityKey EntityKey) where T_EntityKey : EntityKey
        {
            throw new NotImplementedException();
        }

        public T_Entity Load(Expression<Func<T_Entity, bool>> LoadPredicate)
        {
            throw new NotImplementedException();
        }

        public void Save(T_Entity Entity)
        {
            throw new NotImplementedException();
        }

        public T_RelatedEntity Load_RelatedEntity<T_RelatedEntity, T_EntityKey>(T_EntityKey EntityKey)
            where T_RelatedEntity : EntityBase, new()
            where T_EntityKey : EntityKey, new()
        {
            throw new NotImplementedException();
        }
    }
}
