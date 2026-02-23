using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Service.Interfaces
{
    
    public interface IExpenseService:IServiceBase
    {
        Task<int?> InsertAsync(entity.ExpenseEntity entityToInsert);
        Task<entity.ExpenseEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.ExpenseEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.ExpenseEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
