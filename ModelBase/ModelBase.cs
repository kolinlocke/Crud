using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using _Common;
using _EntityBase;
using _Factories;
using _Interfaces;

namespace _ModelBase
{
    [Serializable()]
    public abstract class ModelBase { }

    [Serializable()]
    public abstract class ModelBase<T_Entity> : ModelBase
        where T_Entity : EntityBase<T_Entity>, new()
    {
        public Interface_ModelDataAccess<T_Entity> pModelDataAccess { get; protected set; }
    }

    [Serializable()]
    public abstract class ModelBase<T_Entity, T_EntityKey> : ModelBase<T_Entity>
        where T_Entity : EntityBase<T_Entity, T_EntityKey>, new()
        where T_EntityKey : EntityKey, new()
    {
        #region _Variables

        T_Entity mEntity;
        List<RelatedEntity> mRelatedEntities = new List<RelatedEntity>();
        List<RelatedEntity> mRelatedEntityDetails = new List<RelatedEntity>();
        List<RelatedModel> mRelatedModels = new List<RelatedModel>();
        List<RelatedModel> mRelatedModelDetails = new List<RelatedModel>();
        Expression<Func<T_Entity, Boolean>> mLoadPredicate = null;

        #endregion

        #region _Constructor

        public ModelBase()
        { this.Setup(); }

        protected virtual void Setup()
        { this.Setup(null); }

        protected virtual void Setup(Expression<Func<T_Entity, Boolean>> LoadPredicate)
        {
            this.mEntity = Activator.CreateInstance<T_Entity>();
            this.mLoadPredicate = LoadPredicate;

            this.pModelDataAccess = Factory_ModelDataAccess.Create_EntityDataAccess<T_Entity>();
        }

        protected void Setup_AddRelatedEntity<T_RelatedEntity, T_RelatedEntityKey>(
            String RelatedEntityName = ""
            , Expression<Func<T_RelatedEntity, Boolean>> LoadPredicate = null)
            where T_RelatedEntity : _EntityBase.EntityBase, new()
            where T_RelatedEntityKey : RelatedEntityKey, new()
        {
            RelatedEntity<T_RelatedEntity, T_RelatedEntityKey, T_Entity> RelatedEntity = 
                new RelatedEntity<T_RelatedEntity, T_RelatedEntityKey, T_Entity>();
            RelatedEntity.Setup(this, RelatedEntityName, LoadPredicate);

            this.mRelatedEntities.Add(RelatedEntity);
        }

        protected void Setup_AddRelatedDetail<T_RelatedEntity, T_RelatedEntityKey>(
            String RelatedEntityName = ""
            , Expression<Func<T_RelatedEntity, Boolean>> LoadPredicate = null)
            where T_RelatedEntity : _EntityBase.EntityBase, new()
            where T_RelatedEntityKey : RelatedEntityKey, new()
        {
            RelatedEntityDetails<T_RelatedEntity, T_RelatedEntityKey, T_Entity> RelatedEntityDetail =
                new RelatedEntityDetails<T_RelatedEntity, T_RelatedEntityKey, T_Entity>();
            RelatedEntityDetail.Setup(this, RelatedEntityName, LoadPredicate);

            this.mRelatedEntityDetails.Add(RelatedEntityDetail);
        }

        protected void Setup_AddRelatedModel<T_RelatedModel, T_RelatedEntityKey>(
            List<RelatedKey> RelatedKeys = null)
            where T_RelatedModel : ModelBase, new()
            where T_RelatedEntityKey : RelatedEntityKey, new()
        {
            Type EntityType = typeof(T_RelatedModel);
            T_RelatedModel Entity = Activator.CreateInstance<T_RelatedModel>();

            RelatedModel RelatedModel = new RelatedModel<T_RelatedModel, T_RelatedEntityKey>();
            this.mRelatedModels.Add(RelatedModel);
            
        }

        #endregion

        #region  _Methods

        public virtual void New()
        {
            this.mEntity = new T_Entity();
            this.New_Related();
        }

        void New_Related()
        {
            this.mRelatedEntities.ForEach(O => { O.New(); });
            this.mRelatedEntityDetails.ForEach(O => { O.New(); });
            this.mRelatedModels.ForEach(O => { O.New(); });
            this.mRelatedModelDetails.ForEach(O => { O.New(); });
        }

        public virtual void Load(T_EntityKey EntityKey)
        {
            this.mEntity = this.pModelDataAccess.Load(EntityKey);
            this.Load_Related(EntityKey);
        }

        void Load_Related(T_EntityKey EntityKey)
        { 
            this.mRelatedEntities.ForEach(O => { O.Load(EntityKey); });
            this.mRelatedEntityDetails.ForEach(O => { O.Load(EntityKey); });
            this.mRelatedModels.ForEach(O => { O.Load(EntityKey); });
            this.mRelatedModelDetails.ForEach(O => { O.Load(EntityKey); });            
        }

        public virtual void Save()
        {
            this.pModelDataAccess.Save(this.mEntity);
        }

        public virtual void Delete()
        {

        }

        #endregion

        #region _Properties

        public T_Entity pEntity
        {
            get { return this.mEntity; }
        }

        public T_RelatedEntity Get_RelatedEntity<T_RelatedEntity>() where T_RelatedEntity : _EntityBase.EntityBase, new()
        { return this.Get_RelatedEntity<T_RelatedEntity>(""); }

        public T_RelatedEntity Get_RelatedEntity<T_RelatedEntity>(String EntityName) where T_RelatedEntity : _EntityBase.EntityBase, new()
        {
            RelatedEntity RelatedEntity = null;
            if (EntityName == "")
            {
                RelatedEntity = this.mRelatedEntities.FirstOrDefault(O => O is RelatedEntity<T_RelatedEntity>);
            }
            else
            {
                RelatedEntity =
                    this.mRelatedEntities.FirstOrDefault(O =>
                        O is RelatedEntity<T_RelatedEntity>
                        && EntityHelper.Get_EntityName<T_RelatedEntity>() == EntityName);
            }

            if (RelatedEntity != null)
            { return (RelatedEntity as RelatedEntity<T_RelatedEntity>).pEntity; }
            else
            {
                String ErrorMsg = String.Format("ModelBase.Get_RelatedEntity: Related Entity {0} not found.", typeof(T_RelatedEntity).Name);
                throw new Exception(ErrorMsg);
            }
        }

        public List<RelatedEntity> pRelatedEntities
        {
            get { return this.mRelatedEntities; }
        }

        public List<RelatedEntity> pRelatedEntityDetails
        {
            get { return this.mRelatedEntityDetails; }
        }

        #endregion
    }
}
