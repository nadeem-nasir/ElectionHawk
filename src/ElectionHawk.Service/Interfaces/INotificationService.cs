using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Service.Interfaces
{
   
    public  interface INotificationService:IServiceBase
    {
        Task<int?> InsertAsync(entity.NotificationEntity entityToInsert);
        Task<entity.NotificationEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.NotificationEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.NotificationEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);


    }
}
