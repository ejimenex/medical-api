using Entities;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Repo
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : BaseClass,new()
    {
        protected MedicalContext RepositoryContext { get; set; }
        protected readonly DbSet<T> entities;
        public RepositoryBase(MedicalContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
            entities = RepositoryContext.Set<T>();
        }
        public virtual int Create(T entity)
        {
            //this.RepositoryContext.Set<T>().Add(entity);
            entity.Version = 1;
            entity.CreatedDate = DateTime.Now;
            entity.IsActive = true;
            var result = entities.Add(entity);
            this.RepositoryContext.SaveChanges();
            return Convert.ToInt32(result.Property("Id").CurrentValue.ToString());
        }

        public virtual void Delete(int Id)
        {
            var entity = this.GetOne(Id);
            entity.IsActive = false;
            this.Update(entity);
        }

        public virtual IQueryable<T> FindAll()
        {
            return this.entities.Where(c=> c.IsActive).AsNoTracking();
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public virtual T GetOne(int Id)
        {
           return this.RepositoryContext.Set<T>().Find(Id);
        }

        public virtual T Update(T entity)
        {
            entity.Version += 1;
            entity.ModifiedDate = DateTime.Now;
          this.RepositoryContext.Set<T>().Update(entity);
            this.RepositoryContext.SaveChanges();
            return entity;
        }

        public bool Exist(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Any(expression);
        }
    }
}
