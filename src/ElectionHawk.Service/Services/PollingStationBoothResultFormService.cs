using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class PollingStationBoothResultFormService : ServiceBase, IPollingStationBoothResultFormService
    {
        private readonly IPollingStationBoothResultFormRepository _pollingStationBoothResultFormRepository;

        public PollingStationBoothResultFormService(IPollingStationBoothResultFormRepository pollingStationBoothResultFormRepository)
        {
            this._pollingStationBoothResultFormRepository = pollingStationBoothResultFormRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.PollingStationBoothResultFormEntity> GetByIdAsync(int id)
        {
            return await this._pollingStationBoothResultFormRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.PollingStationBoothResultFormEntity>> GetAllAsync()
        {
            return await this._pollingStationBoothResultFormRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.PollingStationBoothResultFormEntity entityToInsert)
        {
            try
            {
                await this._pollingStationBoothResultFormRepository.InsertAsync(entityToInsert);
                return entityToInsert.PollingBoothResultFormId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.PollingStationBoothResultFormEntity entityToUpdate)
        {
            try
            {
                return await this._pollingStationBoothResultFormRepository.UpdateAsync(entityToUpdate);

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
                return await this._pollingStationBoothResultFormRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
