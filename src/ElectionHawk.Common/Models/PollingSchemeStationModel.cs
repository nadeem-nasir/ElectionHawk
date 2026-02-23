using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.Models
{
    public class PollingSchemeStationCreateModel
    {
        public int StationId { get; set; }
        public string StationName { get; set; }
        public int MaleBooths { get; set; }
        public int FemaleBooths { get; set; }
        public int TotalBooths { get; set; }
        public int MaleVoters { get; set; }
        public int FemaleVoters { get; set; }
        public int TotalVoters { get; set; }
        public decimal Latitued { get; set; }
        public decimal Longitude { get; set; }
        public byte[] PollingStationImage { get; set; }
        public string PollingStationMapUrl { get; set; }
        public int  ECPPSNo { get; set; }


    }


    public class PollingSchemeStationUpdateModel
    {
        public int StationId { get; set; }
        public string StationName { get; set; }
        public int MaleBooths { get; set; }
        public int FemaleBooths { get; set; }
        public int TotalBooths { get; set; }
        public int MaleVoters { get; set; }
        public int FemaleVoters { get; set; }
        public int TotalVoters { get; set; }
        public decimal Latitued { get; set; }
        public decimal Longitude { get; set; }
        public byte[] PollingStationImage { get; set; }
        public string PollingStationMapUrl { get; set; }
        public int ECPPSNo { get; set; }
    }

    public class PollingSchemeStationViewModel
    {
        public int StationId { get; set; }
        public string StationName { get; set; }
        public int MaleBooths { get; set; }
        public int FemaleBooths { get; set; }
        public int TotalBooths { get; set; }
        public int MaleVoters { get; set; }
        public int FemaleVoters { get; set; }
        public int TotalVoters { get; set; }
        public decimal Latitued { get; set; }
        public decimal Longitude { get; set; }
        public byte[] PollingStationImage { get; set; }
        public string PollingStationMapUrl { get; set; }
        public int ECPPSNo { get; set; }
    }

}
