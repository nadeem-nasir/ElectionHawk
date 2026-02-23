using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class CandidateConstituencyService : ServiceBase, ICandidateConstituencyService
    {
        private readonly ICandidateConstituencyRepository _candidateConstituencyRepository;

        public CandidateConstituencyService(ICandidateConstituencyRepository candidateConstituencyRepository)
        {
            this._candidateConstituencyRepository = candidateConstituencyRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.CandidateConstituencyEntity> GetByIdAsync(int id)
        {
            return await this._candidateConstituencyRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.CandidateConstituencyEntity>> GetAllAsync()
        {
            return await this._candidateConstituencyRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.CandidateConstituencyEntity entityToInsert)
        {
            try
            {
                await this._candidateConstituencyRepository.InsertAsync(entityToInsert);
                return entityToInsert.ConstituencyId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.CandidateConstituencyEntity entityToUpdate)
        {
            try
            {
                return await this._candidateConstituencyRepository.UpdateAsync(entityToUpdate);

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
                return await this._candidateConstituencyRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
