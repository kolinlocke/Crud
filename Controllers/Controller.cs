using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using _EntityBase;
using _ModelBase;
using _Implementation_Entities.Entities;
using _Implementation_Models.Models;

namespace _Controller
{
    public class Controller
    {
        public void Test()
        {
            //Model_Ingredient Ing = new Model_Ingredient();
            //Ing.Setup();

            //Entity_RowProperty Rp = new Entity_RowProperty();            
            //Rp.Load(O => O.);

            //List<Model_Ingredient> List = new List<Model_Ingredient>();
            ////List.AsQueryable().Where(O => O.Entity.IngredientID == 1);
            //List.AsQueryable().Where(O => O.Get_RelatedEntity<Entity_RowProperty>().IsActive);

            Model_Ingredient Model_I = new Model_Ingredient();
            Model_I.Load(new EntityKey_Ingredient() { IngredientID = 1 });


            //ModelHelper.ModelKeys<Model_Ingredient> Keys = new ModelHelper.ModelKeys<Model_Ingredient>();
            //Keys.Add(() => I.pEntity, 1);

            //I.Load(

            //Entity_RowProperty Rp = new Entity_RowProperty();
            //Rp.Load(O => O.IsActive == true);

            //String Name = EntityHelper.Get_EntityName<Entity_RowProperty>();
            //Debugger.Break();
        }
    }
}
