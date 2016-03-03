using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _EntityBase;
using _Interfaces;

namespace _Factories
{
    public static class Factory_ModelDataAccess
    {
        public static Interface_ModelDataAccess<T_Entity> Create_EntityDataAccess<T_Entity>()
            where T_Entity : EntityBase<T_Entity>, new()
        {
            return new Implementation_ModelDataAccess_SQLServer.ModelDataAccess<T_Entity>();
        }
    }
}
