using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class ElectionResultService : ServiceBase, IElectionResultService
    {
        private readonly IElectionResultRepository _electionResultRepository;

        public ElectionResultService(IElectionResultRepository electionResultRepository)
        {
            this._electionResultRepository = electionResultRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.ElectionResultEntity> GetByIdAsync(int id)
        {
            return await this._electionResultRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.ElectionResultEntity>> GetAllAsync()
        {
            return await this._electionResultRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.ElectionResultEntity entityToInsert)
        {
            try
            {
                await this._electionResultRepository.InsertAsync(entityToInsert);
                return entityToInsert.ResultId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.ElectionResultEntity entityToUpdate)
        {
            try
            {
                return await this._electionResultRepository.UpdateAsync(entityToUpdate);

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
                return await this._electionResultRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
