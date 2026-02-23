using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.Models
{
    public class ConstituencyCreateModel
    {
        public int ConstituencyId { get; set; }
        public int ConstituencyTypeId { get; set; }
        public string ConstituencyTitle { get; set; }
        public string ConstituencyName { get; set; }
        public int? MapId { get; set; }
        public int? AreaId { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? ProvinceId { get; set; }
        public int? ECPConstCode { get; set; }

        //public int ProvCode { get; set; }
        //public int ConstCode { get; set; }
        //public string ElectionType { get; set; }
        //public string ConstituencyNoAndName { get; set; }
    }
    public class ConstituencyUpdateModel
    {
        public int ConstituencyId { get; set; }
        public int ConstituencyTypeId { get; set; }
        public string ConstituencyTitle { get; set; }
        public string ConstituencyName { get; set; }
        public int? MapId { get; set; }
        public int? AreaId { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? ProvinceId { get; set; }
        public int? ECPConstCode { get; set; }
    }
    public class ConstituencyViewModel
    {
        public int ConstituencyId { get; set; }
        public int ConstituencyTypeId { get; set; }
        public string ConstituencyTitle { get; set; }
        public string ConstituencyName { get; set; }
        public int? MapId { get; set; }
        public int? AreaId { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? ProvinceId { get; set; }
        public int? ECPConstCode { get; set; }
    }
}
