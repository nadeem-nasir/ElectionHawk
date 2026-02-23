using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Common.Interfaces
{
    
    public interface ICandidateDocumentRepository 
    {
        Task<int?> InsertAsync(entity.CandidateDocumentEntity entityToInsert);
        Task<entity.CandidateDocumentEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.CandidateDocumentEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.CandidateDocumentEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
