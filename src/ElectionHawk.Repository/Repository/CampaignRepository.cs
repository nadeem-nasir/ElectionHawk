using System;
using System.Collections.Generic;
using System.Text;
using ElectionHawk.Common.Interfaces;
using ElectionHawk.Common.AppSettings;
using Dapper;
using Dapper.FastCrud;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
using System.Linq;
namespace ElectionHawk.Repository
{

    public class CampaignRepository : RepositoryBase, ICampaignRepository
    {
        public CampaignRepository(ConnectionString connectionString) : base(connectionString) { }
        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.CampaignEntity> GetByIdAsync(int id)
        {
            try
            {
                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {

                   connection.Open();
                    //  var result = await connection.GetAsync<entity.CampaignEntity>(new entity.CampaignEntity { CampaignId = id });
                    var sql = @"SELECT c.CampaignId, c.Title, c.Media, c.MediumofPropagation, c.Forum, c.AgendaId, ai.* from [dbo].[Campaign] c
                                inner join [dbo].[AgendaItem] ai on ai.ItemId = c.AgendaId where c.CampaignId = " + id;

                    var result = await connection.QueryAsync<entity.CampaignEntity, entity.AgendaItemEntity, entity.CampaignEntity>(sql, (c, ai) =>
                    {
                        c.agendaItemEntity = ai;
                        return c;
                    }, splitOn: "AgendaId, ItemId");
                    return result.SingleOrDefault<entity.CampaignEntity>();
                    
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.CampaignEntity>> GetAllAsync()
        {
            try
            {
                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {
                   /* var sql = @"SELECT c.CampaignId, c.Title, c.Media, c.MediumofPropagation, c.Forum, c.AgendaId 
                                 , a.Title, a.CandidateProfileId, a.AgendaId as CandidateAgendaId  , 
                                 cai.AgendaId as CandidateAgendaId, cai.ItemId as CandidateAgendaItemId, ai.*  from [dbo].[Campaign] c 
                                LEFT  JOIN [dbo].[CandidateAgenda] a on c.AgendaId = a.AgendaId
                                LEFT JOIN [dbo].[CandidateAgendaItem] cai on a.AgendaId = cai.AgendaId
                                LEFT JOIN [dbo].[AgendaItem] ai on cai.ItemId = ai.ItemId ";*/
                    var sql = @"SELECT c.CampaignId, c.Title, c.Media, c.MediumofPropagation, c.Forum, c.AgendaId 
                                 , ai.*  from [dbo].[Campaign] c 
                                
                                inner JOIN [dbo].[AgendaItem] ai on ai.ItemId = c.AgendaId ";
                    connection.Open();
                    var campaignEntity =  await connection.QueryAsync<entity.CampaignEntity, entity.AgendaItemEntity, entity.CampaignEntity>(sql, (c,  ai) =>
                    {
                        c.agendaItemEntity = ai;                       
                        return c;
                    }, splitOn: "AgendaId, ItemId");
                    return campaignEntity;                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
                    //OrmConfiguration.GetSqlBuilder<entity.CampaignEntity>().Format()
                    /*return await connection.FindAsync<entity.CampaignEntity>(statement => statement
                   .Include<entity.AgendaItemEntity>());                
                    //return await connection.QueryAsync <entity.CampaignEntity> (BuildCampaignListQuery());
                    //return await connection.FindAsync<entity.CampaignEntity>();
                */
        //private string BuildCampaignListQuery()
        //{
        //    var AgendaItemEntity = Sql.Table<entity.AgendaItemEntity>();
        //    var CampaignTable = Sql.Table<entity.CampaignEntity>();

        //    var CampaignColumnId = Sql.TableAndColumn<entity.CampaignEntity>(nameof(entity.CampaignEntity.CampaignId));
        //    var CampaignColumnName = Sql.TableAndColumn<entity.CampaignEntity>(nameof(entity.CampaignEntity.Title));
        //    var CampaignColumnMedia = Sql.TableAndColumn<entity.CampaignEntity>(nameof(entity.CampaignEntity.Media));
        //    var CampaignColumnForum = Sql.TableAndColumn<entity.CampaignEntity>(nameof(entity.CampaignEntity.Forum));
        //    var CampaignColumnMedium = Sql.TableAndColumn<entity.CampaignEntity>(nameof(entity.CampaignEntity.MediumofPropagation));
        //    var CampaignColumnAgenda = Sql.TableAndColumn<entity.CampaignEntity>(nameof(entity.CampaignEntity.AgendaId));

        //    var AgendItemColumnId = Sql.TableAndColumn<entity.AgendaItemEntity>(nameof(entity.AgendaItemEntity.ItemId));
        //    var AgendItemColumnName = Sql.TableAndColumn<entity.AgendaItemEntity>(nameof(entity.AgendaItemEntity.Description));

        //    string sqlBuilderResult = OrmConfiguration.GetSqlBuilder<entity.CampaignEntity>()
        //        .Format(
        //            $@"SELECT {CampaignColumnId}, {CampaignColumnName}, {CampaignColumnMedia}, {CampaignColumnForum}, 
        //                {AgendItemColumnName} as ""AgendItemName"" FROM {CampaignTable}
        //                LEFT JOIN {AgendaItemEntity} ON {CampaignColumnAgenda} = {AgendItemColumnId}");


        //    return sqlBuilderResult;
        //}
        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.CampaignEntity entityToInsert)
        {
            try
            {
                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {
                    connection.Open();
                    await connection.InsertAsync(entityToInsert);
                    return entityToInsert.CampaignId;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.CampaignEntity entityToUpdate)
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
                    return await connection.DeleteAsync<entity.CampaignEntity>(new entity.CampaignEntity { CampaignId = id });
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
