using System.Threading.Tasks;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using jooneliweb.Models;

namespace jooneliweb.Services.Interfaces
{
    public interface IMongoRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);

        Task<List<T>> GetAllSortedByDateAsync();
        Task CreateAsync(T entity);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);
    }
}
