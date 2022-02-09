using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Dados.Contracts
{
    public interface IBaseRepository<T>
        where T : class
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(int Id);

        List<T> GetAll();
        T GetById(int Id);
    }
}
