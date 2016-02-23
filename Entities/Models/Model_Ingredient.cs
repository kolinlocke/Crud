using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using EntityBase;
using Implementation_Entities.Entities;
using ModelBase;

namespace Implementation_Entities.Models
{
    public class Model_Ingredient : ModelBase<Entity_Ingredient, EntityKey_Ingredient>
    {
        public Model_Ingredient()
        {
            this.Setup();

            this.Setup_AddRelatedEntity
                <Entity_RowProperty, RelatedEntityKey_RowProperty>
                ("RowProperty", (O => O.IsActive == true));
        }
    }

    class RelatedEntityKey_RowProperty : RelatedEntityKey<Entity_Ingredient, Entity_RowProperty>
    {
        protected override void Setup()
        {
            this.Setup_AddRelationship(
                this.pEntityParent.GetPropertyInfo(O => O.RowPropertyID)
                , this.pEntityChild.GetPropertyInfo(O => O.RowPropertyID));
        }
    }
}
