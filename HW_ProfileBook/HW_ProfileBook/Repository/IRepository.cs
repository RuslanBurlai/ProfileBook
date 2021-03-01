using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HW_ProfileBook.Repository
{
    public interface IRepository
    {
        IEnumerable<T> GetItems<T>() where T : IEntityBaseForModel, new();
        void AddItem<T>(T item) where T : IEntityBaseForModel, new();
        int DeleteItem<T>(T item) where T : IEntityBaseForModel, new();
    }
}
