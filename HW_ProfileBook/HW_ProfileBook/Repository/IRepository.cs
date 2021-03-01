using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HW_ProfileBook.Repository
{
    public interface IRepository
    {
        //Task<int> InsertAsync<T>(T entity) where T : IEntityBaseForModel, new();

        //Task<int> UpdateAsync<T>(T entity) where T : IEntityBaseForModel, new();

        //Task<int> DeleteAsync<T>(T entity) where T : IEntityBaseForModel, new();

        //Task<List<T>> GetAllAsync<T>() where T : IEntityBaseForModel, new();

        IEnumerable<T> GetItems<T>() where T : IEntityBaseForModel, new();
        void AddItem<T>(T item) where T : IEntityBaseForModel, new();
        void UpdateItem<T>(T item) where T : IEntityBaseForModel, new();
        int DeleteItem<T>(T item) where T : IEntityBaseForModel, new();
        int GetId<T>(string userLogin, string userPassword) where T : IEntityBaseForModel, new();
        bool GetSameUser<T>(string login) where T : IEntityBaseForModel, new();
    }
}
