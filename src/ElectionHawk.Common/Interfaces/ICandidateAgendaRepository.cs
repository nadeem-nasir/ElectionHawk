using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Common.Interfaces
{
    
    public interface ICandidateAgendaRepository
    {
        Task<int?> InsertAsync(entity.CandidateAgendaEntity entityToInsert);
        Task<entity.CandidateAgendaEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.CandidateAgendaEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.CandidateAgendaEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
