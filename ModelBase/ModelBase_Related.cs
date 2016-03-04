using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using _EntityBase;

namespace _ModelBase
{
    #region _RelatedEntity

    public abstract class RelatedEntity
    {
        internal RelatedEntity() { }

        public virtual void New() { }

        public virtual void Load<T_EntityKey>(T_EntityKey EntityKey)
            where T_EntityKey : EntityKey, new() { }
    }

    public abstract class RelatedEntity<T_RelatedEntity> : RelatedEntity
        where T_RelatedEntity : EntityBase, new()
    {
        internal RelatedEntity() { }

        public virtual void Setup_Entity()
        { this.pEntity = new T_RelatedEntity(); }

        public virtual T_RelatedEntity pEntity { get; protected set; }
    }

    public class RelatedEntity<T_RelatedEntity, T_RelatedEntityKey, T_ParentEntity> : RelatedEntity<T_RelatedEntity>
        where T_RelatedEntity : EntityBase, new()
        where T_RelatedEntityKey : RelatedEntityKey, new()
        where T_ParentEntity : EntityBase<T_ParentEntity>, new()
    {
        internal RelatedEntity() { }

        protected ModelBase<T_ParentEntity> mModelBase_Parent;
        protected String mRelatedEntityName = "";
        protected Expression<Func<T_RelatedEntity, Boolean>> mLoadPredicate;

        public virtual void Setup(
            ModelBase<T_ParentEntity> ModelBase_Parent
            , String RelatedEntityName
            , Expression<Func<T_RelatedEntity, Boolean>> LoadPredicate)
        {
            this.mModelBase_Parent = ModelBase_Parent;
            this.mRelatedEntityName = RelatedEntityName;
            this.mLoadPredicate = LoadPredicate;
            this.Setup_Entity();
        }

        public override void New()
        { this.pEntity = new T_RelatedEntity(); }

        public override void Load<T_EntityKey>(T_EntityKey EntityKey)
        {
            this.pEntity =
                this.mModelBase_Parent
                    .pModelDataAccess
                    .Load_RelatedEntity<T_RelatedEntity, T_EntityKey>(EntityKey);
        }

        public T_RelatedEntityKey pRelatedEntityKey
        {
            get { return new T_RelatedEntityKey(); }
        }
    }

    #endregion

    #region _RelatedEntityDetails

    public class RelatedEntityDetails<T_RelatedEntity, T_RelatedEntityKey, T_ParentEntity> : RelatedEntity<T_RelatedEntity, T_RelatedEntityKey, T_ParentEntity>
        where T_RelatedEntity : EntityBase, new()
        where T_RelatedEntityKey : RelatedEntityKey, new()
        where T_ParentEntity : EntityBase<T_ParentEntity>, new()
    {
        internal RelatedEntityDetails() { }

        public override void Setup(ModelBase<T_ParentEntity> ModelBase_Parent, string RelatedEntityName, Expression<Func<T_RelatedEntity, bool>> LoadPredicate)
        {
            base.Setup(ModelBase_Parent, RelatedEntityName, LoadPredicate);
            this.pEntityDetails = new List<T_RelatedEntity>();
        }

        public override void Setup_Entity() { }

        public override void New()
        { this.pEntityDetails = new List<T_RelatedEntity>(); }

        public override void Load<T_EntityKey>(T_EntityKey EntityKey)
        { }

        public List<T_RelatedEntity> pEntityDetails
        {
            get;
            protected set;
        }

        public override T_RelatedEntity pEntity
        {
            get { return null; }
            protected set { base.pEntity = value; }
        }
    }

    #endregion

    #region _RelatedModel

    public class RelatedModel
    {
        internal RelatedModel() { }

        public virtual void New() { }

        public virtual void Load<T_EntityKey>(T_EntityKey EntityKey) 
            where T_EntityKey : EntityKey { }
    }

    public class RelatedModel<T_RelatedModel> : RelatedModel
        where T_RelatedModel : ModelBase, new()
    {
        internal RelatedModel() { }

        public virtual void Setup_Model()
        { this.pModel = new T_RelatedModel(); }

        public virtual T_RelatedModel pModel { get; protected set; }
    }

    public class RelatedModel<T_RelatedModel, T_RelatedEntityKey> : RelatedModel<T_RelatedModel>
        where T_RelatedModel : ModelBase, new()
        where T_RelatedEntityKey : RelatedEntityKey, new()
    {
        internal RelatedModel() { }

        protected String mRelatedEntityName;
        protected Expression<Func<T_RelatedModel, bool>> mLoadPredicate;

        public virtual void Setup(string RelatedEntityName, Expression<Func<T_RelatedModel, bool>> LoadPredicate)
        {
            this.mRelatedEntityName = RelatedEntityName;
            this.mLoadPredicate = LoadPredicate;
            this.Setup_Model();
        }

        public override void New()
        { this.pModel = new T_RelatedModel(); }

        public override void Load<T_EntityKey>(T_EntityKey EntityKey)
        { }

        public T_RelatedEntityKey pRelatedEntityKey
        {
            get { return new T_RelatedEntityKey(); }
        }
    }

    #endregion

    #region _RelatedModelDetails

    public class RelatedModelDetails<T_RelatedModel, T_RelatedEntityKey> : RelatedModel<T_RelatedModel, T_RelatedEntityKey>
        where T_RelatedModel : ModelBase, new()
        where T_RelatedEntityKey : RelatedEntityKey, new()
    {
        public override void Setup(string RelatedEntityName, Expression<Func<T_RelatedModel, bool>> LoadPredicate)
        {
            base.Setup(RelatedEntityName, LoadPredicate);
            this.pModels = new List<T_RelatedModel>();
        }

        public override void Setup_Model() { }

        public override void New()
        { this.pModels = new List<T_RelatedModel>(); }

        public override void Load<T_EntityKey>(T_EntityKey EntityKey)
        { }

        public List<T_RelatedModel> pModels
        {
            get;
            protected set;
        }

        public override T_RelatedModel pModel
        {
            get { return null; }
            protected set { base.pModel = value; }
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
        where T_EntityParent : _EntityBase.EntityBase, new()
        where T_EntityChild : _EntityBase.EntityBase, new()
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
