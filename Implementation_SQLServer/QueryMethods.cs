using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using _EntityBase;

namespace Lv03_Implementation_SQLServer
{
    internal class QueryMethods
    {
        #region _Methods

        public static List<T_Entity> GetEntities<T_Entity>(String QueryCondition) 
            where T_Entity : EntityBase
        {




            return null;
        }

        #endregion

        #region _DataConnection

        static DataConnection_Singleton pDataConnection
        {
            get { return DataConnection_Singleton.pInstance; } 
        }

        sealed class DataConnection_Singleton
        {
            static readonly DataConnection_Singleton mInstance =
                new DataConnection_Singleton()
                {
                    pConnectionString = ConfigurationManager.ConnectionStrings["ModelDataAccess_SQLServer"].ConnectionString
                };

            public static DataConnection_Singleton pInstance
            { 
                get { return mInstance; } 
            }

            public String pConnectionString { get; private set; }
        }

        #endregion

    }
}
