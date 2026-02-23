using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Common.Interfaces
{
   
    public interface IPollingStationBoothAgentRepository
    {

        Task<int?> InsertAsync(entity.PollingStationBoothAgentEntity entityToInsert);
        Task<entity.PollingStationBoothAgentEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.PollingStationBoothAgentEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.PollingStationBoothAgentEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
