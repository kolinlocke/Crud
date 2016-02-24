using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _Interfaces;
using Implementation_Entities.Entities;

namespace Implementation_SQLServer
{
    public class ModelDataAccess_Ingredient : Interface_ModelDataAccess<Entity_Ingredient>
    {
        public List<string> GetEntityKeys(string EntityName)
        {
            throw new NotImplementedException();
        }

        public Entity_Ingredient Load<T_EntityKey>(T_EntityKey EntityKey) where T_EntityKey : _EntityBase.EntityKey
        {
            throw new NotImplementedException();
        }

        public Entity_Ingredient Load(System.Linq.Expressions.Expression<Func<Entity_Ingredient, bool>> LoadPredicate)
        {
            throw new NotImplementedException();
        }

        public void Save(Entity_Ingredient Entity)
        {
            throw new NotImplementedException();
        }

        public T_RelatedEntity Load_RelatedEntity<T_RelatedEntity, T_EntityKey>(T_EntityKey EntityKey)
            where T_RelatedEntity : _EntityBase.EntityBase, new()
            where T_EntityKey : _EntityBase.EntityKey, new()
        {
            throw new NotImplementedException();
        }
    }
}
