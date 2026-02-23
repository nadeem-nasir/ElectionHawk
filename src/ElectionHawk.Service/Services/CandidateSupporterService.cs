using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class CandidateSupporterService : ServiceBase, ICandidateSupporterService
    {
        private readonly ICandidateSupporterRepository _candidateSupporterRepository;

        public CandidateSupporterService(ICandidateSupporterRepository candidateSupporterRepository)
        {
            this._candidateSupporterRepository = candidateSupporterRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.CandidateSupporterEntity> GetByIdAsync(int id)
        {
            return await this._candidateSupporterRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.CandidateSupporterEntity>> GetAllAsync()
        {
            return await this._candidateSupporterRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.CandidateSupporterEntity entityToInsert)
        {
            try
            {
                await this._candidateSupporterRepository.InsertAsync(entityToInsert);
                return entityToInsert.CandidateSupporterId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.CandidateSupporterEntity entityToUpdate)
        {
            try
            {
                return await this._candidateSupporterRepository.UpdateAsync(entityToUpdate);

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
                return await this._candidateSupporterRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
