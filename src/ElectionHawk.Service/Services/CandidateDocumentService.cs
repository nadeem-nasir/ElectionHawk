using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class CandidateDocumentService : ServiceBase, ICandidateDocumentService
    {
        private readonly ICandidateDocumentRepository _candidateDocumentRepository;

        public CandidateDocumentService(ICandidateDocumentRepository candidateDocumentRepository)
        {
            this._candidateDocumentRepository = candidateDocumentRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.CandidateDocumentEntity> GetByIdAsync(int id)
        {
            return await this._candidateDocumentRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.CandidateDocumentEntity>> GetAllAsync()
        {
            return await this._candidateDocumentRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.CandidateDocumentEntity entityToInsert)
        {
            try
            {
                await this._candidateDocumentRepository.InsertAsync(entityToInsert);
                return entityToInsert.DocumentId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.CandidateDocumentEntity entityToUpdate)
        {
            try
            {
                return await this._candidateDocumentRepository.UpdateAsync(entityToUpdate);

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
                return await this._candidateDocumentRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
