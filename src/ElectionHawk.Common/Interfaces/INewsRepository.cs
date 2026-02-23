using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Common.Interfaces
{
    
    public interface INewsRepository
    {
        Task<int?> InsertAsync(entity.NewsEntity entityToInsert);
        Task<entity.NewsEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.NewsEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.NewsEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
