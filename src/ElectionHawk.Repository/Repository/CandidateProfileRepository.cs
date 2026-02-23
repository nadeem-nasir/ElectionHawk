using System;
using System.Collections.Generic;
using System.Text;
using ElectionHawk.Common.Interfaces;
using ElectionHawk.Common.AppSettings;
using Dapper;
using Dapper.FastCrud;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
using model = ElectionHawk.Common.Models;
using System.Data.SqlClient;
using System.Data;
using ElectionHawk.Repository.Helpers;
using System.Linq;
namespace ElectionHawk.Repository
{
   
    public  class CandidateProfileRepository : RepositoryBase, ICandidateProfileRepository
    {
        public CandidateProfileRepository(ConnectionString connectionString) : base(connectionString) { }
        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.CandidateProfileEntity> GetByIdAsync(int id)
        {
            try
            {
                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {
                    connection.Open();
                    var sql = @"select  cp.CandidateProfileId,
cp.Name, cp.Age, cp.Gender, cp.Address, cp.Picture,
cp.Phone1, cp.Phone2, cp.Email, cp.Whatsapp, cp.FacebookUrl, cp.TwitterUrl, 
cp.MediaPresence,
cp.ConstituencyId, 
cp.PoliticalPartyId,
 cp.ProfileTypeId,
cc.constituencyId, 
cc.constituencyTitle, 
pp.politicalpartyId,


 pp.Name, pt.Description from candidateprofile cp
 inner join constituency cc on cc.constituencyId = cp.constituencyId
 inner join PoliticalParty pp on pp.politicalPartyId = cp.politicalpartyId
 inner join ProfileType pt on pt.profileTypeId = cp.ProfileTypeId where cp.candidateProfileId=" + id;

                    var result =  await connection.QueryAsync<entity.CandidateProfileEntity,entity.ConstituencyEntity, entity.PoliticalPartyEntity,
                                                        entity.ProfileTypeEntity, entity.CandidateProfileEntity>
                                                        (sql,(cp,ce,pp, pt)=> {

                                                            cp.constituency = ce;
                                                            cp.PoliticalParty = pp;
                                                            cp.profileType = pt;
                                                            return cp;
                                                        }, splitOn: "CandidateProfileId,ConstituencyId,PoliticalPartyId,ProfileTypeId");
                    
                    return result.SingleOrDefault<entity.CandidateProfileEntity>() ; 
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        ///// <summary>
        ///// get all 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public async Task<IEnumerable<entity.CandidateProfileEntity>> GetAllAsync()
        //{
        //    using (var connection = MyDapper.CreateConnection(GetConnectionString))
        //    {
        //        connection.Open();
        //        return await connection.FindAsync<entity.CandidateProfileEntity>();
        //    }
        //}
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.CandidateProfileEntity>> GetAllAsync()
        {
            try
            {
                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {
                   
                    var sql = @"select cp.*,c.constituencyTitle, pp.* from candidateprofile cp
                                inner join constituency c
                                on cp.constituencyId = c.constituencyId
                                inner join PoliticalParty pp
                                on pp.PoliticalPartyId= cp.PoliticalPartyId

                                 ";
                    connection.Open();
                    var candidateEntity = await connection.QueryAsync<entity.CandidateProfileEntity, entity.ConstituencyEntity, 
                        entity.PoliticalPartyEntity, entity.CandidateProfileEntity>(sql, (c, ce, pp) =>
                    {

                        c.constituency = ce;
                        c.PoliticalParty = pp;
                        return c;
                    }, splitOn: "ConstituencyId, PoliticalPartyId");
                    return candidateEntity;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {
                    connection.Open();
                    await connection.InsertAsync(entityToInsert);
                    return entityToInsert.CandidateProfileId;
                }
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
                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {
                    connection.Open();
                    return await connection.UpdateAsync(entityToUpdate);
                }
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
                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {
                    connection.Open();
                    return await connection.DeleteAsync<entity.CandidateProfileEntity>(new entity.CandidateProfileEntity { CandidateProfileId = id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



    }
}
