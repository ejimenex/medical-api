
using BussinesLogic.Interface;
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BussinesLogic.Service
{
    public abstract class BaseService<T> : IBaseService<T> where T : BaseClass, new()
    {
        protected readonly IRepository<T> _repository;
        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public virtual int Create(T entity)
        {
            try
            {
                return _repository.Create(entity);
            }
            catch (Exception e)
            {

                throw new ArgumentException(e.Message);
            }
           
        }

        public virtual void Delete(int Id)
        {
            try
            {
                 _repository.Delete(Id);
            }
            catch (Exception e)
            {

                throw new ArgumentException(e.Message);
            }
        }

        public virtual IQueryable<T> FindAll()
        {
            return _repository.FindAll();
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _repository.FindByCondition(expression);
        }

        public virtual T GetOne(int Id)
        {
            return _repository.GetOne(Id);
        }

        public virtual T Update(T entity)
        {
            return _repository.Update(entity);
        }
        public bool Exist(Expression<Func<T, bool>> expression)
        {
            return _repository.Exist(expression);
        }
    }
}
