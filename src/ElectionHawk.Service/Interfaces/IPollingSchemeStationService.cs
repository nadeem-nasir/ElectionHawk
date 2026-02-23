using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service.Interfaces
{
   
    public interface IPollingSchemeStationService:IServiceBase
    {
        Task<int?> InsertAsync(entity.PollingSchemeStationEntity entityToInsert);
        Task<entity.PollingSchemeStationEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.PollingSchemeStationEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.PollingSchemeStationEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);



    }
}
