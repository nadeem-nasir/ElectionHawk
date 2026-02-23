using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Common.Interfaces
{
   
    public  interface ICandidateConstituencyRepository
    {
        Task<int?> InsertAsync(entity.CandidateConstituencyEntity entityToInsert);
        Task<entity.CandidateConstituencyEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.CandidateConstituencyEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.CandidateConstituencyEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
