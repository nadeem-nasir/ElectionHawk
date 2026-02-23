using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Service.Interfaces
{
   
    public  interface ICandidateProfileService:IServiceBase
    {

        Task<int?> InsertAsync(entity.CandidateProfileEntity entityToInsert);
        Task<entity.CandidateProfileEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.CandidateProfileEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.CandidateProfileEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
