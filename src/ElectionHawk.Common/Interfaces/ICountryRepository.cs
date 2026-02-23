using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Common.Interfaces
{
    
    public interface ICountryRepository : IRepositoryBase
    {
        Task<int?> InsertAsync(entity.CountryEntity entityToInsert);
        Task<entity.CountryEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.CountryEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.CountryEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
