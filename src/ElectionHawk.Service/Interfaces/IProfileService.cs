using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Service.Interfaces
{
    
    public interface IProfileService:IServiceBase
    {
        Task<int?> InsertAsync(entity.ProfileEntity entityToInsert);
        Task<entity.ProfileEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.ProfileEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.ProfileEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
