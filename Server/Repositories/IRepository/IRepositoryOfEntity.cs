using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Services.FilterService;

namespace Server.Repositories.IRepository
{
    public interface IRepositoryOfEntity<T>
    {
        Task<List<T>>? GetAll(string filter);
        Task<List<T>>? GetAllFullOptions(PaginationFilterService paginationFilterService);
        Task<T>? GetEntityById(int id);
        Task<bool> CreateEntity(T entity);
        Task<bool> UpdateEntity(int? id, T entity);
        Task<bool> DeleteEntity(int id);
    }
}