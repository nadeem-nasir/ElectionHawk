using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class DistrictConstituencyService : ServiceBase, IDistrictConstituencyService
    {
        private readonly IDistrictConstituencyRepository _districtConstituencyRepository;

        public DistrictConstituencyService(IDistrictConstituencyRepository districtConstituencyRepository)
        {
            this._districtConstituencyRepository = districtConstituencyRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.DistrictConstituencyEntity> GetByIdAsync(int id)
        {
            return await this._districtConstituencyRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.DistrictConstituencyEntity>> GetAllAsync()
        {
            return await this._districtConstituencyRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.DistrictConstituencyEntity entityToInsert)
        {
            try
            {
                await this._districtConstituencyRepository.InsertAsync(entityToInsert);
                return entityToInsert.DistrictId;//actually districtconstituencyid?
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.DistrictConstituencyEntity entityToUpdate)
        {
            try
            {
                return await this._districtConstituencyRepository.UpdateAsync(entityToUpdate);

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
                return await this._districtConstituencyRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
