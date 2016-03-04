using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _EntityBase;
using _EntityBase.EntityAttributes;

namespace _Implementation_Entities.Entities
{
    [Entity(EntityName = "Ingredient")]
    public class Entity_Ingredient : EntityBase<Entity_Ingredient, EntityKey_Ingredient>
    {
        [EntityField(FieldName = "IngredientID", IsKey = true)]
        public Int64 IngredientID { get; set; }

        [EntityField(FieldName = "RowPropertyID")]
        public Int64 RowPropertyID { get; set; }
    }

    public class EntityKey_Ingredient : EntityKey
    {
        [EntityField(FieldName = "IngredientID")]
        public Int64 IngredientID { get; set; }
    }
}
