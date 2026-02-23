using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service.Interfaces
{
    public interface IPoliticalPartyService:IServiceBase
    {
        Task<int?> InsertAsync(entity.PoliticalPartyEntity entityToInsert);
        Task<entity.PoliticalPartyEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.PoliticalPartyEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.PoliticalPartyEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
