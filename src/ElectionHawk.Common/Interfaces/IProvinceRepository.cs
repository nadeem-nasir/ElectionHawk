using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Common.Interfaces
{
  
    public interface IProvinceRepository
    {
        Task<int?> InsertAsync(entity.ProvinceEntity entityToInsert);
        Task<entity.ProvinceEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.ProvinceEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.ProvinceEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
