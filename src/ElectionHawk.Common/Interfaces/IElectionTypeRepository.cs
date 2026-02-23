using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;


namespace ElectionHawk.Common.Interfaces
{
    
    public interface IElectionTypeRepository

    {
        Task<int?> InsertAsync(entity.ElectionTypeEntity entityToInsert);
        Task<entity.ElectionTypeEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.ElectionTypeEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.ElectionTypeEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);


    }
}
