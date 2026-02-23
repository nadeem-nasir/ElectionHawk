using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Common.Interfaces
{
    
    public interface IPollingStationBoothResultRepository
    {
        Task<int?> InsertAsync(entity.PollingStationBoothResultEntity entityToInsert);
        Task<entity.PollingStationBoothResultEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.PollingStationBoothResultEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.PollingStationBoothResultEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
