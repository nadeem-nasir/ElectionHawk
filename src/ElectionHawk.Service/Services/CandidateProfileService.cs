using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class CandidateProfileService : ServiceBase, ICandidateProfileService
    {
        private readonly ICandidateProfileRepository _candidateProfileRepository;

        public CandidateProfileService(ICandidateProfileRepository candidateProfileRepository)
        {
            this._candidateProfileRepository = candidateProfileRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.CandidateProfileEntity> GetByIdAsync(int id)
        {
            return await this._candidateProfileRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.CandidateProfileEntity>> GetAllAsync()
        {
            return await this._candidateProfileRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.CandidateProfileEntity entityToInsert)
        {
            try
            {
                await this._candidateProfileRepository.InsertAsync(entityToInsert);
                return entityToInsert.CandidateProfileId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.CandidateProfileEntity entityToUpdate)
        {
            try
            {
                return await this._candidateProfileRepository.UpdateAsync(entityToUpdate);

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
                return await this._candidateProfileRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
