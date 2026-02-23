using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class ConstituencyVoterListService : ServiceBase, IConstituencyVoterListService
    {
        private readonly IConstituencyVoterListRepository _constituencyVoterListRepository;

        public ConstituencyVoterListService(IConstituencyVoterListRepository constituencyVoterListRepository)
        {
            this._constituencyVoterListRepository = constituencyVoterListRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.ConstituencyVoterListEntity> GetByIdAsync(int id)
        {
            return await this._constituencyVoterListRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.ConstituencyVoterListEntity>> GetAllAsync()
        {
            return await this._constituencyVoterListRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.ConstituencyVoterListEntity entityToInsert)
        {
            try
            {
                await this._constituencyVoterListRepository.InsertAsync(entityToInsert);
                return entityToInsert.VoterListId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.ConstituencyVoterListEntity entityToUpdate)
        {
            try
            {
                return await this._constituencyVoterListRepository.UpdateAsync(entityToUpdate);

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
                return await this._constituencyVoterListRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
