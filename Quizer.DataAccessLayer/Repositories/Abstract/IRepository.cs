using System;
using System.Collections.Generic;
using System.Text;
using Quizer.DataAccessLayer.Entities;

namespace Quizer.DataAccessLayer.Repositories.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
