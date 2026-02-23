using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;


namespace ElectionHawk.Common.Interfaces
{
   
    public interface IElectionRepository
    {
        Task<int?> InsertAsync(entity.ElectionEntity entityToInsert);
        Task<entity.ElectionEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.ElectionEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.ElectionEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);


    }
}
