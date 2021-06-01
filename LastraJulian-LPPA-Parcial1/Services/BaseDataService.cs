using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LastraJulian_LPPA_Parcial1.Models;

namespace LastraJulian_LPPA_Parcial1.Services
{
        public class BaseDataService<T> : IDataService<T> where T : IndentityBase, new()
        {
            protected MyDbContext Db;

            public BaseDataService()
            {
                this.Db = new MyDbContext();
            }

            public T Create(T entity)
            {
                Db.Set<T>().Add(entity);
                Db.SaveChanges();
                return entity;
            }

            public void Delete(T entity)
            {
                Db.Set<T>().Attach(entity);
                Db.Set<T>().Remove(entity);
                Db.SaveChanges();
            }

            public void Delete(int id)
            {
                var entity = GetById(id);
                this.Delete(entity);
            }
            
            public List<T> Get(Expression<Func<T, bool>> whereExpression = null, Func<IQueryable<T>, IOrderedQueryable<T>>
                orderFunction = null, string includeModels = "")
            {
                IQueryable<T> query = Db.Set<T>();

                if (whereExpression != null)
                    query = query.Where(whereExpression);

                var entity = includeModels.Split(separator: new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                query = entity.Aggregate(query, (current, model) => current.Include(model));

            if (orderFunction != null)
                query = orderFunction(query);   

                return query.ToList();
            }

            public T GetById(int id)
            {
                return Db.Set<T>().SingleOrDefault(x => x.Id == id);
            }

            public void Update(T entity)
            {
                Db.Entry(entity).State = EntityState.Modified;
                Db.SaveChanges();
            }

            public void Update(int id)
            {
                var entity = GetById(id);
                this.Update(entity);
            }

        public List<ValidationResult> ValidateModel(T model)
            {
                throw new NotImplementedException();
            }
        }
}
