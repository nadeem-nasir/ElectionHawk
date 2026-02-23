using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.Models
{
    public class MapCreateModel
    {
        public int MapId { get; set; }
        public string LocationTitle { get; set; }
        public string LocationPoints { get; set; }
    }


    public class MapUpdateModel
    {
        public int MapId { get; set; }
        public string LocationTitle { get; set; }
        public string LocationPoints { get; set; }
    }

    public class MapViewModel
    {
        public int MapId { get; set; }
        public string LocationTitle { get; set; }
        public string LocationPoints { get; set; }
    }

}
