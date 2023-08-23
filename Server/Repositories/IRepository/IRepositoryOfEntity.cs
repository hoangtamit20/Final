using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Repositories.IRepository
{
    public interface IRepositoryOfEntity<T>
    {
        Task<IEnumerable<T>>? GetAll();
        Task<IEnumerable<T>>? GetAllFullOptions(string filter, string sortBy, int? pageIndex, int? pageSize);
        Task<T>? GetEntityById(int id);
        Task<bool> CreateEntity(T entity);
        Task<bool> UpdateEntity(int? id, T entity);
        Task<bool> DeleteEntity(int id);
    }
}