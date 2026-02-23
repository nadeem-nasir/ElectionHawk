using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service.Interfaces
{
   
    public interface IPollingStationBoothAgentService:IServiceBase
    {

        Task<int?> InsertAsync(entity.PollingStationBoothAgentEntity entityToInsert);
        Task<entity.PollingStationBoothAgentEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.PollingStationBoothAgentEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.PollingStationBoothAgentEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
