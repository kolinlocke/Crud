using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using _EntityBase;

namespace _Implementation_SQLServer
{
    internal class QueryMethods
    {
        #region _DataStructs

        public class QueryCondition : List<QueryCondition_Item>
        {

            
        }

        public class QueryCondition_Item
        {
            public String FieldName { get; set; }
            public Object FieldValue { get; set; }
        }

        #endregion

        #region _Methods

        public static List<T_Entity> GetEntities<T_Entity>(String QueryCondition) 
            where T_Entity : EntityBase
        {
            SqlConnection Cn = new SqlConnection(pDataConnection.pConnectionString);

            String Query = "";


            return null;
        }

        public static List<T_Entity> GetEntities<T_Entity>(Expression<Func<T_Entity, Boolean>> LoadPredicate = null)
            where T_Entity : EntityBase
        {
            SqlConnection Cn = new SqlConnection(pDataConnection.pConnectionString);
            SqlCommand Cmd = new SqlCommand() { Connection = Cn };

            //LoadPredicate.Body


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
