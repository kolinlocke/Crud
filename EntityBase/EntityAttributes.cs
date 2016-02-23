using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _EntityBase.EntityAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class EntityAttribute : Attribute
    {
        public String EntityName { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class EntityFieldAttribute : Attribute
    {
        public String FieldName { get; set; }
        public Boolean IsKey { get; set; }
    }
}
