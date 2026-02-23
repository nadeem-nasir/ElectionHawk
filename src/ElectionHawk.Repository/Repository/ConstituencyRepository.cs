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
namespace ElectionHawk.Repository
{

    public class ConstituencyRepository : RepositoryBase, IConstituencyRepository
    {

        public ConstituencyRepository(ConnectionString connectionString) : base(connectionString) { }
        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.ConstituencyEntity> GetByIdAsync(int id)
        {
            using (var connection = MyDapper.CreateConnection(GetConnectionString))
            {
                connection.Open();
                return await connection.GetAsync<entity.ConstituencyEntity>(new entity.ConstituencyEntity { ConstituencyId = id });
            }
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.ConstituencyEntity>> GetAllAsync()
        {
            using (var connection = MyDapper.CreateConnection(GetConnectionString))
            {
                connection.Open();
                return await connection.FindAsync<entity.ConstituencyEntity>();
            }
        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.ConstituencyEntity entityToInsert)
        {
            try
            {
                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {
                    connection.Open();
                    await connection.InsertAsync(entityToInsert);
                    return entityToInsert.ConstituencyId;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.ConstituencyEntity entityToUpdate)
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
                    return await connection.DeleteAsync<entity.ConstituencyEntity>(new entity.ConstituencyEntity { ConstituencyId = id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Sql bulkcopy and import

        /// <summary>
        /// Import District, Constituency, pollingScheme, pollingScheme stations for ECP website 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> SqlBulkCopy(model.ConstituencyImportModel entityToInsert)
        {
            try
            {         
                var sqlDistrictFind = @"SELECT * FROM District WHERE LOWER(Name)= @Name";
                var sqlConstituencyFind = @"SELECT * FROM Constituency WHERE ECPConstCode = @ECPConstCode AND ConstituencyTypeId = @ConstituencyTypeId AND ProvinceId = @ProvinceId";
                var sqlDistrictConstituency = @"SELECT * FROM DistrictConstituency WHERE DistrictId = @DistrictId AND  ConstituencyId = @ConstituencyId";
                using (var connection = MyDapper.CreateSqlConnection(GetConnectionString))
                {
                    connection.Open();
                    var provinceId = GetProvinceIdFromECPProvCode(entityToInsert.ProvCode);
                    var constituencyTypeId = GetConstituencyType(entityToInsert.ElectionType);
                    var districtEntity = connection.QueryFirstOrDefault<entity.DistrictEntity>(sqlDistrictFind, new
                    { Name = entityToInsert.DistrictName.ToLower() });
                    if (districtEntity == null)
                    {
                        districtEntity = new entity.DistrictEntity();
                        districtEntity.Name = entityToInsert.DistrictName.ToLower();
                        districtEntity.ProvinceId = provinceId.Value;
                        await connection.InsertAsync(districtEntity);
                    }
                    var constituencyEntity = connection.QueryFirstOrDefault<entity.ConstituencyEntity>(sqlConstituencyFind, new
                    {
                        ECPConstCode = entityToInsert.ConstCode,
                        ConstituencyTypeId = constituencyTypeId,
                        ProvinceId = provinceId
                    });
                    if (constituencyEntity == null)
                    {
                        constituencyEntity = new entity.ConstituencyEntity();
                        constituencyEntity.ConstituencyTypeId = constituencyTypeId.Value;
                        constituencyEntity.ConstituencyTitle = entityToInsert.ConstituencyNoAndName;
                        constituencyEntity.ConstituencyName = entityToInsert.ConstituencyNoAndName;
                        constituencyEntity.MapId = (int?)null;
                        constituencyEntity.AreaId = (int?)null;
                        constituencyEntity.CityId = (int?)null;
                        constituencyEntity.ECPConstCode = entityToInsert.ConstCode;
                        constituencyEntity.DistrictId = districtEntity.DistrictId;
                        constituencyEntity.ProvinceId = provinceId;
                        await connection.InsertAsync(constituencyEntity);
                    }
                    var districtConstituencyEntity = connection.QueryFirstOrDefault<entity.DistrictConstituencyEntity>(sqlDistrictConstituency,
                        new
                        {
                            DistrictId = districtEntity.DistrictId,
                            ConstituencyId = constituencyEntity.ConstituencyId
                        });
                    if (districtConstituencyEntity == null)
                    {
                        await connection.InsertAsync<entity.DistrictConstituencyEntity>(new entity.DistrictConstituencyEntity
                        {
                          DistrictId = districtEntity.DistrictId,
                          ConstituencyId = constituencyEntity.ConstituencyId
                        });
                    }
                    
                    //Todo: If stations already exsit then do the merge and update
                    var pollingSchemeEntity = new entity.PollingSchemeEntity();
                    pollingSchemeEntity.Type = entityToInsert.PollingScheme.Type;
                    pollingSchemeEntity.Title = entityToInsert.PollingScheme.Title;
                    pollingSchemeEntity.ElectionId = entityToInsert.PollingScheme.ElectionId;
                    pollingSchemeEntity.ConstituencyId = constituencyEntity.ConstituencyId;
                    await connection.InsertAsync(pollingSchemeEntity);
                    using (SqlTransaction sqlTransaction = connection.BeginTransaction())
                    {
                        using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, sqlTransaction))
                        {
                            try
                            {
                                var  dt = entityToInsert.PollingScheme.pollingSchemeStations.ToDataTable();
                                bulkcopy.ColumnMappings.Add("StationName", "StationName");
                                bulkcopy.ColumnMappings.Add("MaleBooths", "MaleBooths");
                                bulkcopy.ColumnMappings.Add("FemaleBooths", "FemaleBooths");
                                bulkcopy.ColumnMappings.Add("TotalBooths", "TotalBooths");
                                bulkcopy.ColumnMappings.Add("MaleVoters", "MaleVoters");
                                bulkcopy.ColumnMappings.Add("FemaleVoters", "FemaleVoters");
                                bulkcopy.ColumnMappings.Add("TotalVoters", "TotalVoters");
                                bulkcopy.ColumnMappings.Add("Latitude", "Latitude");
                                bulkcopy.ColumnMappings.Add("Longitude", "Longitude");
                                bulkcopy.ColumnMappings.Add("PollingStationImageUrl", "PollingStationImageUrl");
                                bulkcopy.ColumnMappings.Add("PollingStationMapUrl", "PollingStationMapUrl");
                                bulkcopy.ColumnMappings.Add("ECPPSNo", "ECPPSNo");
                                bulkcopy.BatchSize = 10000;
                                bulkcopy.BulkCopyTimeout = 5000;
                                bulkcopy.DestinationTableName = "PollingSchemeStation";
                                bulkcopy.WriteToServer(dt.CreateDataReader());
                                sqlTransaction.Commit();
                            }
                            catch(Exception ex )
                            {
                                sqlTransaction.Rollback();
                            }
                        }
                    }
                }
                return 0;//todo
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region helpers
        private int? GetProvinceIdFromECPProvCode(int eCPProvCode)
        {
            switch (eCPProvCode)
            {
                case 9: //kPK 
                    {
                        return 1;
                    }
                case 11: //Punjab
                    {
                        return 3;

                    }
                case 12://Sindh
                    {
                        return 4;
                    }
                    //case 12://Balochistan
                    //    {
                    //        return 4;
                    //    }
            }
            return null;
        }
        private int? GetConstituencyType(string ecpElectionType)
        {
            switch (ecpElectionType)
            {
                case "NA":
                    {
                        return 1;
                    }
                case "PA":
                    {
                        return 2;
                    }
            }
            return null;
        }
        #endregion
    }
}

