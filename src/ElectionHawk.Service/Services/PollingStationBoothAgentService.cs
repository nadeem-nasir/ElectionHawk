using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class PollingStationBoothAgentService : ServiceBase, IPollingStationBoothAgentService
    {
        private readonly IPollingStationBoothAgentRepository _pollingStationBoothAgentRepository;

        public PollingStationBoothAgentService(IPollingStationBoothAgentRepository pollingStationBoothAgentRepository)
        {
            this._pollingStationBoothAgentRepository = pollingStationBoothAgentRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.PollingStationBoothAgentEntity> GetByIdAsync(int id)
        {
            return await this._pollingStationBoothAgentRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.PollingStationBoothAgentEntity>> GetAllAsync()
        {
            return await this._pollingStationBoothAgentRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.PollingStationBoothAgentEntity entityToInsert)
        {
            try
            {
                await this._pollingStationBoothAgentRepository.InsertAsync(entityToInsert);
                return entityToInsert.PollingBoothAgentId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.PollingStationBoothAgentEntity entityToUpdate)
        {
            try
            {
                return await this._pollingStationBoothAgentRepository.UpdateAsync(entityToUpdate);

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
                return await this._pollingStationBoothAgentRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
