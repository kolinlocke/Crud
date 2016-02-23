using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityBase;
using EntityBase.EntityAttributes;

namespace Implementation_Entities.Entities
{
    [Entity(EntityName = "RowProperty")]
    public class Entity_RowProperty : EntityBase<Entity_RowProperty, EntityKey_RowProperty>
    {
        [EntityField(FieldName = "RowPropertyID", IsKey = true)]
        public Int64 RowPropertyID { get; set; }

        [EntityField(FieldName = "Code")]
        public String Code { get; set; }

        [EntityField(FieldName = "Name")]
        public String Name { get; set; }

        [EntityField(FieldName = "Desc")]
        public String Desc { get; set; }

        [EntityField(FieldName = "IsActive")]
        public Boolean IsActive { get; set; }

        [EntityField(FieldName = "Remarks")]
        public String Remarks { get; set; }

        [EntityField(FieldName = "DateCreated")]
        public DateTime DateCreated { get; set; }

        [EntityField(FieldName = "DateUpdated")]
        public DateTime DateUpdated { get; set; }
    }

    public class EntityKey_RowProperty : EntityKey
    {
        [EntityField(FieldName = "RowPropertyID")]
        public Int64 RowPropertyID { get; set; }
    }
}
