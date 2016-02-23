using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Common;
using EntityBase;
using Factories;
using Interfaces;

namespace ModelBase
{
    [Serializable()]
    public abstract class ModelBase { }

    [Serializable()]
    public abstract class ModelBase<T_Entity, T_EntityKey> : ModelBase
        where T_Entity : EntityBase<T_Entity, T_EntityKey>, new()
        where T_EntityKey : EntityKey, new()
    {
        #region _Variables

        T_Entity mEntity;
        List<RelatedEntity> mRelatedEntities = new List<RelatedEntity>();
        List<RelatedEntity> mRelatedEntityDetails = new List<RelatedEntity>();
        List<RelatedModel> mRelatedModels = new List<RelatedModel>();
        Expression<Func<T_Entity, Boolean>> mLoadPredicate = null;

        Interface_ModelDataAccess<T_Entity, T_EntityKey> mEda;

        #endregion

        #region _Constructor

        protected virtual void Setup()
        {
            this.Setup(null);
        }

        protected virtual void Setup(Expression<Func<T_Entity, Boolean>> LoadPredicate)
        {
            this.mEntity = Activator.CreateInstance<T_Entity>();
            this.mLoadPredicate = LoadPredicate;

            this.mEda = Factory_ModelDataAccess.Create_EntityDataAccess<T_Entity, T_EntityKey>();
        }

        protected void Setup_AddRelatedEntity<T_RelatedEntity, T_RelatedEntityKey>(
            String RelatedEntityName = ""
            , Expression<Func<T_RelatedEntity, Boolean>> LoadPredicate = null)
            where T_RelatedEntity : EntityBase.EntityBase, new()
            where T_RelatedEntityKey : RelatedEntityKey, new()
        {
            RelatedEntity<T_RelatedEntity, T_RelatedEntityKey> RelatedEntity = new RelatedEntity<T_RelatedEntity, T_RelatedEntityKey>();
            RelatedEntity.Setup(RelatedEntityName, LoadPredicate);

            this.mRelatedEntities.Add(RelatedEntity);
        }

        protected void Setup_AddRelatedDetail<T_RelatedEntity, T_RelatedEntityKey>(
            String RelatedEntityName = ""
            , Expression<Func<T_RelatedEntity, Boolean>> LoadPredicate = null)
            where T_RelatedEntity : EntityBase.EntityBase, new()
            where T_RelatedEntityKey : RelatedEntityKey, new()
        {
            RelatedEntityDetails<T_RelatedEntity, T_RelatedEntityKey> RelatedEntityDetail = new RelatedEntityDetails<T_RelatedEntity, T_RelatedEntityKey>();
            RelatedEntityDetail.Setup(RelatedEntityName, LoadPredicate);

            this.mRelatedEntityDetails.Add(RelatedEntityDetail);
        }

        protected void Setup_AddRelatedModel<T_RelatedModel, T_RelatedEntityKey>(
            List<RelatedKey> RelatedKeys = null)
            where T_RelatedModel : ModelBase, new()
            where T_RelatedEntityKey : RelatedEntityKey, new()
        {
            Type EntityType = typeof(T_RelatedModel);
            T_RelatedModel Entity = Activator.CreateInstance<T_RelatedModel>();

            RelatedModel Rm = new RelatedModel<T_RelatedModel, T_RelatedEntityKey>();
        }

        #endregion

        #region  _Methods

        public virtual void New()
        {

        }

        public virtual void Load(T_EntityKey EntityKey)
        {

            //this.mEntity = this.mEda.Load(Keys);
        }

        public virtual void Load(Expression<Func<T_Entity, bool>> LoadPredicate)
        {
            this.mEntity = this.mEda.Load(LoadPredicate);
        }

        public virtual void Save()
        {
            this.mEda.Save(this.mEntity);
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

        public T_RelatedEntity Get_RelatedEntity<T_RelatedEntity>() where T_RelatedEntity : EntityBase.EntityBase, new()
        { return this.Get_RelatedEntity<T_RelatedEntity>(""); }

        public T_RelatedEntity Get_RelatedEntity<T_RelatedEntity>(String EntityName) where T_RelatedEntity : EntityBase.EntityBase, new()
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
