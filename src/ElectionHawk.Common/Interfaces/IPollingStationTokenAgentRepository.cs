using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Common.Interfaces
{
    
    public interface IPollingStationTokenAgentRepository
    {

        Task<int?> InsertAsync(entity.PollingStationTokenAgentEntity entityToInsert);
        Task<entity.PollingStationTokenAgentEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.PollingStationTokenAgentEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.PollingStationTokenAgentEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
