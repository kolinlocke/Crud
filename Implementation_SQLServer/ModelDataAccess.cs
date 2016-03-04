using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using _Common;
using _EntityBase;
using _Interfaces;
using _Implementation_Entities.Entities;

namespace Implementation_ModelDataAccess_SQLServer
{
    public class ModelDataAccess<T_Entity> : Interface_ModelDataAccess<T_Entity>
        where T_Entity : EntityBase<T_Entity>, new()
    {
        public List<string> GetEntityKeys(string EntityName)
        {
            throw new NotImplementedException();
        }

        public T_Entity Load<T_EntityKey>(T_EntityKey EntityKey) 
            where T_EntityKey : EntityKey
        {
            //Get EntityName
            var EntityName = EntityHelper.Get_EntityName<T_Entity>();

            //Get Entity Fields
            var EntityFields = EntityHelper.Get_EntityFields<T_Entity>();

            //Get EntityKey Fields
            var EntityKeyFields = EntityHelper.Get_EntityFields<T_EntityKey>();




            return new T_Entity();
        }

        public void Save(T_Entity Entity)
        {
            throw new NotImplementedException();
        }

        public T_RelatedEntity Load_RelatedEntity<T_RelatedEntity, T_EntityKey>(T_EntityKey EntityKey)
            where T_RelatedEntity : EntityBase, new()
            where T_EntityKey : EntityKey, new()
        {
            return new T_RelatedEntity();
        }
    }
}
