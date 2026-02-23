using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class CandidateSMSService : ServiceBase, ICandidateSMSService
    {
        private readonly ICandidateSMSRepository _candidateSMSRepository;

        public CandidateSMSService(ICandidateSMSRepository candidateSMSRepository)
        {
            this._candidateSMSRepository = candidateSMSRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.CandidateSMSEntity> GetByIdAsync(int id)
        {
            return await this._candidateSMSRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.CandidateSMSEntity>> GetAllAsync()
        {
            return await this._candidateSMSRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.CandidateSMSEntity entityToInsert)
        {
            try
            {
                await this._candidateSMSRepository.InsertAsync(entityToInsert);
                return entityToInsert.CandidateSMSId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.CandidateSMSEntity entityToUpdate)
        {
            try
            {
                return await this._candidateSMSRepository.UpdateAsync(entityToUpdate);

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
                return await this._candidateSMSRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
