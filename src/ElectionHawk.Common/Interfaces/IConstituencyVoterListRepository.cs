using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;



namespace ElectionHawk.Common.Interfaces
{
    
    public interface IConstituencyVoterListRepository
    {
        Task<int?> InsertAsync(entity.ConstituencyVoterListEntity entityToInsert);
        Task<entity.ConstituencyVoterListEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.ConstituencyVoterListEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.ConstituencyVoterListEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);


    }
}
