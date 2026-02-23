using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class ConstituencyTypeService : ServiceBase, IConstituencyTypeService
    {
        private readonly IConstituencyTypeRepository _constituencyTypeRepository;

        public ConstituencyTypeService(IConstituencyTypeRepository constituencyTypeRepository)
        {
            this._constituencyTypeRepository = constituencyTypeRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.ConstituencyTypeEntity> GetByIdAsync(int id)
        {
            return await this._constituencyTypeRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.ConstituencyTypeEntity>> GetAllAsync()
        {
            return await this._constituencyTypeRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.ConstituencyTypeEntity entityToInsert)
        {
            try
            {
                await this._constituencyTypeRepository.InsertAsync(entityToInsert);
                return entityToInsert.ConstituencyTypeId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.ConstituencyTypeEntity entityToUpdate)
        {
            try
            {
                return await this._constituencyTypeRepository.UpdateAsync(entityToUpdate);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Delete 
        public async Task<bool> DeleteByIdAsync(int id)
        {
            try
            {
                return await this._constituencyTypeRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
