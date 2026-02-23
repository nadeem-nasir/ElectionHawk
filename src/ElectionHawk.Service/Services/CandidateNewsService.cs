using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class CandidateNewsService : ServiceBase, ICandidateNewsService
    {
        private readonly ICandidateNewsRepository _candidateNewsRepository;

        public CandidateNewsService(ICandidateNewsRepository candidateNewsRepository)
        {
            this._candidateNewsRepository = candidateNewsRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.CandidateNewsEntity> GetByIdAsync(int id)
        {
            return await this._candidateNewsRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.CandidateNewsEntity>> GetAllAsync()
        {
            return await this._candidateNewsRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.CandidateNewsEntity entityToInsert)
        {
            try
            {
                await this._candidateNewsRepository.InsertAsync(entityToInsert);
                return entityToInsert.CandidateNewsId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.CandidateNewsEntity entityToUpdate)
        {
            try
            {
                return await this._candidateNewsRepository.UpdateAsync(entityToUpdate);

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
                return await this._candidateNewsRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
