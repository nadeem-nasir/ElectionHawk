using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class VoterListDetailService : ServiceBase, IVoterListDetailService
    {
        private readonly IVoterListDetailRepository _voterListDetailRepository;

        public VoterListDetailService(IVoterListDetailRepository voterListDetailRepository)
        {
            this._voterListDetailRepository = voterListDetailRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.VoterListDetailEntity> GetByIdAsync(int id)
        {
            return await this._voterListDetailRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.VoterListDetailEntity>> GetAllAsync()
        {
            return await this._voterListDetailRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.VoterListDetailEntity entityToInsert)
        {
            try
            {
                await this._voterListDetailRepository.InsertAsync(entityToInsert);
                return entityToInsert.VoterListId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.VoterListDetailEntity entityToUpdate)
        {
            try
            {
                return await this._voterListDetailRepository.UpdateAsync(entityToUpdate);

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
                return await this._voterListDetailRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
