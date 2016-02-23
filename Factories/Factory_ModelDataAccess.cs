using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityBase;
using Interfaces;

namespace Factories
{
    public static class Factory_ModelDataAccess
    {
        public static Interface_ModelDataAccess<T_Entity, T_EntityKey> Create_EntityDataAccess<T_Entity, T_EntityKey>()
            where T_Entity : EntityBase<T_Entity, T_EntityKey>, new()
            where T_EntityKey : EntityKey, new()
        {
            return new Implementation_SQLServer.ModelDataAccess<T_Entity, T_EntityKey>();
        }
    }
}
