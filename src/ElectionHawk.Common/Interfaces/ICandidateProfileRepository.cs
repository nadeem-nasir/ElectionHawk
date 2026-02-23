using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Common.Interfaces
{
   
    public  interface ICandidateProfileRepository
    {

        Task<int?> InsertAsync(entity.CandidateProfileEntity entityToInsert);
        Task<entity.CandidateProfileEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.CandidateProfileEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.CandidateProfileEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
