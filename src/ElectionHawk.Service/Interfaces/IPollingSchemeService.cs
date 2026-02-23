using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Service.Interfaces
{
  
    public interface IPollingSchemeService:IServiceBase
    {
        Task<int?> InsertAsync(entity.PollingSchemeEntity entityToInsert);
        Task<entity.PollingSchemeEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.PollingSchemeEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.PollingSchemeEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
