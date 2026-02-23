using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class PoliticalPartyOfficialMemberService : ServiceBase, IPoliticalPartyOfficialMemberService
    {
        private readonly IPoliticalPartyOfficialMemberRepository _politicalPartyOfficialMemberRepository;

        public PoliticalPartyOfficialMemberService(IPoliticalPartyOfficialMemberRepository politicalPartyOfficialMemberRepository)
        {
            this._politicalPartyOfficialMemberRepository = politicalPartyOfficialMemberRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.PoliticalPartyOfficialMemberEntity> GetByIdAsync(int id)
        {
            return await this._politicalPartyOfficialMemberRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.PoliticalPartyOfficialMemberEntity>> GetAllAsync()
        {
            return await this._politicalPartyOfficialMemberRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.PoliticalPartyOfficialMemberEntity entityToInsert)
        {
            try
            {
                await this._politicalPartyOfficialMemberRepository.InsertAsync(entityToInsert);
                return entityToInsert.OfficialMemberProfileId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.PoliticalPartyOfficialMemberEntity entityToUpdate)
        {
            try
            {
                return await this._politicalPartyOfficialMemberRepository.UpdateAsync(entityToUpdate);

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
                return await this._politicalPartyOfficialMemberRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
