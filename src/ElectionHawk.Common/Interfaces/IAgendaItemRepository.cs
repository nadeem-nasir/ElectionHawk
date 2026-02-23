using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Common.Interfaces
{
   
    public interface IAgendaItemRepository
    {
        Task<int?> InsertAsync(entity.AgendaItemEntity entityToInsert);
        Task<entity.AgendaItemEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.AgendaItemEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.AgendaItemEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
