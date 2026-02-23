using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;



namespace ElectionHawk.Common.Interfaces
{
   
    public interface IDistrictRepository
    {
        Task<int?> InsertAsync(entity.DistrictEntity entityToInsert);
        Task<entity.DistrictEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.DistrictEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.DistrictEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
