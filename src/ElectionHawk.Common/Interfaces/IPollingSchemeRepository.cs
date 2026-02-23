using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Common.Interfaces
{
  
    public interface IPollingSchemeRepository
    {
        Task<int?> InsertAsync(entity.PollingSchemeEntity entityToInsert);
        Task<entity.PollingSchemeEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.PollingSchemeEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.PollingSchemeEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
