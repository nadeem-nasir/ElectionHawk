using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Common.Interfaces
{
    
    public  interface ICandidateSupporterRepository
    {

        Task<int?> InsertAsync(entity.CandidateSupporterEntity entityToInsert);
        Task<entity.CandidateSupporterEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.CandidateSupporterEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.CandidateSupporterEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
