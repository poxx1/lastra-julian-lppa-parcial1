using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static LastraJulian_LPPA_Parcial1.Models.IndentityBase;

namespace LastraJulian_LPPA_Parcial1.Services
{
        public class BaseDataService<T> : IDataService<T> where T : IdentityBase, new()
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
                Db.Set<T>().Remove(entity);
                Db.SaveChanges();
            }

            public void Delete(int id)
            {
                //Db.Set<int>().Remove(id);
                Db.SaveChanges();
                throw new NotImplementedException();
            }

            public List<T> Get(Expression<Func<T, bool>> whereExpression = null, Func<IQueryable<T>, IOrderedQueryable<T>>
                orderFunction = null, string includeModels = "")
            {
                IQueryable<T> query = Db.Set<T>();

                if (whereExpression != null)
                    query = query.Where(whereExpression);

                var entity = includeModels.Split(separator: new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                query = entity.Aggregate(query, (current, model) => current.Include(model));

                return query.ToList();
            }

            public T GetById(int id)
            {
                throw new NotImplementedException();
            }

            public void Update(T entity)
            {
                //Db.Set<T>().;
                //Db.SaveChanges();
                //return entity;
                throw new NotImplementedException();
            }

            public List<ValidationResult> ValidateModel(T model)
            {
                throw new NotImplementedException();
            }
        }
}