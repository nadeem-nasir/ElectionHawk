using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.Models
{
    public class ProvinceCreateModel
    {
        public int ProvinceId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int CountryId { get; set; }
    }


    public class ProvinceUpdateModel
    {
        public int ProvinceId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int CountryId { get; set; }
    }

    public class ProvinceViewModel
    {
        public int ProvinceId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int CountryId { get; set; }
    }

}
