using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Common.Interfaces
{
   
    public interface IPollingSchemeStationRepository
    {
        Task<int?> InsertAsync(entity.PollingSchemeStationEntity entityToInsert);
        Task<entity.PollingSchemeStationEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.PollingSchemeStationEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.PollingSchemeStationEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);



    }
}
