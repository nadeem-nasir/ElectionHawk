using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.Models
{
    /// <summary>
    /// using in crawler to import Constituency, PollingScheme and PollingSchemeStation from ECP website 
    /// </summary>
    public class ConstituencyImportModel
    {
        public int ProvCode { get; set; }
        public int ConstCode { get; set; }
        public string ElectionType { get; set; }
        public string ConstituencyNoAndName { get; set; }
        public string DistrictName { get; set; }
        public PollingSchemeImportModel PollingScheme  { get; set; }
    }

    /// <summary>
    /// Polling scheme for a constituency
    /// </summary>
    public class PollingSchemeImportModel
    {
        public PollingSchemeImportModel()
        {
            pollingSchemeStations = new List<PollingSchemeStationImportModel>();

        }
        public int PollingSchemeId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public int ElectionId { get; set; }
        public int ConstituencyId { get; set; }
        public List<PollingSchemeStationImportModel> pollingSchemeStations { get; set; }
    }

    /// <summary>
    /// Polling scheme stations 
    /// </summary>
    public class PollingSchemeStationImportModel
    {
        //public string PSNo { get; set; }
        //public int StationId { get; set; }
        public int? ECPPSNo { get; set; }
        public string StationName { get; set; }
        public int? MaleBooths { get; set; }
        public int? FemaleBooths { get; set; }
        public int? TotalBooths { get; set; }
        public int? MaleVoters { get; set; }
        public int? FemaleVoters { get; set; }
        public int? TotalVoters { get; set; }
        public string PollingStationImageUrl { get; set; }
        public string PollingStationMapUrl { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
    }
}
