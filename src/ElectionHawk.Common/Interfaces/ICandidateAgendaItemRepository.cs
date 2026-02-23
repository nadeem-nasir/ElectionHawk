using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Common.Interfaces
{
    
    public interface ICandidateAgendaItemRepository
    {
        Task<int?> InsertAsync(entity.CandidateAgendaItemEntity entityToInsert);
        Task<entity.CandidateAgendaItemEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.CandidateAgendaItemEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.CandidateAgendaItemEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
