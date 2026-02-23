using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Service.Interfaces
{
    
    public interface ICategoryService:IServiceBase
    {
        Task<int?> InsertAsync(entity.CategoryEntity entityToInsert);
        Task<entity.CategoryEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.CategoryEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.CategoryEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
