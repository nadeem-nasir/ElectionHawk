using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Common.Interfaces
{
   
    public interface IPartyOfficeRepository
    {
        Task<int?> InsertAsync(entity.PartyOfficeEntity entityToInsert);
        Task<entity.PartyOfficeEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.PartyOfficeEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.PartyOfficeEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
