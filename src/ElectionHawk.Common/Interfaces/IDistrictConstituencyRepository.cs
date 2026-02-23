using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Common.Interfaces
{
    
    public interface IDistrictConstituencyRepository
    {
       Task<int?> InsertAsync(entity.DistrictConstituencyEntity entityToInsert);
        Task<entity.DistrictConstituencyEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.DistrictConstituencyEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.DistrictConstituencyEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
