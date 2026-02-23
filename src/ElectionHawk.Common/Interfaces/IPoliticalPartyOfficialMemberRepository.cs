using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Common.Interfaces
{
   
    public  interface IPoliticalPartyOfficialMemberRepository
    {
        Task<int?> InsertAsync(entity.PoliticalPartyOfficialMemberEntity entityToInsert);
        Task<entity.PoliticalPartyOfficialMemberEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.PoliticalPartyOfficialMemberEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.PoliticalPartyOfficialMemberEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
