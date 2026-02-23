using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service.Interfaces
{
    
    public interface ICandidateConstituencyOpponentsService:IServiceBase
    {
        Task<int?> InsertAsync(entity.CandidateConstituencyOpponentsEntity entityToInsert);
        Task<entity.CandidateConstituencyOpponentsEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.CandidateConstituencyOpponentsEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.CandidateConstituencyOpponentsEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
