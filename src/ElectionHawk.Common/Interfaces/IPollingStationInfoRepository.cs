using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;


namespace ElectionHawk.Common.Interfaces
{
    
    public interface IPollingStationInfoRepository
    {
        Task<int?> InsertAsync(entity.PollingStationInfoEntity entityToInsert);
        Task<entity.PollingStationInfoEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.PollingStationInfoEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.PollingStationInfoEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);


    }
}
