using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.Models
{
    public class CityCreateModel
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
        public int Population { get; set; }
    }


    public class CityUpdateModel
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
        public int Population { get; set; }
    }

    public class CityViewModel
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
        public int Population { get; set; }
    }

}
