using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
using model = ElectionHawk.Common.Models;
namespace ElectionHawk.Common.Interfaces
{
  
    public interface IConstituencyRepository
    {

        Task<int?> InsertAsync(entity.ConstituencyEntity entityToInsert);
        Task<entity.ConstituencyEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.ConstituencyEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.ConstituencyEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
        Task<int?> SqlBulkCopy(model.ConstituencyImportModel entityToInsert);

    }
}
