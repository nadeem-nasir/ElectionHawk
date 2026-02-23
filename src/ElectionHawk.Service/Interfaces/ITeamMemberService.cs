using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;


namespace ElectionHawk.Service.Interfaces
{
    
    public interface ITeamMemberService:IServiceBase
    {
        Task<int?> InsertAsync(entity.TeamMemberEntity entityToInsert);
        Task<entity.TeamMemberEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.TeamMemberEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.TeamMemberEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
