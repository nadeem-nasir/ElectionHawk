using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class PollingSchemeService : ServiceBase, IPollingSchemeService
    {
        private readonly IPollingSchemeRepository _pollingSchemeRepository;

        public PollingSchemeService(IPollingSchemeRepository pollingSchemeRepository)
        {
            this._pollingSchemeRepository = pollingSchemeRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.PollingSchemeEntity> GetByIdAsync(int id)
        {
            return await this._pollingSchemeRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.PollingSchemeEntity>> GetAllAsync()
        {
            return await this._pollingSchemeRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.PollingSchemeEntity entityToInsert)
        {
            try
            {
                await this._pollingSchemeRepository.InsertAsync(entityToInsert);
                return entityToInsert.PollingSchemeId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.PollingSchemeEntity entityToUpdate)
        {
            try
            {
                return await this._pollingSchemeRepository.UpdateAsync(entityToUpdate);

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
                return await this._pollingSchemeRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
