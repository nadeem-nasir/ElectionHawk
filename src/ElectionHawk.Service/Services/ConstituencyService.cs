using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
using model = ElectionHawk.Common.Models;
namespace ElectionHawk.Service
{
    public class ConstituencyService : ServiceBase, IConstituencyService
    {
        private readonly IConstituencyRepository _constituencyRepository;

        public ConstituencyService(IConstituencyRepository constituencyRepository)
        {
            this._constituencyRepository = constituencyRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.ConstituencyEntity> GetByIdAsync(int id)
        {
            return await this._constituencyRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.ConstituencyEntity>> GetAllAsync()
        {
            return await this._constituencyRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.ConstituencyEntity entityToInsert)
        {
            try
            {
                await this._constituencyRepository.InsertAsync(entityToInsert);
                return entityToInsert.ConstituencyId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.ConstituencyEntity entityToUpdate)
        {
            try
            {
                return await this._constituencyRepository.UpdateAsync(entityToUpdate);

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
                return await this._constituencyRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Sql bulkcopy and import
        public async Task<int?> SqlBulkCopy(model.ConstituencyImportModel entityToInsert)
        {
            try
            {
                return await this._constituencyRepository.SqlBulkCopy(entityToInsert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        
    }
}
