using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Common.Interfaces
{
    
    public interface IConstituencyTypeRepository
    {
        Task<int?> InsertAsync(entity.ConstituencyTypeEntity entityToInsert);
        Task<entity.ConstituencyTypeEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.ConstituencyTypeEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.ConstituencyTypeEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);


    }
}
