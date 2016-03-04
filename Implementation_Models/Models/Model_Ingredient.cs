using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _Common;
using _ModelBase;
using _Implementation_Entities.Entities;

namespace _Implementation_Models.Models
{
    public class Model_Ingredient : ModelBase<Entity_Ingredient, EntityKey_Ingredient>
    {
        protected override void Setup()
        {
            base.Setup();

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
