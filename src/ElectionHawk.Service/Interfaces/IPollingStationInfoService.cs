
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;


namespace ElectionHawk.Service.Interfaces
{
    
    public interface IPollingStationInfoService:IServiceBase
    {
        Task<int?> InsertAsync(entity.PollingStationInfoEntity entityToInsert);
        Task<entity.PollingStationInfoEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.PollingStationInfoEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.PollingStationInfoEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);


    }
}
