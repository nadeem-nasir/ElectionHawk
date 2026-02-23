using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Service.Interfaces
{
   
    public interface IProfileTypeService:IServiceBase
    {
        Task<int?> InsertAsync(entity.ProfileTypeEntity entityToInsert);
        Task<entity.ProfileTypeEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.ProfileTypeEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.ProfileTypeEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
