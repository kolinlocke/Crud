using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using EntityBase;

namespace ModelBase
{
    #region _RelatedEntity

    public class RelatedEntity
    {
        internal RelatedEntity() { }
    }

    public class RelatedEntity<T_RelatedEntity> : RelatedEntity
        where T_RelatedEntity : EntityBase.EntityBase 
    {
        internal RelatedEntity() { }

        public T_RelatedEntity pEntity { get; private set; }
    }

    public class RelatedEntity<T_RelatedEntity, T_RelatedEntityKey> : RelatedEntity<T_RelatedEntity>
        where T_RelatedEntity : EntityBase.EntityBase, new()
        where T_RelatedEntityKey : RelatedEntityKey, new()
    {
        internal RelatedEntity() { }

        protected String mRelatedEntityName = "";
        protected Expression<Func<T_RelatedEntity, Boolean>> mLoadPredicate;
        EntityBase.EntityBase mEntity;

        public virtual void Setup(
            String RelatedEntityName
            , Expression<Func<T_RelatedEntity, Boolean>> LoadPredicate)
        {
            this.mEntity = new T_RelatedEntity();
            this.mLoadPredicate = LoadPredicate;
        }

        public virtual void Load<T_EntityKey>(T_EntityKey EntityKey) where T_EntityKey : EntityKey
        { }

        public T_RelatedEntityKey pRelatedEntityKey
        {
            get { return new T_RelatedEntityKey(); }
        }
    }

    #endregion

    #region _RelatedEntityDetails

    public class RelatedEntityDetails<T_RelatedEntity, T_RelatedEntityKey> : RelatedEntity<T_RelatedEntity, T_RelatedEntityKey>
        where T_RelatedEntity : EntityBase.EntityBase, new()
        where T_RelatedEntityKey : RelatedEntityKey, new()
    {
        internal RelatedEntityDetails() { }

        List<EntityBase.EntityBase> mEntityDetails;

        public override void Setup(string RelatedEntityName, Expression<Func<T_RelatedEntity, bool>> LoadPredicate)
        {
            base.Setup(RelatedEntityName, LoadPredicate);
            this.mEntityDetails = new List<EntityBase.EntityBase>();
        }

        public override void Load<T_EntityKey>(T_EntityKey EntityKey)
        {
            base.Load<T_EntityKey>(EntityKey);
        }
    }

    #endregion

    #region _RelatedModel

    public class RelatedModel
    {
        internal RelatedModel() { }
    }

    public class RelatedModel<T_RelatedModel, T_RelatedEntityKey> : RelatedModel
        where T_RelatedModel : ModelBase, new()
        where T_RelatedEntityKey : RelatedEntityKey, new()
    {
        internal RelatedModel() { }

        ModelBase mModel;

        public void Setup()
        {
            this.mModel = new T_RelatedModel();
        }

        public T_RelatedEntityKey pRelatedEntityKey
        {
            get { return new T_RelatedEntityKey(); }
        }
    }

    #endregion

    #region _RelatedEntityKey

    public struct RelatedKey
    {
        public String ParentKey;
        public String ChildKey;

        public RelatedKey(String ParentKey, String ChildKey)
        {
            this.ParentKey = ParentKey;
            this.ChildKey = ChildKey;
        }
    }

    public abstract class RelatedEntityKey { }

    public abstract class RelatedEntityKey<T_EntityParent, T_EntityChild> : RelatedEntityKey
        where T_EntityParent : EntityBase.EntityBase, new()
        where T_EntityChild : EntityBase.EntityBase, new()
    {
        class Relationships : List<Relationship> { }

        class Relationship
        {
            public PropertyInfo PropertyParent { get; set; }
            public PropertyInfo PropertyChild { get; set; }
        }

        Relationships mRelationships = new Relationships();

        T_EntityParent mEntityParent;
        T_EntityChild mEntityChild;

        public RelatedEntityKey()
        {
            this.mEntityParent = new T_EntityParent();
            this.mEntityChild = new T_EntityChild();

            this.Setup();
        }

        protected abstract void Setup();

        public void Setup_AddRelationship(
            PropertyInfo PropertyParent
            , PropertyInfo PropertyChild)
        {
            this.mRelationships.Add(
                new Relationship()
                {
                    PropertyParent = PropertyParent,
                    PropertyChild = PropertyChild
                });
        }

        protected T_EntityParent pEntityParent
        {
            get { return this.mEntityParent; }
        }

        protected T_EntityChild pEntityChild
        {
            get { return this.mEntityChild; }
        }
    }

    #endregion
}
