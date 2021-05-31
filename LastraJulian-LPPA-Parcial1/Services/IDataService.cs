using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace LastraJulian_LPPA_Parcial1.Services
{
     public interface IDataService<T>
    {
        List<ValidationResult> ValidateModel(T model);
        List<T> Get(Expression<Func<T, bool>> whereExpression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunction = null,
            string includeModels = "");
        T GetById(int id);
        T Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}
