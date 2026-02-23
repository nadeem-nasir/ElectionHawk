using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.Models
{
    public class DistrictCreateModel
    {
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
    }


    public class DistrictUpdateModel
    {
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
    }

    public class DistrictViewModel
    {
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
    }

}
