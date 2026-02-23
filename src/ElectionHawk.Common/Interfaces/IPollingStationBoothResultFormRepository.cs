using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Common.Interfaces
{
   
    public interface IPollingStationBoothResultFormRepository
    {
        Task<int?> InsertAsync(entity.PollingStationBoothResultFormEntity entityToInsert);
        Task<entity.PollingStationBoothResultFormEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.PollingStationBoothResultFormEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.PollingStationBoothResultFormEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
