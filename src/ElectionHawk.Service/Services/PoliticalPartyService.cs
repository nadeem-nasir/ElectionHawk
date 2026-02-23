using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class PoliticalPartyService : ServiceBase, IPoliticalPartyService
    {
        private readonly IPoliticalPartyRepository _politicalPartyRepository;

        public PoliticalPartyService(IPoliticalPartyRepository politicalPartyRepository)
        {
            this._politicalPartyRepository = politicalPartyRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.PoliticalPartyEntity> GetByIdAsync(int id)
        {
            return await this._politicalPartyRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.PoliticalPartyEntity>> GetAllAsync()
        {
            return await this._politicalPartyRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.PoliticalPartyEntity entityToInsert)
        {
            try
            {
                await this._politicalPartyRepository.InsertAsync(entityToInsert);
                return entityToInsert.PoliticalPartyId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.PoliticalPartyEntity entityToUpdate)
        {
            try
            {
                return await this._politicalPartyRepository.UpdateAsync(entityToUpdate);

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
                return await this._politicalPartyRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
