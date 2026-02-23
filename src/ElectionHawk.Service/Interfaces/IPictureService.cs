using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service.Interfaces
{

    public interface IPictureService:IServiceBase
    {
        Task<int?> InsertAsync(entity.PictureEntity entityToInsert);
        Task<entity.PictureEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.PictureEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.PictureEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
