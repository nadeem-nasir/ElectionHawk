using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class PoliticalPartyDesignationService : ServiceBase, IPoliticalPartyDesignationService
    {
        private readonly IPoliticalPartyDesignationRepository _politicalPartyDesignationRepository;

        public PoliticalPartyDesignationService(IPoliticalPartyDesignationRepository politicalPartyDesignationRepository)
        {
            this._politicalPartyDesignationRepository = politicalPartyDesignationRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.PoliticalPartyDesignationEntity> GetByIdAsync(int id)
        {
            return await this._politicalPartyDesignationRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.PoliticalPartyDesignationEntity>> GetAllAsync()
        {
            return await this._politicalPartyDesignationRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.PoliticalPartyDesignationEntity entityToInsert)
        {
            try
            {
                await this._politicalPartyDesignationRepository.InsertAsync(entityToInsert);
                return entityToInsert.DesignationId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.PoliticalPartyDesignationEntity entityToUpdate)
        {
            try
            {
                return await this._politicalPartyDesignationRepository.UpdateAsync(entityToUpdate);

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
                return await this._politicalPartyDesignationRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
