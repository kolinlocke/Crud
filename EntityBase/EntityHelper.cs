using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using EntityBase.EntityAttributes;

namespace EntityBase
{
    public static class EntityHelper
    {
        public class EntityFields : List<EntityField> { }

        public class EntityField
        {
            public String FieldName { get; set; }
            public Boolean IsKey { get; set; }
        }

        public static String Get_EntityName<T>() where T : EntityBase
        {
            String EntityName = "";
            Type EntityType = typeof(T);
            var EntityAtt = EntityType.GetCustomAttributes(typeof(EntityAttribute), true);
            if (EntityAtt.Any())            
            {
                EntityName = (EntityAtt.FirstOrDefault() as EntityAttribute).EntityName;
            }

            return EntityName;
        }

        public static EntityFields Get_EntityFields<T>() where T : EntityBase
        {
            EntityFields EntityFields = new EntityFields();
            Type EntityType = typeof(T);
            var EntityAtts = EntityType.GetCustomAttributes(typeof(EntityFieldAttribute), true);
            foreach (Attribute Item_Att in EntityAtts)
            {
                if (Item_Att is EntityFieldAttribute)
                {
                    EntityFieldAttribute EntityFieldAtt = (Item_Att as EntityFieldAttribute);
                    EntityFields.Add(
                        new EntityField()
                        {
                            FieldName = EntityFieldAtt.FieldName,
                            IsKey = EntityFieldAtt.IsKey
                        });
                }
            }

            return EntityFields;
        }
    }
}
