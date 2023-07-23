using Microsoft.EntityFrameworkCore.ChangeTracking;
using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        IList<T> GetAll();
        T? GetById(int id);
        
        void Create(T entity);
        void Update(int id, T entity);
        void Delete(T entity);
    }
}
