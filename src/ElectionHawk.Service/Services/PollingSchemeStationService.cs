using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class PollingSchemeStationService : ServiceBase, IPollingSchemeStationService
    {
        private readonly IPollingSchemeStationRepository _pollingSchemeStationRepository;

        public PollingSchemeStationService(IPollingSchemeStationRepository pollingSchemeStationRepository)
        {
            this._pollingSchemeStationRepository = pollingSchemeStationRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.PollingSchemeStationEntity> GetByIdAsync(int id)
        {
            return await this._pollingSchemeStationRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.PollingSchemeStationEntity>> GetAllAsync()
        {
            return await this._pollingSchemeStationRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.PollingSchemeStationEntity entityToInsert)
        {
            try
            {
                await this._pollingSchemeStationRepository.InsertAsync(entityToInsert);
                return entityToInsert.StationId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.PollingSchemeStationEntity entityToUpdate)
        {
            try
            {
                return await this._pollingSchemeStationRepository.UpdateAsync(entityToUpdate);

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
                return await this._pollingSchemeStationRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
