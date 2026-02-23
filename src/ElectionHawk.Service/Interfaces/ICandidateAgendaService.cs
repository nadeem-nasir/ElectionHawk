using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service.Interfaces
{
    
    public interface ICandidateAgendaService:IServiceBase
    {
        Task<int?> InsertAsync(entity.CandidateAgendaEntity entityToInsert);
        Task<entity.CandidateAgendaEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.CandidateAgendaEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.CandidateAgendaEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
