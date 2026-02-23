using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;



namespace ElectionHawk.Service.Interfaces
{
   
    public interface IDistrictService:IServiceBase
    {
        Task<int?> InsertAsync(entity.DistrictEntity entityToInsert);
        Task<entity.DistrictEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.DistrictEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.DistrictEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
