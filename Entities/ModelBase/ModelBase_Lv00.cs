using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lv02_Entities.Entities;

namespace Lv02_Entities.ModelBase
{
    public abstract class ModelBase_Lv00
    {
        #region _Variables

        protected RowProperty mRowProperty;

        #endregion

        #region _Properties
        
        public RowProperty pRowProperty
        { get { return this.mRowProperty; } }

        #endregion

        #region _Constructor

        public ModelBase_Lv00() { }

        public virtual void Setup(RowProperty RowProperty)
        {
            this.mRowProperty = RowProperty;
        }

        #endregion
    }
}
